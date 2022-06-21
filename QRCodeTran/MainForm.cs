using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout;
using QRCoder;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRNapasLib;

namespace QRCodeTran
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bt_taoma_Click(object sender, EventArgs e)
        {
            string sotk = tb_sotk.Text.Replace("-", "").Trim();
            if (sotk.Length == 0)
            {
                MessageBox.Show("Chưa nhập số tk");

            }
            else
            {
              

                var vietqr = Generator.Generator_VietQR("BIDV", sotk, 15260000,"thanh toan tien hang" ); 


                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);

                //SvgQRCode qrCodesvg = new SvgQRCode(qrCodeData);
                //string qrCodeAsSvg = qrCodesvg.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White);
                //string fileName = @"qr.svg";
                //StreamWriter writer = new StreamWriter(fileName);
                //writer.Write(qrCodeAsSvg);
                //writer.Close();

                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));
                var imagePath = "qrcode.png";

                qrCodeImage.Save(imagePath, ImageFormat.Png);

                var svgDoc = SvgDocument.Open("BIDVQR.svg"); 
                

                var g = svgDoc.GetElementById("qrcode") as SvgImage;
                g.Href = "data:image/png;base64," + ImageToBase64(qrCodeImage, ImageFormat.Png);

                var asotk = svgDoc.GetElementById("sotk") as SvgText;
                asotk.Text = "Số TK: " + sotk;

                var hotentk = svgDoc.GetElementById("hotentk") as SvgText;
                hotentk.Text = "Tên TK: " + tb_tenchutk.Text.ToUpper();
                svgDoc.Write("result.svg");

              //  pictureBox1.Image = qrCode.GetGraphic(20);

                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
                var filepdf ="test.pdf";

                PdfWriter writer = new PdfWriter(filepdf);
                iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);
                pdfDoc.AddFont(pdfFont);
              
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("qrcode").SetValue(imageStr);
                formc.GetField("sotk").SetValue("Số TK: " + sotk, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: " + tb_tenchutk.Text.ToUpper(), pdfFont, 14);
                formc.FlattenFields();
                
                pdfDoc.Close(); 
                writer.Close();

                Stream pdf =   new FileStream(filepdf, FileMode.Open, FileAccess.Read);
                byte[] png = Freeware.Pdf2Png.Convert(pdf, 1);


                MemoryStream ms = new MemoryStream(png, 0, png.Length);
                ms.Write(png, 0, png.Length);
                pictureBox1.Image = Image.FromStream(ms, true);//Exception occurs here



               
              

               
                ////30,66,126
                //pictureBox1.Image = qrCodeImage;

            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public byte[] Combine(IEnumerable<byte[]> pdfs)
        {
            using (var writerMemoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(writerMemoryStream))
                {
                    using (var mergedDocument = new PdfDocument(writer))
                    {
                        var merger = new PdfMerger(mergedDocument);

                        foreach (var pdfBytes in pdfs)
                        {
                            using (var copyFromMemoryStream = new MemoryStream(pdfBytes))
                            {
                                using (var reader = new PdfReader(copyFromMemoryStream))
                                {
                                    using (var copyFromDocument = new PdfDocument(reader))
                                    {
                                        merger.Merge(copyFromDocument, 1, copyFromDocument.GetNumberOfPages());
                                    }
                                }
                            }
                        }
                    }
                }

                return writerMemoryStream.ToArray();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            List<byte[]> asd = new  List<byte[]>();

            //byte[] png = Freeware.Pdf2Png.Convert(pdfDoc, 1);



            //MemoryStream ms = new MemoryStream(png, 0, png.Length);
            //ms.Write(png, 0, png.Length);
            //pictureBox1.Image = Image.FromStream(ms, true);//Exception occurs here
            for (var i = 1; i <= 10; i++)
            {
                var imagePath = "qrcode.png";
                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
                MemoryStream baos = new MemoryStream();
                PdfWriter writer = new PdfWriter(baos);
                iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);
                pdfDoc.AddFont(pdfFont);
                PdfPage page = pdfDoc.GetFirstPage();
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("qrcode").SetValue(imageStr);
                formc.GetField("sotk").SetValue("Số TK: " + i, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: ", pdfFont, 14);
                formc.FlattenFields();
                pdfDoc.Close();
                writer.Close();
                byte[] png = Freeware.Pdf2Png.Convert(baos.ToArray(), 1);
                File.WriteAllBytes(i + "aaa.png", png);
                asd.Add(baos.ToArray());
            }
           
            File.WriteAllBytes(@"iTextQuoteM.pdf",Combine(asd));

        }
    }
}
