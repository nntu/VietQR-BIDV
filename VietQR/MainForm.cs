using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QRCoder;
using Svg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietQRLib;

namespace VietQR
{
    public partial class MainForm : Form
    {
        private string tempfolder;
        private string vietqrfolder;
        private string pdffolder;
        private string temp_template_excel;
        private Config _cf;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainForm()
        {
            InitializeComponent();
        }

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

       

        private void MainForm_Load(object sender, EventArgs e)
        {
            tempfolder = System.AppDomain.CurrentDomain.BaseDirectory + "temp";

            vietqrfolder = System.AppDomain.CurrentDomain.BaseDirectory + "vietqr";

            pdffolder = System.AppDomain.CurrentDomain.BaseDirectory + "Pdf";

            // If directory doesn't exist create one
            if (!Directory.Exists(tempfolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(tempfolder);
            }

            if (!Directory.Exists(vietqrfolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(vietqrfolder);
            }
            if (!Directory.Exists(pdffolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(pdffolder);
            }

            _cf = Config.Load();
        }

        private List<Data_Excel> LoadThongTinExcel(IProgress<int> progress, ISheet sheet)
        {
            try
            {
                List<Data_Excel> ds = new List<Data_Excel>();
                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum; // This may not be valid row count.
                                                     // If first row is table head, i starts from 1
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;

                    for (int i = 1; i <= rowCount; i++)
                    {
                        IRow curRow = sheet.GetRow(i);

                        // Works for consecutive data. Use continue otherwise
                        if (curRow == null)
                        {
                            // Valid row count
                            rowCount = i - 1;
                            break;
                        }
                        // Get data from the 4th column (4th cell of each row)
                        // curRow.GetCell(1).SetCellType(CellType.String);
                        curRow.GetCell(3).SetCellType(CellType.String);
                        if (curRow.GetCell(3) != null)
                        {
                            var tieude = curRow.GetCell(1) == null ? "" : curRow.GetCell(1).StringCellValue.Trim();
                            var hoten = curRow.GetCell(2) == null ? "" : curRow.GetCell(2).StringCellValue.Trim();
                            var sotk = curRow.GetCell(3) == null ? "" : curRow.GetCell(3).StringCellValue.Trim();

                            ds.Add(new Data_Excel()
                            {
                                Tieu_De = tieude,
                                HoTen = hoten,
                                So_Tk = sotk,
                            });
                        }

                        if (progress != null) progress.Report(i);
                    }
                    //   _db.SetThongTinCB(dsttcb);
                }

                return ds;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        private async void bt_LoadExcel_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;

            toolStripProgressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                toolStripProgressBar1.Value = percent;
            });

            openFileDialog1.FileName = temp_template_excel;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//
             //

                IWorkbook workbook;

                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                workbook = new XSSFWorkbook(fs);

                //First sheet
                ISheet sheet = workbook.GetSheetAt(0);
                toolStripProgressBar1.Maximum = sheet.LastRowNum;
                var ls = await Task.Run(() => LoadThongTinExcel(progress, sheet));

                dataGridView1.DataSource = ls;
            }

            // toolStripProgressBar1.Visible = false;
        }

        private async void bt_xuatFilePdf_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;

            toolStripProgressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                toolStripProgressBar1.Value = percent;
            });
            var ls = (List<Data_Excel>)dataGridView1.DataSource;
            toolStripProgressBar1.Maximum = ls.Count();

            await Task.Run(() => GetVietQR(progress, ls));
            bt_xuatFilePdf.Enabled = false;

            // toolStripProgressBar1.Visible = false;
        }

        private void GetVietQR(IProgress<int> progress, List<Data_Excel> ds)
        {
            var j = 1;
            foreach (var i in ds)
            {
                var vietqr = Generator.Generator_VietQR("BIDV", i.So_Tk);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));

                var svgDoc = SvgDocument.Open("vietqr.svg");
                var g = svgDoc.GetElementById("qrcode") as SvgImage;
                g.Href = "data:image/png;base64," + ImageToBase64(qrCodeImage, ImageFormat.Png);
                Bitmap bitmap = svgDoc.Draw();//load the image file
                PrivateFontCollection pfcoll = new PrivateFontCollection();
                //put a font file under a Fonts directory within your application root
                var fontName = "Roboto-Bold.ttf";
                pfcoll.AddFontFile("fonts/" + fontName);
                System.Drawing.FontFamily ff = pfcoll.Families[0];
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font RobotoFont = new Font(ff, 30, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        Rectangle rect = new Rectangle(0, 1130, bitmap.Width - 10, 60);

                        StringFormat sf = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };

                        graphics.DrawString("Số TK: " + i.So_Tk, RobotoFont, Brushes.Red, rect, sf);

                        rect = new Rectangle(0, 1190, bitmap.Width - 10, 60);

                        graphics.DrawString("Tên TK: " + i.HoTen.ToUpper(), RobotoFont, Brushes.Red, rect, sf);

                        //graphics.DrawRectangle(Pens.Green, rect);
                    }
                }
                pictureBox1.Image = bitmap;
                var imagePath = vietqrfolder + '\\' + i.So_Tk + ".jpg";

                svgDoc.Write(vietqrfolder + '\\' + i.So_Tk + ".svg");

                bitmap.Save(imagePath);

                PdfReader reader = new PdfReader("mau.pdf");
                var filepdf = pdffolder + '\\' + i.HoTen + "-" + i.So_Tk + ".pdf";
                PdfWriter writer = new PdfWriter(filepdf);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);
                pdfDoc.AddFont(pdfFont);
                PdfPage page = pdfDoc.GetFirstPage();
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("Image2_af_image").SetValue(imageStr);
                formc.GetField("tieu_de").SetValue(i.Tieu_De, pdfFont, 14);
                formc.FlattenFields();
                pdfDoc.Close();
                writer.Close();

                Thread.Sleep(30);
                if (progress != null) progress.Report(j);
                j++;
            }
            bt_xuatFilePdf.Enabled = true;
            OpenExplorer(pdffolder);
        }

        private void tb_UpdateConfig_Click(object sender, EventArgs e)
        {
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
                Bitmap qrCodeImage = qrCode.GetGraphic(100, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("v2.png"));

                var svgDoc = SvgDocument.Open("vietqr.svg");
                var g = svgDoc.GetElementById("qrcode") as SvgImage;
                g.Href = "data:image/png;base64," + ImageToBase64(qrCodeImage, ImageFormat.Png);

                Bitmap bitmap = svgDoc.Draw();//load the image file
                PrivateFontCollection pfcoll = new PrivateFontCollection();
                //put a font file under a Fonts directory within your application root
                var fontName = "Roboto-Bold.ttf";
                pfcoll.AddFontFile("fonts\\" + fontName);
                System.Drawing.FontFamily ff = pfcoll.Families[0];
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font RobotoFontTK = new Font(ff, 50, FontStyle.Bold, GraphicsUnit.Point);
                     
                        Rectangle rect = new Rectangle(0, 1110, bitmap.Width - 10, 70);

                        StringFormat sf = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };

                        graphics.DrawString("Số TK: " + sotk, RobotoFontTK, Brushes.Red, rect, sf);

                        rect = new Rectangle(0, 1200, bitmap.Width - 10, 70);
                    Font RobotoFontTENTK = new Font(ff, 40, FontStyle.Bold, GraphicsUnit.Point);
                    graphics.DrawString("Tên TK: " + tb_tenchutk.Text.ToUpper(), RobotoFontTENTK, Brushes.Red, rect, sf);

                        //graphics.DrawRectangle(Pens.Green, rect);
                   
                }
                pictureBox1.Image = bitmap;
                var imagePath = vietqrfolder + '\\' + sotk + ".png";

                //svgDoc.Write(vietqrfolder + '\\' + sotk + ".svg");         

                bitmap.Save(imagePath,ImageFormat.Png);

                PdfReader reader = new PdfReader("mau.pdf");
                var filepdf = pdffolder + '\\' + tb_tenchutk.Text.ToUpper() + "-" + sotk + ".pdf";
                PdfWriter writer = new PdfWriter(filepdf);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);

                pdfDoc.AddFont(pdfFont);
                PdfPage page = pdfDoc.GetFirstPage();
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("Image2_af_image").SetValue(imageStr);
                formc.GetField("tieu_de").SetValue(tb_tieude.Text, pdfFont, 14);
                formc.FlattenFields();
                pdfDoc.Close();
                writer.Close();

                OpenExplorer(filepdf);
                bt_taoma.Enabled = true;
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

        private void lb_laytemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                var timestamp = DateTime.Now.ToFileTime();
                FileInfo fi = new FileInfo(@"template.xlsx");
                temp_template_excel = string.Format("{0}\\template_{1}.xlsx", tempfolder, timestamp);
                fi.CopyTo(temp_template_excel, true);
                Process process = new Process();
                process.StartInfo.FileName = temp_template_excel;
                process.Start();
             
        }
    }
}