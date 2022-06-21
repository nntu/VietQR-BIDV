using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRNapasLib;

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

            tb_tenfilepdf.Text = string.Format("file_{0:dd_MM_yyyy_hhmmss}.pdf", DateTime.Now);
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " "+ version.ToString();
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

                using (MemoryStream ms = new MemoryStream(png, 0, png.Length))
                {
                    ;
                    ms.Write(png, 0, png.Length);
                    var kequa = Image.FromStream(ms, true);//Exception occurs here
                    pictureBox1.Image = kequa;
                    kequa.Save(qrfolder + '\\' + sotk + "-full.png", ImageFormat.Png);
                }

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
            if (dataGridView1.RowCount == 1)
            {
                MessageBox.Show("Chưa Nhập Danh sách Tài khoản");
            }
            else
            {
                var ls = (List<Data_Excel>)dataGridView1.DataSource;
                bt_xuatFilePdf.Enabled = false;
                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel1.Visible = true;

                toolStripProgressBar1.Value = 0;
                var progress = new Progress<int>(percent =>
                {
                    toolStripProgressBar1.Value = percent;
                });

                toolStripProgressBar1.Maximum = ls.Count();
                if (rb_export1file.Checked)
                {
                    tb_tenfilepdf.Text = string.Format("file_{0:dd_MM_yyyy_hhmmss}.pdf", DateTime.Now);
                    await Task.Run(() => GetVietQR(progress, ls, tb_tenfilepdf.Text));
                }
                else
                {
                    await Task.Run(() => GetVietQR(progress, ls));
                }

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Visible = false;
                bt_xuatFilePdf.Enabled = true;
            }
        }

        /// <summary>
        /// Xuất vào 1 file pdf
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="ds"></param>
        /// <param name="filename"></param>
        private void GetVietQR(IProgress<int> progress, List<Data_Excel> ds, string filename)
        {
            List<byte[]> addpdffile = new List<byte[]>();

            var j = 1;
            foreach (var i in ds)
            {
                var vietqr = Generator.Generator_VietQR("BIDV", i.So_Tk);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(40, Color.FromArgb(0, 107, 104), Color.White, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));
                var imagePath = qrfolder + '\\' + i.So_Tk + "-lite.png";
                qrCodeImage.Save(imagePath, ImageFormat.Png);
                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");
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
                formc.GetField("sotk").SetValue("Số TK: " + i.So_Tk, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: " + i.HoTen.ToUpper(), pdfFont, 14);
                formc.FlattenFields();

                pdfDoc.Close();
                writer.Close();
                addpdffile.Add(baos.ToArray());

                byte[] png = Freeware.Pdf2Png.Convert(baos.ToArray(), 1);

                MemoryStream ms = new MemoryStream(png, 0, png.Length);
                ms.Write(png, 0, png.Length);
                var kequa = Image.FromStream(ms, true);//Exception occurs here

                kequa.Save(qrfolder + '\\' + i.So_Tk + "-full.png", ImageFormat.Png);

                toolStripStatusLabel1.Text = i.HoTen.ToUpper() + "-" + i.So_Tk;

                Thread.Sleep(1);
                if (progress != null) progress.Report(j);
                j++;
            }

            File.WriteAllBytes(pdffolder + '\\' + filename, Combine(addpdffile));

            OpenExplorer(pdffolder + '\\' + filename);
        }

        /// <summary>
        /// Xuất ra tưng file
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="ds"></param>
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
                var imagePath = qrfolder + '\\' + i.So_Tk + "-lite.png";
                qrCodeImage.Save(imagePath, ImageFormat.Png);

                var filepdf = pdffolder + '\\' + i.HoTen.Trim().ToUpper() + "-" + i.So_Tk + ".pdf";
                PdfReader reader = new PdfReader("QRCODEBIDV.pdf");

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
                formc.GetField("sotk").SetValue("Số TK: " + i.So_Tk, pdfFont, 18);
                formc.GetField("hotentk").SetValue("Tên TK: " + i.HoTen.ToUpper(), pdfFont, 14);
                formc.FlattenFields();

                pdfDoc.Close();
                writer.Close();
                File.WriteAllBytes(filepdf, baos.ToArray());

                byte[] png = Freeware.Pdf2Png.Convert(baos.ToArray(), 1);

                MemoryStream ms = new MemoryStream(png, 0, png.Length);
                ms.Write(png, 0, png.Length);
                var kequa = Image.FromStream(ms, true);//Exception occurs here
                kequa.Save(qrfolder + '\\' + i.So_Tk + "-full.png", ImageFormat.Png);

                toolStripStatusLabel1.Text = i.HoTen.ToUpper() + "-" + i.So_Tk;

                Thread.Sleep(30);
                if (progress != null) progress.Report(j);
                j++;
            }

            bt_xuatFilePdf.Enabled = true;

            OpenExplorer(pdffolder);
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

        private void rb_ExportALLfile_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    // Only one radio button will be checked
                    groupBox4.Enabled = false;
                }
            }
        }

        private void rb_export1file_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    // Only one radio button will be checked
                    groupBox4.Enabled = true;
                    var tenfile = string.Format("file_{0:dd_MM_yyyy_hhmmss}.pdf", DateTime.Now);
                    tb_tenfilepdf.Text = tenfile;
                }
            }
        }
    }
}