using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                var vietqr = viet_qr_generator.Generator.Generator_VietQR("BIDV", sotk ); 


                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));
                
                pictureBox1.Image = qrCodeImage;

            }
        }
    }
}
