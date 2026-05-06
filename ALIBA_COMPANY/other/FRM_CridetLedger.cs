using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_CridetLedger : XtraForm
    {
        private List<LedgerRow> _rows = new List<LedgerRow>();
        private bool _gridReady = false;

        public FRM_CridetLedger()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void FRM_CridetLedger_Load(object sender, EventArgs e)
        {
            Dt_from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Dt_to.Value = DateTime.Now;
            LoadEmplo();
        }

        private void LoadEmplo()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var list = db.TB_emplo
                        .Where(x => x.emplo_dis == true && x.emplo_activity == true)
                        .Select(x => x.emplo_name)
                        .OrderBy(x => x)
                        .ToList();

                    list.Insert(0, "كل الموزعيين");
                    Combo_emplo.DataSource = list;
                    Combo_emplo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل الموزعين:\n" + ex.Message);
            }
        }

        private void SetupGrid()
        {
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.RowStyle += GridView1_RowStyle;
        }

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var action = gridView1.GetRowCellValue(e.RowHandle, "Action")?.ToString();
            switch (action)
            {
                case "بيع":
                    e.Appearance.BackColor = Color.FromArgb(255, 220, 220);
                    e.Appearance.ForeColor = Color.DarkRed;
                    break;
                case "دفع فوري":
                case "قبض اجل":
                    e.Appearance.BackColor = Color.FromArgb(220, 255, 220);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
                case "قبض نقدي":
                    e.Appearance.BackColor = Color.FromArgb(240, 255, 230);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
                case "صرف اجل":
                    e.Appearance.BackColor = Color.FromArgb(230, 245, 255);
                    e.Appearance.ForeColor = Color.DarkBlue;
                    break;
                case "صرف نقدي":
                    e.Appearance.BackColor = Color.FromArgb(220, 240, 255);
                    e.Appearance.ForeColor = Color.DarkBlue;
                    break;
            }
        }

        private void Btn_search_Click(object sender, EventArgs e) => Search();

        private void Txt_cust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void Combo_emplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            Search();
        }

        private async void Search()
        {
            try
            {
                loading.Visible = true;
                Btn_search.Enabled = false;

                string emplo = Combo_emplo.SelectedItem?.ToString();
                string cust = Txt_cust.Text.Trim();
                DateTime dtFrom = Dt_from.Value.Date;
                DateTime dtTo = Dt_to.Value.Date.AddDays(1).AddSeconds(-1);

                if (string.IsNullOrEmpty(emplo))
                {
                    XtraMessageBox.Show("الرجاء اختيار موزع");
                    return;
                }

                var rows = await Task.Run(() => FetchLedger(emplo, cust, dtFrom, dtTo));
                _rows = rows;
                BindGrid(rows);
                UpdateTotals(rows);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في البحث:\n" + ex.Message);
            }
            finally
            {
                loading.Visible = false;
                Btn_search.Enabled = true;
            }
        }

        private List<LedgerRow> FetchLedger(
            string emplo, string cust, DateTime from, DateTime to)
        {
            var raw = new List<(
                DateTime Date, int? Code, string Action,
                decimal AmountUsd, decimal AmountIq,
                bool IsDebit, string Client, string Note,
                decimal ExchRate)>();

            using (var db = new AlibaRamyEntities())
            {
                // ══════════════════════════════════════
                // 1) مبيعات آجلة من TB_list
                //    الدولار  = list_cridetUsd
                //    الدينار  = list_cridetIQ
                //    سعر الصرف = list_exch
                // ══════════════════════════════════════
                var salesQ = db.TB_list
                    .Where(l => l.cust_id != null && l.cust_id != 0 && l.sending == true)
                    .Where(l => l.list_date >= from && l.list_date <= to)
                    .Where(l => l.list_cridetUsd > 0);

                if (emplo != "كل الموزعيين")
                    salesQ = salesQ.Where(l => l.TB_emplo.emplo_name == emplo);
                if (!string.IsNullOrEmpty(cust))
                    salesQ = salesQ.Where(l => l.list_name == cust);

                foreach (var s in salesQ.Select(l => new
                {
                    Date = l.list_date,
                    Code = l.list_code,
                    Usd = l.list_cridetUsd ?? 0m,
                    Iq = l.list_cridetIQ ?? 0m,
                    Exch = l.list_exch ?? 0m,
                    Client = l.list_name,
                    Note = l.list_nots
                }).ToList())
                {
                    raw.Add((s.Date ?? DateTime.MinValue, s.Code,
                             "بيع", s.Usd, s.Iq, true,
                             s.Client ?? "", s.Note ?? "", s.Exch));
                }

                // ══════════════════════════════════════
                // 2) حركات القبض والصرف من TB_cridet
                // ✅ action_id:
                //    6 = قبض نقدي  → دائن  (IsDebit=false)
                //    7 = قبض اجل   → دائن  (IsDebit=false)
                //    8 = صرف نقدي  → مدين  (IsDebit=true)
                //    9 = صرف اجل   → مدين  (IsDebit=true)
                //    الدولار  = cridet_s
                //    الدينار  = cridet_d  ✅ (وليس cridet_amount)
                //    سعر الصرف = cridet_ex
                // ══════════════════════════════════════
                var cridetQ = db.TB_cridet
                    .Where(c => c.action_id == 6 || c.action_id == 7
                             || c.action_id == 8 || c.action_id == 9) // ✅ إضافة 8 و 9
                    .Where(c => c.cridet_date >= from && c.cridet_date <= to)
                    .Where(c => c.cridet_s > 0 && c.sending == true);

                if (emplo != "كل الموزعيين")
                    cridetQ = cridetQ.Where(c => c.TB_emplo.emplo_name == emplo);
                if (!string.IsNullOrEmpty(cust))
                    cridetQ = cridetQ.Where(c => c.list_name == cust);

                foreach (var p in cridetQ.Select(c => new
                {
                    Date = c.cridet_date,
                    Code = c.cridet_code,
                    Usd = c.cridet_s ?? 0m,
                    Iq = c.cridet_d ?? 0m,  // ✅ cridet_d وليس cridet_amount
                    Exch = c.cridet_ex ?? 0m,
                    Client = c.list_name,
                    ActionId = c.action_id,
                    Note = c.cridet_nots
                }).ToList())
                {
                    string act = p.ActionId == 6 ? "قبض نقدي"
                               : p.ActionId == 7 ? "قبض اجل"
                               : p.ActionId == 8 ? "صرف نقدي"
                               : p.ActionId == 9 ? "صرف اجل"
                               : "دفع فوري";

                    // قبض (6,7) = الموزع دفع  → دائن  → IsDebit = false
                    // صرف (8,9) = صرف للموزع  → مدين  → IsDebit = true
                    bool isDebit = (p.ActionId == 8 || p.ActionId == 9);

                    raw.Add((p.Date ?? DateTime.MinValue, p.Code,
                             act, p.Usd, p.Iq, isDebit,
                             p.Client ?? "", p.Note ?? "", p.Exch));
                }
            }

            raw = raw.OrderBy(r => r.Date).ThenBy(r => r.Code).ToList();

            decimal runUsd = 0, runIq = 0;
            var result = new List<LedgerRow>();
            int seq = 1;

            foreach (var r in raw)
            {
                decimal debitUsd = 0, creditUsd = 0;
                decimal debitIq = 0, creditIq = 0;

                if (r.IsDebit)
                {
                    debitUsd = r.AmountUsd; runUsd += r.AmountUsd;
                    debitIq = r.AmountIq; runIq += r.AmountIq;
                }
                else
                {
                    creditUsd = r.AmountUsd; runUsd -= r.AmountUsd;
                    creditIq = r.AmountIq; runIq -= r.AmountIq;
                }

                result.Add(new LedgerRow
                {
                    RowNum = seq++,
                    Wasel = r.Code,
                    Date = r.Date == DateTime.MinValue ? (DateTime?)null : r.Date,
                    Action = r.Action,
                    ExchRate = r.ExchRate,

                    DebitUsd = debitUsd,
                    CreditUsd = creditUsd,
                    AmountUsd = debitUsd > 0 ? debitUsd : creditUsd,
                    RunningUsd = Math.Abs(runUsd),

                    DebitIq = debitIq,
                    CreditIq = creditIq,
                    AmountIq = debitIq > 0 ? debitIq : creditIq,
                    RunningIq = Math.Abs(runIq),

                    RunningType = runUsd > 0 ? "مدين" : runUsd < 0 ? "دائن" : "صفر",
                    Client = r.Client,
                    Note = r.Note,
                });
            }

            return result;
        }

        private void BindGrid(List<LedgerRow> rows)
        {
            _gridReady = false; // ✅ إعادة ضبط الأعمدة في كل مرة

            gridControl1.DataSource = null;
            gridControl1.DataSource = rows;

            if (gridView1.Columns.Count == 0) return;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                col.Visible = false;

            SetCol("RowNum", "ت", 55, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Wasel", "الوصل", 100, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Date", "التاريخ", 160, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Action", "الحركة", 100, DevExpress.Utils.HorzAlignment.Center);
            SetCol("ExchRate", "سعر الصرف", 130, DevExpress.Utils.HorzAlignment.Center);
            SetCol("AmountUsd", "المبلغ $", 150, DevExpress.Utils.HorzAlignment.Center);
            SetCol("AmountIq", "المبلغ د.ع", 150, DevExpress.Utils.HorzAlignment.Center);
            SetCol("RunningUsd", "الرصيد $", 200, DevExpress.Utils.HorzAlignment.Center);
            SetCol("RunningIq", "الرصيد د.ع", 200, DevExpress.Utils.HorzAlignment.Center);
            SetCol("RunningType", "حالته", 70, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Client", "العميل", 250, DevExpress.Utils.HorzAlignment.Far);
            SetCol("Note", "ملاحظات", 350, DevExpress.Utils.HorzAlignment.Far);

            gridView1.Columns["Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Date"].DisplayFormat.FormatString = "dd/MM/yyyy";

            foreach (string f in new[] { "AmountUsd", "RunningUsd" })
            {
                gridView1.Columns[f].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns[f].DisplayFormat.FormatString = "N2";
            }
            foreach (string f in new[] { "AmountIq", "RunningIq" })
            {
                gridView1.Columns[f].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns[f].DisplayFormat.FormatString = "N0";
            }
            gridView1.Columns["ExchRate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["ExchRate"].DisplayFormat.FormatString = "N2";
        }

        private void SetCol(string field, string caption, int width,
                            DevExpress.Utils.HorzAlignment align)
        {
            var col = gridView1.Columns[field];
            if (col == null) return;
            col.Caption = caption;
            col.Width = width;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.AppearanceHeader.TextOptions.HAlignment = align;
            col.AppearanceCell.TextOptions.HAlignment = align;
        }

        private void UpdateTotals(List<LedgerRow> rows)
        {
            decimal totalDebitUsd = rows.Sum(r => r.DebitUsd);
            decimal totalCreditUsd = rows.Sum(r => r.CreditUsd);
            decimal netUsd = totalDebitUsd - totalCreditUsd;

            decimal totalDebitIq = rows.Sum(r => r.DebitIq);
            decimal totalCreditIq = rows.Sum(r => r.CreditIq);
            decimal netIq = totalDebitIq - totalCreditIq;

            Lbl_total_debit.Text = $"إجمالي المبيعات\n$ {totalDebitUsd:N2}\n{totalDebitIq:N0} د.ع";
            Lbl_total_credit.Text = $"إجمالي المدفوعات\n$ {totalCreditUsd:N2}\n{totalCreditIq:N0} د.ع";
            Lbl_net.Text = $"صافي الدين\n$ {netUsd:N2}\n{netIq:N0} د.ع";

            Lbl_total_debit.AutoSize = false;
            Lbl_total_credit.AutoSize = false;
            Lbl_net.AutoSize = false;

           

            Lbl_net.ForeColor = netUsd > 0 ? Color.DarkRed :
                                netUsd < 0 ? Color.DarkGreen : Color.Black;
        }

        private void Btn_xls_Click(object sender, EventArgs e)
        {
            if (_rows == null || !_rows.Any())
            {
                XtraMessageBox.Show("لا توجد بيانات للتصدير");
                return;
            }
            try
            {
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                string emplo = Combo_emplo.SelectedItem?.ToString() ?? "الموزع";
                string cust = string.IsNullOrWhiteSpace(Txt_cust.Text) ? "كل العملاء" : Txt_cust.Text.Trim();

                using (var dlg = new SaveFileDialog
                {
                    FileName = $"كشف_{cust}_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx",
                    Filter = "Excel|*.xlsx",
                    Title = "حفظ كملف Excel"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    using (var pkg = new OfficeOpenXml.ExcelPackage(new System.IO.FileInfo(dlg.FileName)))
                    {
                        var ws = pkg.Workbook.Worksheets.Add("كشف الموزع");

                        string[] hdrs = {
                            "ت","الوصل","التاريخ","الحركة","سعر الصرف",
                            "المبلغ $","المبلغ د.ع",
                            "الرصيد $","الرصيد د.ع",
                            "حالته","العميل","ملاحظات"
                        };

                        for (int c = 0; c < hdrs.Length; c++)
                        {
                            var cell = ws.Cells[1, c + 1];
                            cell.Value = hdrs[c];
                            cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.SteelBlue);
                            cell.Style.Font.Color.SetColor(Color.White);
                            cell.Style.Font.Bold = true;
                            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        }

                        int row = 2;
                        foreach (var r in _rows)
                        {
                            ws.Cells[row, 1].Value = r.RowNum;
                            ws.Cells[row, 2].Value = r.Wasel;
                            ws.Cells[row, 3].Value = r.Date?.ToString("dd/MM/yyyy");
                            ws.Cells[row, 4].Value = r.Action;
                            ws.Cells[row, 5].Value = r.ExchRate;
                            ws.Cells[row, 6].Value = r.AmountUsd;
                            ws.Cells[row, 7].Value = r.AmountIq;
                            ws.Cells[row, 8].Value = r.RunningUsd;
                            ws.Cells[row, 9].Value = r.RunningIq;
                            ws.Cells[row, 10].Value = r.RunningType;
                            ws.Cells[row, 11].Value = r.Client;
                            ws.Cells[row, 12].Value = r.Note;

                            ws.Cells[row, 5].Style.Numberformat.Format = "#,##0.00";
                            ws.Cells[row, 6].Style.Numberformat.Format = "#,##0.00";
                            ws.Cells[row, 7].Style.Numberformat.Format = "#,##0";
                            ws.Cells[row, 8].Style.Numberformat.Format = "#,##0.00";
                            ws.Cells[row, 9].Style.Numberformat.Format = "#,##0";

                            Color rowColor = (r.Action == "بيع" || r.Action == "صرف اجل" || r.Action == "صرف نقدي")
                                ? Color.FromArgb(255, 235, 235)
                                : Color.FromArgb(235, 255, 235);

                            ws.Cells[row, 1, row, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, 1, row, 12].Style.Fill.BackgroundColor.SetColor(rowColor);
                            row++;
                        }

                        decimal tdU = _rows.Sum(r => r.DebitUsd), tcU = _rows.Sum(r => r.CreditUsd);
                        decimal tdI = _rows.Sum(r => r.DebitIq), tcI = _rows.Sum(r => r.CreditIq);

                        void WriteTotal(int r2, string lbl, decimal usd, decimal iq)
                        {
                            ws.Cells[r2, 4].Value = lbl;
                            ws.Cells[r2, 4].Style.Font.Bold = true;
                            ws.Cells[r2, 6].Value = usd;
                            ws.Cells[r2, 6].Style.Numberformat.Format = "#,##0.00";
                            ws.Cells[r2, 7].Value = iq;
                            ws.Cells[r2, 7].Style.Numberformat.Format = "#,##0";
                        }

                        WriteTotal(row, "إجمالي المبيعات:", tdU, tdI);
                        WriteTotal(row + 1, "إجمالي المدفوعات:", tcU, tcI);
                        WriteTotal(row + 2, "صافي الدين:", tdU - tcU, tdI - tcI);

                        ws.Cells.AutoFitColumns();
                        pkg.Save();
                    }

                    XtraMessageBox.Show("✅ تم التصدير بنجاح");
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في التصدير:\n" + ex.Message);
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                var ps = new DevExpress.XtraPrinting.PrintingSystem();
                ps.PageSettings.Landscape = true;
                ps.PageSettings.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)
                                             System.Drawing.Printing.PaperKind.A4;

                string emplo = Combo_emplo.SelectedItem?.ToString() ?? "";
                string cust = string.IsNullOrWhiteSpace(Txt_cust.Text) ? "كل العملاء" : Txt_cust.Text.Trim();
                string period = $"{Dt_from.Value:dd/MM/yyyy} - {Dt_to.Value:dd/MM/yyyy}";

                var link = new DevExpress.XtraPrinting.PrintableComponentLink(ps)
                {
                    Component = gridControl1,
                    Landscape = true,
                    Margins = new System.Drawing.Printing.Margins(15, 15, 15, 15),
                };

               

                link.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(
                   new DevExpress.XtraPrinting.PageHeaderArea(
                       new string[]
                       {
                           $"كشف حساب موزع  |  الموزع: {emplo}  |  العميل: {cust}  |  الفترة: {period}",
                           "", ""
                       },
                       new Font("Arial", 10, FontStyle.Bold),
                       DevExpress.XtraPrinting.BrickAlignment.Near
                   ),
                   null
                );

              

                link.CreateDocument();

                var preview = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
                {
                    PrintingSystem = ps,
                    RightToLeft = RightToLeft.Yes,
                };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في الطباعة:\n" + ex.Message);
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e) { }
    }

    // ══════════════════════════════════════════════════════════════════
    //  LedgerRow — مع حقول الدينار العراقي
    // ══════════════════════════════════════════════════════════════════
    public class LedgerRow
    {
        public int RowNum { get; set; }
        public int? Wasel { get; set; }
        public DateTime? Date { get; set; }
        public string Action { get; set; }
        public decimal ExchRate { get; set; }

        // دولار
        public decimal DebitUsd { get; set; }
        public decimal CreditUsd { get; set; }
        public decimal AmountUsd { get; set; }
        public decimal RunningUsd { get; set; }

        // دينار عراقي
        public decimal DebitIq { get; set; }
        public decimal CreditIq { get; set; }
        public decimal AmountIq { get; set; }
        public decimal RunningIq { get; set; }

        public string RunningType { get; set; }
        public string Client { get; set; }
        public string Note { get; set; }
    }
}