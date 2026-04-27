using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using Bunifu.UI.WinForms;

namespace ALIBA_COMPANY
{
    public class ImageSlider
    {
        private Panel panel; // لعرض الصورة في هذا الـ Panel
        private Button btnPrevious; // زر للانتقال إلى الصورة السابقة
        private Button btnNext;     // زر للانتقال إلى الصورة التالية
        private int currentIndex = 0; // مؤشر الصورة الحالية
        private Image[] images; // مصفوفة الصور المحملة
        private Panel panelImageDisplay;
        private BunifuImageButton btnPrevious1;
        private BunifuImageButton btnNext1;

        public ImageSlider(Panel panel, Button btnPrevious, Button btnNext)
        {
            this.panel = panel;
            this.btnPrevious = btnPrevious;
            this.btnNext = btnNext;
        }

        public ImageSlider(Panel panelImageDisplay, BunifuImageButton btnPrevious1, BunifuImageButton btnNext1)
        {
            this.panelImageDisplay = panelImageDisplay;
            this.btnPrevious1 = btnPrevious1;
            this.btnNext1 = btnNext1;
        }

        public async void LoadImages(string[] imageUrls)
        {
            if (IsInternetAvailable())
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // تحميل الصور إلى المصفوفة
                        images = new Image[imageUrls.Length];

                        for (int i = 0; i < imageUrls.Length; i++)
                        {
                            byte[] imageBytes = await client.GetByteArrayAsync(imageUrls[i]);

                            using (var ms = new MemoryStream(imageBytes))
                            {
                                images[i] = Image.FromStream(ms);
                            }
                        }

                        // بعد تحميل الصور، يتم عرض أول صورة
                        DisplayImage();

                        // إعداد الوظائف لأزرار التنقل
                        btnPrevious.Click += BtnPrevious_Click;
                        btnNext.Click += BtnNext_Click;
                    }
                    catch (Exception)
                    {
                        // لا نعرض أي رسالة خطأ هنا إذا فشل التحميل
                    }
                }
            }
            else
            {
                // لا نقوم بأي شيء إذا لم يكن هناك اتصال بالإنترنت
            }
        }

        private bool IsInternetAvailable()
        {
            // التحقق من وجود اتصال بالإنترنت
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            // الانتقال إلى الصورة السابقة
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayImage();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            // الانتقال إلى الصورة التالية
            if (currentIndex < images.Length - 1)
            {
                currentIndex++;
                DisplayImage();
            }
        }

        private void DisplayImage()
        {
            if (images != null && images.Length > 0)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = images[currentIndex],
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };

                // مسح الـ Panel وإضافة الصورة الجديدة
                panel.Controls.Clear();
                panel.Controls.Add(pictureBox);
            }
        }
    }
}
