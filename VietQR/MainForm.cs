using iText.Forms;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietQR
{
    public partial class MainForm : Form
    {

        string tempfolder;
        string vietqrfolder;
        string pdffolder;

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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileInfo fi = new FileInfo(@"template.xlsx");
            fi.CopyTo(tempfolder + @"\template_temp.xlsx", true);
            Process process = new Process();
            process.StartInfo.FileName = tempfolder + @"\template_temp.xlsx";
            process.Start();
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

                            ds.Add(new Data_Excel() {
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


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//
             //
                IWorkbook workbook;

                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                workbook = new XSSFWorkbook(fs);

                //First sheet
                ISheet sheet = workbook.GetSheetAt(0);
                toolStripProgressBar1.Maximum = sheet.LastRowNum;
               var ls =  await Task.Run(() => LoadThongTinExcel(progress, sheet));

                dataGridView1.DataSource = ls;

            }

            toolStripProgressBar1.Visible = false;
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



            OpenExplorer(pdffolder);
            toolStripProgressBar1.Visible = false;
        }

        private async void GetVietQR(IProgress<int> progress, List<Data_Excel> ds ) {

            var vietqr = new VietQRApi();
            
            var j = 1;
            foreach (var i in ds) {
                var request = new VQR_Post()
                {
                    accountName = i.HoTen,
                    accountNo = i.So_Tk,
                    acqId = "970418",
                    format = "vietqr_net"

                };

                var rq = await vietqr.GetVietQR(request);
                
                var base64Data = Regex.Match(rq.data.qrDataURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;

                var bytes = Convert.FromBase64String(base64Data);
                var imagePath = vietqrfolder + '\\' + i.HoTen + "-" +  i.So_Tk + ".jpg";
                using (var imageFile = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                PdfReader reader = new PdfReader("mau.pdf");
                var filepdf = pdffolder + '\\' + i.HoTen + "-" + i.So_Tk + ".pdf";
                PdfWriter writer = new PdfWriter(filepdf);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);


                PdfFont pdfFont = PdfFontFactory.CreateFont("palab.ttf", PdfEncodings.IDENTITY_H);

                pdfDoc.AddFont(pdfFont);


                PdfPage page = pdfDoc.GetFirstPage();


                PdfAcroForm formc = PdfAcroForm.GetAcroForm(pdfDoc, true);

                 
                byte[] byteArray = File.ReadAllBytes(imagePath);
                var imageStr = Convert.ToBase64String(byteArray);
                formc.GetField("Image2_af_image").SetValue(imageStr);

                formc.GetField("tieu_de").SetValue(i.Tieu_De, pdfFont,14);

                formc.FlattenFields();


                pdfDoc.Close();
                writer.Close();

                Thread.Sleep(30);
                if (progress != null) progress.Report(j);
                j++;
            }
        
        
        }

        private void tb_UpdateConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
