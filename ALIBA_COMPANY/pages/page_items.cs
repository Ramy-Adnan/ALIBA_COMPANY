using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALIBA_COMPANY.AddPage;
using System.IO;
using ALIBA_COMPANY.classes;
using System.Data.Entity;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ALIBA_COMPANY.pages
{
    public partial class page_items : DevExpress.XtraEditors.XtraUserControl
    {
        AlibaRamyEntities db;
        int Buyid;
        Note note;
        public page_items()
        {
            InitializeComponent();
            Role();
            UpdateSuggestions();
        }
        private void empity()
        {
            if (string.IsNullOrEmpty(ser_item.Text.Trim()))
            {
                listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
                listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                ClearResults();
            }
        }
        private void Role()
        {
            if (AddPage.Users.userRole == "مسؤول الموزعيين"||AddPage.Users.userRole == "موزع"|| AddPage.Users.userRole == "امين مخزن"|| AddPage.Users.userRole == "اداري")
            {
                Btn_new.Visible = false;
                Btn_edit.Visible = false;
                Btn_exel.Visible = false;
            }
        }
        private void ser_item_TextChanged(object sender, EventArgs e)
        {

            UpdateSuggestions(); // تحديث الاقتراحات
            empity();


        }

        private void UpdateSuggestions()
        {
            try
            {
                string inputText = ser_item.Text; // التأكد من عدم وجود فراغات في النص

                using (db = new AlibaRamyEntities())
                {
                    
                    // استعلام LINQ للحصول على الاقتراحات مع البحث بالاسم العربي والاسم الإنجليزي
                    var suggestions = db.TB_items
                        .Where(x => x.items_name.Contains(inputText) || x.items_code.Contains(inputText) || x.items_enname.Contains(inputText))
                        .Select(x => x.items_name)
                        .ToList();


                    // تحديث عناصر الليست بوكس بالاقتراحات المطابقة
                    listbox_suggestions.DataSource = suggestions;
                    if (suggestions.Count > 0)
                    {
                        listbox_suggestions.Visible = true;// جعل الليست بوكس مرئيًا إذا كانت هناك اقتراحات
                    }

                    else
                    {
                        listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
                        listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                        listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                        ClearResults();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null) // تحقق مما إذا كانت القيمة مخصصة
            {
                // عرض العنصر المحدد من الليست بوكس في التيكست بوكس
                // ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();

            }
        }

        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listbox_suggestions.SelectedItem != null) // تحقق مما إذا كانت القيمة مخصصة
            {
                // عند الضغط على Enter، اختر العنصر المحدد وجلب البيانات
                ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();
            }
        }

        private void GetMaterialsData()
        {
            try
            {

                string itemName = listbox_suggestions.SelectedItem.ToString().Trim(); // التأكد من عدم وجود فراغات في النص
                if (!string.IsNullOrEmpty(itemName))
                {
                    using (db = new AlibaRamyEntities())
                    {

                        TB_items buy = db.TB_items.FirstOrDefault(x => x.items_name == itemName);

                        if (buy != null)
                        {
                            Buyid = buy.items_id;

                            Txt_nameAR.Text = buy.items_name;
                            Txt_nameEn.Text = buy.items_enname;
                           
                            Txt_parcode.Text = buy.items_code;

                            Txt_form.Text = buy.items_form;
                            Txt_quart.Text = buy.items_quart.ToString();
                            Txt_info.Text = buy.items_nots;
                            Txt_UpriceUs.Text = buy.Usd_upper.ToString();
                            Txt_LpriceUs.Text = buy.Usd_lower.ToString();
                            Txt_exchang.Text = buy.exchang.ToString();
                            Txt_UpriceIQ.Text = buy.IQD_upper.ToString();
                            Txt_LpriceIQ.Text = buy.IQD_lower.ToString();

                            // تحميل الصورة من المسار المحفوظ في الجدول
                            string imagePath = buy.items_pic;
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureEdit1.Image = Image.FromFile(imagePath);
                            }
                            else
                            {
                                // إعادة تعيين الصورة في حال عدم وجود مسار صحيح للصورة
                                pictureEdit1.Image = Properties.Resources.aliba;
                            }

                            TB_groups buy2 = db.TB_groups.FirstOrDefault(m => m.groups_id == buy.groups_id);
                            Txt_gat.Text = buy2.groups_name;

                        }
                    }
                }
                else
                {
                    ClearResults();
                    MessageBox.Show("اسم المادة العربي محذوف \n لذلك لا يمكنني عرضها لك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("لم يتم جلب البيانات حدث غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearResults()
        {
          
            Txt_nameAR.Text = string.Empty;
            Txt_nameEn.Text = string.Empty;
          
            Txt_parcode.Text = string.Empty;
            Txt_gat.Text = string.Empty;
            Txt_form.Text = string.Empty;
            Txt_quart.Text = string.Empty;
            Txt_info.Text = string.Empty;
            Txt_UpriceUs.Text = string.Empty;
            Txt_LpriceUs.Text = string.Empty;
            Txt_exchang.Text = string.Empty;
            Txt_UpriceIQ.Text = string.Empty;
            Txt_LpriceIQ.Text = string.Empty;
            pictureEdit1.Image = null;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            if (listbox_suggestions.SelectedItem != null&& !string.IsNullOrEmpty(Txt_nameAR.Text))
            {

                string selectedItem = listbox_suggestions.SelectedItem.ToString();
                FRM_Additems AddForm = new FRM_Additems(Buyid); //تمرير المفتاح الرئيسي
                AddForm.btn_add.Visible = false;
             
                FRM_Additems.addoredit_combo = 2;

                // تعيين حدث FormClosed
                AddForm.FormClosed += (s, args) =>
                {
                    if (AddForm.DialogResult == DialogResult.OK)
                    {
                        ser_item.Text = FRM_Additems.addoredit; // تحديث البيانات في الفورم الأول بعد الإضافة
                        GetMaterialsData();
                    }
                };

                AddForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد مادة للتعديل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            // إنشاء نافذة FRM_Additems لإضافة عنصر جديد بدون تحديد عنصر محدد
            FRM_Additems AddForm = new FRM_Additems();
            AddForm.btn_edit.Visible = false;
            FRM_Additems.addoredit_combo = 1;

            // تعيين حدث FormClosed
            AddForm.FormClosed += (s, args) =>
            {
                if (AddForm.DialogResult == DialogResult.OK)
                {
                    ser_item.Text = FRM_Additems.addoredit; // تحديث البيانات في الفورم الأول بعد الإضافة
                }
            };

            AddForm.ShowDialog();
        }
        private List<Items> ItemsDetails;
        private async Task LoadDetailsAsync()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                ItemsDetails = await Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var data = db.TB_items
                           .Where(x => x.items_activity == true).AsNoTracking()
                           .Select(x => new Items
                           {
                               Name = x.items_name,
                               Code = x.items_code,
                               NameEn = x.items_enname,
                               Form = x.items_form,
                               Quart = (byte)x.items_quart,
                               Group = x.TB_groups.groups_name,
                               UpriceU = x.Usd_upper,
                               LpriceU = x.Usd_lower,
                               Ex = x.exchang,
                               UpriceI = x.IQD_upper,
                               LpriceI = x.IQD_lower,
                               Note = x.items_nots,
                           })
                           .ToList();

                        return data;
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }
        private async void Btn_exel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                if (AddPage.Users.userRole == "مدير" || AddPage.Users.userRole == "مدير حسابات" || AddPage.Users.userRole == "حسابات")
                {

                    await LoadDetailsAsync();


                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"المواد {DateTime.Now:yyyy-MM-dd}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);

                        using (var package = new ExcelPackage(fileInfo))
                        {
                            var worksheet = package.Workbook.Worksheets.Add("المواد");


                            worksheet.Cells[1, 1].Value = "اسم المادة";
                            worksheet.Cells[1, 2].Value = "الكود";
                            worksheet.Cells[1, 3].Value = "الاسم التجاري";
                            worksheet.Cells[1, 4].Value = "التجزئة";
                            worksheet.Cells[1, 5].Value = "عدد التجزئة";
                            worksheet.Cells[1, 6].Value = "الصنف";
                            worksheet.Cells[1, 7].Value = "اعلى سعر دولار";
                            worksheet.Cells[1, 8].Value = "اقل سعر دولار";
                            worksheet.Cells[1, 9].Value = "اعلى سعر عراقي";
                            worksheet.Cells[1, 10].Value = "اقل سعر عراقي";
                            worksheet.Cells[1, 11].Value = "التصريف بعد التقريب";
                            worksheet.Cells[1, 12].Value = "الملاحظات";


                            using (var headerRange = worksheet.Cells[1, 1, 1, 12])
                            {
                                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                headerRange.Style.Font.Bold = true;
                            }


                            for (int i = 0; i < ItemsDetails.Count; i++)
                            {
                                worksheet.Cells[i + 2, 1].Value = ItemsDetails[i].Name;
                                worksheet.Cells[i + 2, 2].Value = ItemsDetails[i].Code;
                                worksheet.Cells[i + 2, 3].Value = ItemsDetails[i].NameEn;
                                worksheet.Cells[i + 2, 4].Value = ItemsDetails[i].Form;
                                worksheet.Cells[i + 2, 5].Value = ItemsDetails[i].Quart;
                                worksheet.Cells[i + 2, 6].Value = ItemsDetails[i].Group;
                                worksheet.Cells[i + 2, 7].Value = ItemsDetails[i].UpriceU;
                                worksheet.Cells[i + 2, 8].Value = ItemsDetails[i].LpriceU;
                                worksheet.Cells[i + 2, 9].Value = ItemsDetails[i].UpriceI;
                                worksheet.Cells[i + 2, 10].Value = ItemsDetails[i].LpriceI;
                                worksheet.Cells[i + 2, 11].Value = ItemsDetails[i].Ex;
                                worksheet.Cells[i + 2, 12].Value = ItemsDetails[i].Note;
                            }


                            using (var allCells = worksheet.Cells[1, 1, ItemsDetails.Count + 1, 12])
                            {
                                allCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Font.Size = 14;
                                allCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                            package.Save();
                            MessageBox.Show("تم التصدير بنجاح");

                            note = new Note();
                            pages.Notifications notifications = new pages.Notifications();
                            var Note = " تصدير المواد";
                            note.AddNote(Note, notifications, "تصدير", 7);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ليس من صلاحيتك");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات: " + ex.Message);
            }
        }
    }
}







