using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
using System.Threading;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
                var imagePath = qrfolder + '\\' + sotk + "-lite.png";

                //svgDoc.Write(vietqrfolder + '\\' + sotk + ".svg");         

                qrCodeImage.Save(imagePath, ImageFormat.Png);

                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
                var filepdf = pdffolder + '\\' + tb_tenchutk.Text.ToUpper() + "-" + sotk + ".pdf";
                MemoryStream baos = new MemoryStream();
                PdfWriter writer = new PdfWriter(baos);
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
                File.WriteAllBytes(filepdf, baos.ToArray());
                 
                byte[] png = Freeware.Pdf2Png.Convert(baos.ToArray(), 1);

                MemoryStream ms = new MemoryStream(png, 0, png.Length);
                ms.Write(png, 0, png.Length);
                var kequa = Image.FromStream(ms, true);//Exception occurs here
                pictureBox1.Image = kequa;
                kequa.Save(qrfolder + '\\' + sotk + "-full.png",ImageFormat.Png);


                OpenExplorer(filepdf);
                bt_taoma.Enabled = true;
            }
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
                        curRow.GetCell(2).SetCellType(CellType.String);
                        if (curRow.GetCell(2) != null)
                        {
                            
                            var hoten = curRow.GetCell(1) == null ? "" : curRow.GetCell(1).StringCellValue.Trim();
                            var sotk = curRow.GetCell(2) == null ? "" : curRow.GetCell(2).StringCellValue.Trim();

                            ds.Add(new Data_Excel()
                            {
                                
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
        }

        private async void bt_xuatFilePdf_Click(object sender, EventArgs e)
        {
            bt_xuatFilePdf.Enabled = false;
            toolStripProgressBar1.Visible = true;

            toolStripProgressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                toolStripProgressBar1.Value = percent;
            });
            var ls = (List<Data_Excel>)dataGridView1.DataSource;
            toolStripProgressBar1.Maximum = ls.Count();

            await Task.Run(() => GetVietQR(progress, ls));
            bt_xuatFilePdf.Enabled = true;
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
                Bitmap qrCodeImage = qrCode.GetGraphic(100, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));


                //pictureBox1.Image = qrCodeImage;
                var imagePath = qrfolder + '\\' + i.So_Tk + "-lite.png";

                //svgDoc.Write(vietqrfolder + '\\' + sotk + ".svg");         

                qrCodeImage.Save(imagePath, ImageFormat.Png);

                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
                var filepdf = pdffolder + '\\' + i.HoTen.Trim().ToUpper() + "-" + i.So_Tk + ".pdf";
                PdfWriter writer = new PdfWriter(filepdf);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);

                PdfFont pdfFont = PdfFontFactory.CreateFont("fonts/palab.ttf", PdfEncodings.IDENTITY_H);

                pdfDoc.AddFont(pdfFont);
                PdfPage page = pdfDoc.GetFirstPage();
                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("qrcode").SetValue(imageStr);
                formc.GetField("sotk").SetValue("Số TK: " + i.So_Tk, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: " + i.HoTen.ToUpper(), pdfFont, 14);
                formc.FlattenFields();

                pdfDoc.Close();
                writer.Close();

                Stream pdf = new FileStream(filepdf, FileMode.Open, FileAccess.Read);
                byte[] png = Freeware.Pdf2Png.Convert(pdf, 1);

                MemoryStream ms = new MemoryStream(png, 0, png.Length);
                ms.Write(png, 0, png.Length);
                var kequa = Image.FromStream(ms, true);//Exception occurs here
                pictureBox1.Image = kequa;
                kequa.Save(qrfolder + '\\' + i.So_Tk + "-full.png", ImageFormat.Png);

                toolStripStatusLabel1.Text = i.HoTen.ToUpper() + "-" + i.So_Tk;

                Thread.Sleep(30);
                if (progress != null) progress.Report(j);
                j++;
            }
            bt_xuatFilePdf.Enabled = true;
            OpenExplorer(pdffolder);
        }
    }
}
