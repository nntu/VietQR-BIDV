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
using VietQRLib;

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
              

                var vietqr = Generator.Generator_VietQR("BIDV", sotk ); 


                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);

                SvgQRCode qrCodesvg = new SvgQRCode(qrCodeData);
                string qrCodeAsSvg = qrCodesvg.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White);
                string fileName = @"qr.svg";
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(qrCodeAsSvg);
                writer.Close();

                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));
                                

                var svgDoc = SvgDocument.Open("vietqr.svg"); 
                

                var g = svgDoc.GetElementById("qrcode") as SvgImage;
                g.Href = "data:image/png;base64," + ImageToBase64(qrCodeImage, ImageFormat.Png);

                var asotk = svgDoc.GetElementById("sotk") as SvgTextSpan;
                asotk.Text = "Số TK: " + sotk;

                var hotentk = svgDoc.GetElementById("hotentk") as SvgTextSpan;
                hotentk.Text = "Tên TK: " + tb_tenchutk.Text.ToUpper();



                //Bitmap bitmap = svgDoc.Draw();//load the image file
                //PrivateFontCollection pfcoll = new PrivateFontCollection();
                ////put a font file under a Fonts directory within your application root
                //var fontName = "Roboto-Bold.ttf";
                //pfcoll.AddFontFile("fonts/" + fontName);
                //FontFamily ff = pfcoll.Families[0];
                //using (Graphics graphics = Graphics.FromImage(bitmap))
                //{
                //    using (Font RobotoFont = new Font(ff, 30, FontStyle.Bold, GraphicsUnit.Point))
                //    {
                //        Rectangle rect = new Rectangle(0, 1130, bitmap.Width - 10,60);

                //        StringFormat sf = new StringFormat
                //        {
                //            LineAlignment = StringAlignment.Center,
                //            Alignment = StringAlignment.Center
                //        };

                //        graphics.DrawString("Số TK: " + sotk, RobotoFont, Brushes.Red, rect, sf);

                //        rect = new Rectangle(0, 1190 , bitmap.Width - 10, 60);

                //        graphics.DrawString("Tên TK: "+ tb_tenchutk.Text, RobotoFont, Brushes.Red, rect, sf);

                //        //graphics.DrawRectangle(Pens.Green, rect);
                //    }
                //}
                pictureBox1.Image = svgDoc.Draw(); ;



                
                svgDoc.Write("result.svg");
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

        private void button1_Click(object sender, EventArgs e)
        {
           


        }
    }
}
