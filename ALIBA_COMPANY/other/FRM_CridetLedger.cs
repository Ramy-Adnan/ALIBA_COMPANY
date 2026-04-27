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

        // ════════════════════════════════════════════════════════════
        // LOAD
        // ════════════════════════════════════════════════════════════
        private void FRM_CridetLedger_Load(object sender, EventArgs e)
        {
            Dt_from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Dt_to.Value = DateTime.Now;
            LoadEmplo();
        }

        // ════════════════════════════════════════════════════════════
        // تحميل الموزعين
        // ════════════════════════════════════════════════════════════
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

        // ════════════════════════════════════════════════════════════
        // إعداد Grid — مرة واحدة فقط من Constructor
        // ════════════════════════════════════════════════════════════
        private void SetupGrid()
        {
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.RowStyle += GridView1_RowStyle;
        }

        // ════════════════════════════════════════════════════════════
        // تلوين الصفوف
        // ════════════════════════════════════════════════════════════
        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var action = gridView1.GetRowCellValue(e.RowHandle, "Action")?.ToString();
            switch (action)
            {
                case "بيع":
                    e.Appearance.BackColor = Color.FromArgb(255, 240, 240);
                    e.Appearance.ForeColor = Color.DarkRed;
                    break;
                case "دفع فوري":


                case "قبض اجل":
                    e.Appearance.BackColor = Color.FromArgb(240, 255, 240);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
                case "قبض نقدي":
                    e.Appearance.BackColor = Color.FromArgb(250, 255, 240);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
                case "صرف اجل":
                    e.Appearance.BackColor = Color.FromArgb(260, 255, 240);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;

                case "صرف نقدي":
                    e.Appearance.BackColor = Color.FromArgb(280, 255, 240);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
            }
        }

        // ════════════════════════════════════════════════════════════
        // أحداث عناصر التحكم
        // ════════════════════════════════════════════════════════════
        private void Btn_search_Click(object sender, EventArgs e) => Search();

     

        private void Txt_cust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void Combo_emplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IsHandleCreated يمنع استدعاء Search أثناء LoadEmplo في الـ Load
            if (!this.IsHandleCreated) return;
            Search();
        }

        // ════════════════════════════════════════════════════════════
        // Search
        // ════════════════════════════════════════════════════════════
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

        // ════════════════════════════════════════════════════════════
        // FetchLedger — جلب البيانات وحساب الرصيد التراكمي
        // ════════════════════════════════════════════════════════════
        private List<LedgerRow> FetchLedger(
            string emplo, string cust, DateTime from, DateTime to)
        {
            var raw = new List<(DateTime Date, int? Code, string Action,
                                decimal Amount, bool IsDebit, string Client, string Note)>();

            using (var db = new AlibaRamyEntities())
            {
                // ── 1) مبيعات آجلة من TB_list ──────────────────────
                var salesQ = db.TB_list
                    .Where(l => l.cust_id != null && l.cust_id != 0)
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
                    Amountusd = l.list_cridetUsd ?? 0m,
                    Amountdnr = l.list_cridetUsd ?? 0m,
                    Client = l.list_name,
                    Note = l.list_nots
                }).ToList())
                {
                    raw.Add((s.Date ?? DateTime.MinValue, s.Code,
                             "بيع", s.Amountusd, true, s.Client ?? "", s.Note ?? ""));
                }

                // ── 2) مدفوعات من TB_cridet ────────────────────────
                // 6 = قبض نقدي  ،  7 = قبض دين
                var cridetQ = db.TB_cridet
                    .Where(c => c.action_id == 6 || c.action_id == 7)
                    .Where(c => c.cridet_date >= from && c.cridet_date <= to)
                    .Where(c => c.cridet_s > 0);

                if (emplo != "كل الموزعيين")
                    cridetQ = cridetQ.Where(c => c.TB_emplo.emplo_name == emplo);
                if (!string.IsNullOrEmpty(cust))
                    cridetQ = cridetQ.Where(c => c.list_name == cust);

                foreach (var p in cridetQ.Select(c => new
                {
                    Date = c.cridet_date,
                    Code = c.cridet_code,
                    Amount = c.cridet_s ?? 0m,
                    Client = c.list_name,
                    ActionId = c.action_id,
                    Note = c.cridet_nots
                }).ToList())
                {
                   
                    string act = p.ActionId == 6 ? "قبض نقدي" : p.ActionId == 7 ? "قبض اجل" : p.ActionId == 8 ? "صرف نقدي" : p.ActionId == 9 ? "صرف اجل" : "دفع فوري";

                    raw.Add((p.Date ?? DateTime.MinValue, p.Code,
                             act, p.Amount, false, p.Client ?? "", p.Note ?? ""));
                }
            }

            // ── ترتيب زمني ────────────────────────────────────────
            raw = raw.OrderBy(r => r.Date).ThenBy(r => r.Code).ToList();

            // ── رصيد تراكمي: بيع (+) ، دفع (-) ──────────────────
            decimal running = 0;
            var result = new List<LedgerRow>();
            int seq = 1;

            foreach (var r in raw)
            {
                decimal debit = 0, credit = 0;
                if (r.IsDebit) { debit = r.Amount; running += r.Amount; }
                else { credit = r.Amount; running -= r.Amount; }

                result.Add(new LedgerRow
                {
                    RowNum = seq++,
                    Wasel = r.Code,
                    Date = r.Date == DateTime.MinValue ? (DateTime?)null : r.Date,
                    Action = r.Action,
                    Debit = debit,
                    Credit = credit,
                    Running = running,
                    RunningType = running > 0 ? "مدين" : running < 0 ? "دائن" : "صفر",
                    Client = r.Client,
                    Note = r.Note,
                });
            }

            return result;
        }

        // ════════════════════════════════════════════════════════════
        // BindGrid — الأعمدة والـ Footer تُضبط مرة واحدة فقط
        // ════════════════════════════════════════════════════════════
        private void BindGrid(List<LedgerRow> rows)
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = rows;

            if (_gridReady) return;
            if (gridView1.Columns.Count == 0) return;
            _gridReady = true;

            SetCol("RowNum", "ت", 55, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Wasel", "الوصل", 75, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Date", "التاريخ", 250, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Action", "الحركة", 95, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Debit", "مدين", 110, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Credit", "دائن", 110, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Running", "الرصيد", 250, DevExpress.Utils.HorzAlignment.Center);
            SetCol("RunningType", "حالته", 70, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Client", "العميل", 300, DevExpress.Utils.HorzAlignment.Far);
            SetCol("Note", "الملاحظات", 400, DevExpress.Utils.HorzAlignment.Far);

            gridView1.Columns["Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Date"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";

            foreach (string f in new[] { "Debit", "Credit", "Running" })
            {
                gridView1.Columns[f].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns[f].DisplayFormat.FormatString = "N2";
            }

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

        // ════════════════════════════════════════════════════════════
        // UpdateTotals
        // ════════════════════════════════════════════════════════════
        private void UpdateTotals(List<LedgerRow> rows)
        {
            decimal totalDebit = rows.Sum(r => r.Debit);
            decimal totalCredit = rows.Sum(r => r.Credit);
            decimal net = totalDebit - totalCredit;

            Lbl_total_debit.Text = $"إجمالي المبيعات: {totalDebit:N2} $";
            Lbl_total_credit.Text = $"إجمالي المدفوعات: {totalCredit:N2} $";
            Lbl_net.Text = $"صافي الدين: {net:N2} $";
            Lbl_net.ForeColor = net > 0 ? Color.DarkRed :
                                    net < 0 ? Color.DarkGreen : Color.Black;
        }

        // ════════════════════════════════════════════════════════════
        // تصدير Excel
        // ════════════════════════════════════════════════════════════
        private void Btn_xls_Click(object sender, EventArgs e)
        {
            if (_rows == null || !_rows.Any())
            {
                XtraMessageBox.Show("لا توجد بيانات للتصدير");
                return;
            }
            try
            {
                OfficeOpenXml.ExcelPackage.LicenseContext =
                    OfficeOpenXml.LicenseContext.NonCommercial;

                using (var dlg = new SaveFileDialog
                {
                    FileName = $"كشف_الدائن_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx",
                    Filter = "Excel|*.xlsx",
                    Title = "حفظ كملف Excel"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    using (var pkg = new OfficeOpenXml.ExcelPackage(
                                         new System.IO.FileInfo(dlg.FileName)))
                    {
                        var ws = pkg.Workbook.Worksheets.Add("كشف الدائن");
                        string[] hdrs = { "ت","الوصل","التاريخ","الحركة",
                                          "مدين","دائن","الرصيد","حالته","العميل" };

                        for (int c = 0; c < hdrs.Length; c++)
                        {
                            ws.Cells[1, c + 1].Value = hdrs[c];
                            ws.Cells[1, c + 1].Style.Fill.PatternType =
                                OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[1, c + 1].Style.Fill.BackgroundColor.SetColor(Color.SteelBlue);
                            ws.Cells[1, c + 1].Style.Font.Color.SetColor(Color.White);
                            ws.Cells[1, c + 1].Style.Font.Bold = true;
                        }

                        int row = 2;
                        foreach (var r in _rows)
                        {
                            ws.Cells[row, 1].Value = r.RowNum;
                            ws.Cells[row, 2].Value = r.Wasel;
                            ws.Cells[row, 3].Value = r.Date?.ToString("dd/MM/yyyy HH:mm");
                            ws.Cells[row, 4].Value = r.Action;
                            ws.Cells[row, 5].Value = r.Debit;
                            ws.Cells[row, 6].Value = r.Credit;
                            ws.Cells[row, 7].Value = r.Running;
                            ws.Cells[row, 8].Value = r.RunningType;
                            ws.Cells[row, 9].Value = r.Client;
                            ws.Cells[row, 10].Value = r.Note;

                            Color rowColor = r.Debit > 0
                                ? Color.FromArgb(255, 235, 235)
                                : Color.FromArgb(235, 255, 235);
                            ws.Cells[row, 1, row, 9].Style.Fill.PatternType =
                                OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, 1, row, 9].Style.Fill.BackgroundColor.SetColor(rowColor);
                            row++;
                        }

                        decimal td = _rows.Sum(r => r.Debit);
                        decimal tc = _rows.Sum(r => r.Credit);
                        ws.Cells[row, 4].Value = "إجمالي المبيعات:";
                        ws.Cells[row, 5].Value = td;
                        ws.Cells[row + 1, 4].Value = "إجمالي المدفوعات:";
                        ws.Cells[row + 1, 6].Value = tc;
                        ws.Cells[row + 2, 4].Value = "صافي الدين:";
                        ws.Cells[row + 2, 5].Value = td - tc;

                        ws.Cells.AutoFitColumns();
                        pkg.Save();
                    }

                    XtraMessageBox.Show("✅ تم التصدير بنجاح");
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(dlg.FileName)
                        { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في التصدير:\n" + ex.Message);
            }
        }

        // ════════════════════════════════════════════════════════════
        // طباعة
        // ════════════════════════════════════════════════════════════
        private void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                var ps = new DevExpress.XtraPrinting.PrintingSystem();
                var link = new DevExpress.XtraPrinting.PrintableComponentLink(ps)
                {
                    Component = gridControl1,
                    Landscape = true,
                    Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10)
                };
                link.CreateDocument();

                var preview = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
                {
                    PrintingSystem = ps
                };
                preview.PrintingSystem.PageSettings.Landscape = true;
                preview.PrintingSystem.PageSettings.PaperKind =
                    (DevExpress.Drawing.Printing.DXPaperKind)
                    System.Drawing.Printing.PaperKind.A4;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في الطباعة:\n" + ex.Message);
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }


   

    public class LedgerRow
    {
        public int RowNum { get; set; }   // الرقم التسلسلي
        public int? Wasel { get; set; }   // رقم الوصل
        public System.DateTime? Date { get; set; }   // التاريخ
        public string Action { get; set; }   // بيع / دفع فوري / تسديد
        public decimal Debit { get; set; }   // مدين  (المبيعات)
        public decimal Credit { get; set; }   // دائن  (المدفوعات)
        public decimal Running { get; set; }   // الرصيد التراكمي
        public string RunningType { get; set; }   // مدين / دائن / صفر
        public string Client { get; set; }
        public string Note { get; set; } // اسم العميل
    }
}