using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietQRLib;

namespace BIDVQR
{
    public partial class MainForm : Form
    {
        private string tempfolder;
        private string qrfolder;
        private string pdffolder;
        private string temp_template_excel;
       
        public static void OpenExplorer(string dir)
        {
            var result = MessageBox.Show($"Xuất Bc thành công \n File Lưu tại {dir} \n Bạn Có muốn mở file", @"OpenFile", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = dir,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var timestamp = DateTime.Now.ToFileTime();
            FileInfo fi = new FileInfo(@"template.xlsx");
            temp_template_excel = string.Format("{0}\\template_{1}.xlsx", tempfolder, timestamp);
            fi.CopyTo(temp_template_excel, true);
            Process process = new Process();
            process.StartInfo.FileName = temp_template_excel;
            process.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tempfolder = System.AppDomain.CurrentDomain.BaseDirectory + "temp";

            qrfolder = System.AppDomain.CurrentDomain.BaseDirectory + "QRcode";

            pdffolder = System.AppDomain.CurrentDomain.BaseDirectory + "Pdf";

            // If directory doesn't exist create one
            if (!Directory.Exists(tempfolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(tempfolder);
            }

            if (!Directory.Exists(qrfolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(qrfolder);
            }
            if (!Directory.Exists(pdffolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(pdffolder);
            }
        }

        private void bt_taoma_Click(object sender, EventArgs e)
        {
            bt_taoma.Enabled = false;
            string sotk = tb_sotk.Text.Replace("-", "").Trim();
            if (sotk.Length == 0)
            {
                MessageBox.Show("Chưa nhập số tk");
            }
            else
            {
                var vietqr = Generator.Generator_VietQR("BIDV", sotk);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(100, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));

               
                pictureBox1.Image = qrCodeImage;
                var imagePath = qrfolder + '\\' + sotk + ".png";

                //svgDoc.Write(vietqrfolder + '\\' + sotk + ".svg");         

                qrCodeImage.Save(imagePath, ImageFormat.Png);

                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
                var filepdf = pdffolder + '\\' + tb_tenchutk.Text.ToUpper() + "-" + sotk + ".pdf";
                PdfWriter writer = new PdfWriter(filepdf);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);

                pdfDoc.AddFont(pdfFont);
                PdfPage page = pdfDoc.GetFirstPage();
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("qrcode").SetValue(imageStr);
                formc.GetField("sotk").SetValue("Số TK: " + sotk, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: " + tb_tenchutk.Text.ToUpper(), pdfFont, 14);
                formc.FlattenFields();

                pdfDoc.Close();
                writer.Close();

                OpenExplorer(filepdf);
                bt_taoma.Enabled = true;
            }
        }
    }
}
