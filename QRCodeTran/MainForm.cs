using QRCoder;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
                //var chuoi = new KeyQRCode(sotk);
                //string chuoima = chuoi.toString();

                //byte[] bytes = Encoding.ASCII.GetBytes(chuoima);

                //CRCTool foo = new CRCTool();
                //var a = foo.CalcCRCITT(bytes);
                //string hexOutput = String.Format("{0:X}", a);
                //string chuoimahoacheck = chuoima + hexOutput;

                var vietqr = Generator.Generator_VietQR("BIDV", sotk ); 


                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);
                

                
                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));

                

                var svgDoc = SvgDocument.Open("vietqr.svg");
                
                

                var g = svgDoc.GetElementById("qrcode") as SvgImage;
                g.Href = "data:image/png;base64," + ImageToBase64(qrCodeImage, ImageFormat.Png);

                //  var hoten = svgDoc.GetElementById("hoten") as SvgText;
                // hoten.Text = tb_tenchutk.Text;

                Point firstLocation = new Point(194, 1160);
                var firstText = "BIDV CAN THO";
                Bitmap bitmap = svgDoc.Draw();//load the image file

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Arial", 26, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        Rectangle rect = new Rectangle(0, 1160, bitmap.Width - 10, bitmap.Height - 10);

                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;

                        graphics.DrawString(firstText, arialFont, Brushes.Red, rect, sf);
                        graphics.DrawRectangle(Pens.Green, rect);
                    }
                }
                pictureBox1.Image = bitmap;



                
                svgDoc.Write("result.svg");
                ////30,66,126
                //pictureBox1.Image = qrCodeImage;
                bitmap.Save("result.jpg");
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
