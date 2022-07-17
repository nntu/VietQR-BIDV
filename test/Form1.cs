using PDFiumSharp;
using PDFtoImage;
using QRNapasLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var inputStream = new FileStream(@"NGUYEN NGOC TU-74110000192944.pdf", FileMode.Open, FileAccess.Read)) { 
                var page = 1;
                var dpi = 300;

                     Conversion.SavePng("test.png", inputStream, page: page - 1, dpi: dpi, withAnnotations: false, withFormFill: false);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
			 
            // Load the first page
            using (var doc = new PdfDocument(@"NGUYEN NGOC TU-74110000192944.pdf"))
            {
                int i = 0;
                foreach (var page in doc.Pages)
                {
                    using (var bitmap = new PDFiumBitmap((int)page.Width, (int)page.Height, true))
                    using (var stream = new MemoryStream())
                    {
                        page.Render(bitmap);
                        bitmap.Save("out.jpg");
                        
                        i++;
                    }
                }
            }
        }
    }
}
