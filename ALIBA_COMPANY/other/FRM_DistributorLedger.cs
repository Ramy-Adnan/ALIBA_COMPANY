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
    public partial class FRM_DistributorLedger : XtraForm
    {
        private List<DistributorLedgerRow> _allRows = new List<DistributorLedgerRow>();

        public FRM_DistributorLedger()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void FRM_DistributorLedger_Load(object sender, EventArgs e)
        {
            Dt_from.Value = new DateTime(DateTime.Now.Year, 1, 1);
            Dt_to.Value = DateTime.Now;
            LoadDistributors();
        }

        private void LoadDistributors()
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
                    Combo_distributor.DataSource = list;
                    Combo_distributor.SelectedIndex = 0;
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

        private void Btn_search_Click(object sender, EventArgs e) => Search();

        private void Combo_distributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            Search();
        }

        private void Txt_search_cust_TextChanged(object sender, EventArgs e)
        {
            FilterClientList(Txt_search_cust.Text.Trim());
        }

        private void FilterClientList(string keyword)
        {
            if (_allRows == null || !_allRows.Any()) return;

            var clients = _allRows
                .Select(r => r.Client)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            if (!string.IsNullOrEmpty(keyword))
                clients = clients.Where(c => c.Contains(keyword)).ToList();

            Lst_cust.SelectedIndexChanged -= Lst_cust_SelectedIndexChanged;
            Lst_cust.Items.Clear();
            Lst_cust.Items.Add("كل العملاء");
            foreach (var c in clients)
                Lst_cust.Items.Add(c);
            Lst_cust.SelectedIndex = 0;
            Lst_cust.SelectedIndexChanged += Lst_cust_SelectedIndexChanged;

            ApplyClientFilter();
        }

        private void Lst_cust_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyClientFilter();
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            ApplyClientFilter();
        }

        // ════════════════════════════════════════════════════════════
        // ClearAll — تصفير فوري للواجهة كاملةً
        // يُضمن أن الجريد وقائمة العملاء والإجماليات تكون فارغة
        // فوراً عند تغيير الموزع، حتى لو لم يكن له أي بيانات
        // ════════════════════════════════════════════════════════════
        private void ClearAll()
        {
            _allRows = new List<DistributorLedgerRow>();

            gridControl1.DataSource = null;

            // تفريغ قائمة العملاء
            Lst_cust.SelectedIndexChanged -= Lst_cust_SelectedIndexChanged;
            Lst_cust.Items.Clear();
            Lst_cust.Items.Add("كل العملاء");
            Lst_cust.SelectedIndex = 0;
            Lst_cust.SelectedIndexChanged += Lst_cust_SelectedIndexChanged;

            // تصفير الإجماليات
            UpdateTotals(_allRows);
        }

        // ════════════════════════════════════════════════════════════
        // Search
        // ════════════════════════════════════════════════════════════
        private async void Search()
        {
            try
            {
                // ── أول شيء: تصفير فوري قبل أي await ──────────────
                ClearAll();

                loading.Visible = true;
                Btn_search.Enabled = false;

                string distributor = Combo_distributor.SelectedItem?.ToString();
                DateTime dtFrom = Dt_from.Value.Date;
                DateTime dtTo = Dt_to.Value.Date.AddDays(1).AddSeconds(-1);

                if (string.IsNullOrEmpty(distributor))
                {
                    XtraMessageBox.Show("الرجاء اختيار موزع");
                    return;
                }

                var rows = await Task.Run(() => FetchLedger(distributor, dtFrom, dtTo));
                _allRows = rows;

                FillClientList(rows);
                ApplyClientFilter();
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

        private void FillClientList(List<DistributorLedgerRow> rows)
        {
            var clients = rows
                .Select(r => r.Client)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            Lst_cust.SelectedIndexChanged -= Lst_cust_SelectedIndexChanged;
            Lst_cust.Items.Clear();
            Lst_cust.Items.Add("كل العملاء");
            foreach (var c in clients)
                Lst_cust.Items.Add(c);
            Lst_cust.SelectedIndex = 0;
            Lst_cust.SelectedIndexChanged += Lst_cust_SelectedIndexChanged;
        }

        private void ApplyClientFilter()
        {
            if (_allRows == null || !_allRows.Any())
            {
                gridControl1.DataSource = null;
                UpdateTotals(new List<DistributorLedgerRow>());
                return;
            }

            string selectedClient = Lst_cust.SelectedItem?.ToString();
            bool showDebit = Chk_debit.Checked;
            bool showCredit = Chk_credit.Checked;

            var filtered = (selectedClient == "كل العملاء" || string.IsNullOrEmpty(selectedClient))
                ? _allRows.ToList()
                : _allRows.Where(r => r.Client == selectedClient).ToList();

            if (!showDebit)
                filtered = filtered.Where(r => r.Debit == 0).ToList();
            if (!showCredit)
                filtered = filtered.Where(r => r.Credit == 0).ToList();

            int seq = 1;
            filtered.ForEach(r => r.RowNum = seq++);

            BindGrid(filtered);
            UpdateTotals(filtered);
        }

        private List<DistributorLedgerRow> FetchLedger(
            string distributor, DateTime from, DateTime to)
        {
            var raw = new List<(DateTime Date, int? Code, string Action,
                                decimal Amount, bool IsDebit,
                                string Client, string Distributor, string Note)>();

            using (var db = new AlibaRamyEntities())
            {
                var salesQ = db.TB_list
                    .Where(l => l.cust_id != null && l.cust_id != 0)
                    .Where(l => l.list_date >= from && l.list_date <= to)
                    .Where(l => l.list_cridetUsd > 0);

                if (distributor != "كل الموزعيين")
                    salesQ = salesQ.Where(l => l.TB_emplo.emplo_name == distributor);

                foreach (var s in salesQ.Select(l => new
                {
                    Date = l.list_date,
                    Code = l.list_code,
                    Amount = l.list_cridetUsd ?? 0m,
                    Client = l.list_name,
                    Dist = l.TB_emplo.emplo_name,
                    Note =l.list_nots
                }).ToList())
                {
                    raw.Add((s.Date ?? DateTime.MinValue, s.Code,
                             "بيع", s.Amount, true,
                             s.Client ?? "", s.Dist ?? "", s.Note ?? ""));
                }

                var cridetQ = db.TB_cridet
                    .Where(c => c.action_id == 6 || c.action_id == 7)
                    .Where(c => c.cridet_date >= from && c.cridet_date <= to)
                    .Where(c => c.cridet_s > 0);

                if (distributor != "كل الموزعيين")
                    cridetQ = cridetQ.Where(c => c.TB_emplo.emplo_name == distributor);

                foreach (var p in cridetQ.Select(c => new
                {
                    Date = c.cridet_date,
                    Code = c.cridet_code,
                    Amount = c.cridet_s ?? 0m,
                    Client = c.list_name,
                    ActionId = c.action_id,
                    Dist = c.TB_emplo.emplo_name,
                    Note = c.cridet_nots
                }).ToList())
                {
                   string act = p.ActionId == 6 ? "قبض نقدي" : p.ActionId == 7 ? "قبض اجل" : p.ActionId == 8 ? "صرف نقدي" : p.ActionId == 9 ? "صرف اجل" : "دفع فوري";

                   

                    raw.Add((p.Date ?? DateTime.MinValue, p.Code,
                             act, p.Amount, false,
                             p.Client ?? "", p.Dist ?? "", p.Note ?? ""));
                }
            }

            raw = raw.OrderBy(r => r.Date).ThenBy(r => r.Code).ToList();

            var result = new List<DistributorLedgerRow>();
            var byClient = raw.GroupBy(r => r.Client);
            int seq = 1;

            foreach (var grp in byClient)
            {
                decimal running = 0;
                foreach (var r in grp.OrderBy(x => x.Date))
                {
                    decimal debit = 0, credit = 0;
                    if (r.IsDebit) { debit = r.Amount; running += r.Amount; }
                    else { credit = r.Amount; running -= r.Amount; }

                    result.Add(new DistributorLedgerRow
                    {
                        RowNum = seq++,
                        Wasel = r.Code,
                        Date = r.Date == DateTime.MinValue ? (DateTime?)null : r.Date,
                        Action = r.Action,
                        Debit = debit,
                        Credit = credit,
                        Amount = debit > 0 ? debit : credit,
                        Running = Math.Abs(running),
                        RunningType = running > 0 ? "مدين" : running < 0 ? "دائن" : "صفر",
                        Client = r.Client,
                        Distributor = r.Distributor,
                        Note = r.Note,
                    });
                }
            }

            result = result.OrderBy(r => r.Date).ThenBy(r => r.Wasel).ToList();
            seq = 1;
            result.ForEach(r => r.RowNum = seq++);

            return result;
        }

        private void BindGrid(List<DistributorLedgerRow> rows)
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = rows;

            if (gridView1.Columns.Count == 0) return;

            // إخفاء الكل أولاً ثم إظهار المطلوب — يعمل في كل مرة
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                col.Visible = false;

            SetCol("RowNum", "ت", 55, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Wasel", "الوصل", 85, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Date", "التاريخ", 250, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Action", "الحركة", 110, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Amount", "المبلغ", 160, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Running", "الرصيد", 180, DevExpress.Utils.HorzAlignment.Center);
            SetCol("RunningType", "حالته", 75, DevExpress.Utils.HorzAlignment.Center);
            SetCol("Client", "العميل", 250, DevExpress.Utils.HorzAlignment.Far);
            SetCol("Distributor", "الموزع", 250, DevExpress.Utils.HorzAlignment.Far);
            SetCol("Note", "ملاحظات", 400, DevExpress.Utils.HorzAlignment.Far);

            gridView1.Columns["Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Date"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";

            foreach (string f in new[] { "Amount", "Running" })
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

        private void UpdateTotals(List<DistributorLedgerRow> rows)
        {
            decimal totalDebit = rows.Sum(r => r.Debit);
            decimal totalCredit = rows.Sum(r => r.Credit);
            decimal net = totalDebit - totalCredit;

            Lbl_total_debit.Text = $"إجمالي المبيعات: $ {totalDebit:N2}";
            Lbl_total_credit.Text = $"إجمالي المدفوعات: $ {totalCredit:N2}";
            Lbl_net.Text = $"صافي الدين: $ {net:N2}";
            Lbl_net.ForeColor = net > 0 ? Color.DarkRed :
                                     net < 0 ? Color.DarkGreen : Color.Black;
        }

        private void Btn_xls_Click(object sender, EventArgs e)
        {
            var displayed = gridControl1.DataSource as List<DistributorLedgerRow>;
            if (displayed == null || !displayed.Any())
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
                    FileName = $"كشف_الموزع_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx",
                    Filter = "Excel|*.xlsx",
                    Title = "حفظ كملف Excel"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    using (var pkg = new OfficeOpenXml.ExcelPackage(
                               new System.IO.FileInfo(dlg.FileName)))
                    {
                        var ws = pkg.Workbook.Worksheets.Add("كشف الموزع");
                        string[] hdrs = { "ت","الوصل","التاريخ","الحركة",
                                          "المبلغ","الرصيد","حالته","العميل","الموزع","ملاحظات" };

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
                        foreach (var r in displayed)
                        {
                            ws.Cells[row, 1].Value = r.RowNum;
                            ws.Cells[row, 2].Value = r.Wasel;
                            ws.Cells[row, 3].Value = r.Date?.ToString("dd/MM/yyyy");
                            ws.Cells[row, 4].Value = r.Action;
                            ws.Cells[row, 5].Value = r.Amount;
                            ws.Cells[row, 6].Value = r.Running;
                            ws.Cells[row, 7].Value = r.RunningType;
                            ws.Cells[row, 8].Value = r.Client;
                            ws.Cells[row, 9].Value = r.Distributor;
                            ws.Cells[row, 10].Value = r.Note;

                            Color rowColor = r.Debit > 0
                                ? Color.FromArgb(255, 235, 235)
                                : Color.FromArgb(235, 255, 235);
                            ws.Cells[row, 1, row, 10].Style.Fill.PatternType =
                                OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, 1, row, 9].Style.Fill.BackgroundColor.SetColor(rowColor);
                            row++;
                        }

                        decimal td = displayed.Sum(r => r.Debit);
                        decimal tc = displayed.Sum(r => r.Credit);
                        ws.Cells[row, 4].Value = "إجمالي المبيعات:";
                        ws.Cells[row, 5].Value = td;
                        ws.Cells[row + 1, 4].Value = "إجمالي المدفوعات:";
                        ws.Cells[row + 1, 5].Value = tc;
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
    }

    // ══════════════════════════════════════════════════════════════════
    //  DistributorLedgerRow
    // ══════════════════════════════════════════════════════════════════
    public class DistributorLedgerRow
    {
        public int RowNum { get; set; }
        public int? Wasel { get; set; }
        public DateTime? Date { get; set; }
        public string Action { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Amount { get; set; }
        public decimal Running { get; set; }
        public string RunningType { get; set; }
        public string Client { get; set; }
        public string Distributor { get; set; }
        public string Note { get; set; }   // ملاحظات من TB_list
    }
}