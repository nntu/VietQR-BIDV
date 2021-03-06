
namespace VietQR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_tenchutk = new System.Windows.Forms.TextBox();
            this.tb_sotk = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_taoma = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_tieude = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tieuDeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataExcelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bt_xuatFilePdf = new System.Windows.Forms.Button();
            this.lb_laytemplate = new System.Windows.Forms.LinkLabel();
            this.bt_LoadExcel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataExcelBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tao QRcode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(468, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 317);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả QR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_tenchutk);
            this.groupBox1.Controls.Add(this.tb_sotk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_taoma);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_tieude);
            this.groupBox1.Location = new System.Drawing.Point(8, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 180);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tiêu Đề";
            // 
            // tb_tenchutk
            // 
            this.tb_tenchutk.Location = new System.Drawing.Point(126, 54);
            this.tb_tenchutk.Name = "tb_tenchutk";
            this.tb_tenchutk.Size = new System.Drawing.Size(247, 20);
            this.tb_tenchutk.TabIndex = 1;
            // 
            // tb_sotk
            // 
            this.tb_sotk.Location = new System.Drawing.Point(126, 27);
            this.tb_sotk.Mask = "###-##-########-#";
            this.tb_sotk.Name = "tb_sotk";
            this.tb_sotk.Size = new System.Drawing.Size(247, 20);
            this.tb_sotk.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Số tài khoản";
            // 
            // bt_taoma
            // 
            this.bt_taoma.Location = new System.Drawing.Point(23, 136);
            this.bt_taoma.Name = "bt_taoma";
            this.bt_taoma.Size = new System.Drawing.Size(96, 23);
            this.bt_taoma.TabIndex = 3;
            this.bt_taoma.Text = "Tạo QRCode";
            this.bt_taoma.UseVisualStyleBackColor = true;
            this.bt_taoma.Click += new System.EventHandler(this.bt_taoma_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên chủ tài khoản";
            // 
            // tb_tieude
            // 
            this.tb_tieude.Location = new System.Drawing.Point(126, 84);
            this.tb_tieude.Name = "tb_tieude";
            this.tb_tieude.Size = new System.Drawing.Size(247, 20);
            this.tb_tieude.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tạo Theo DS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bt_xuatFilePdf);
            this.splitContainer1.Panel2.Controls.Add(this.lb_laytemplate);
            this.splitContainer1.Panel2.Controls.Add(this.bt_LoadExcel);
            this.splitContainer1.Size = new System.Drawing.Size(786, 418);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tieuDeDataGridViewTextBoxColumn,
            this.hoTenDataGridViewTextBoxColumn,
            this.soTkDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataExcelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(504, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // tieuDeDataGridViewTextBoxColumn
            // 
            this.tieuDeDataGridViewTextBoxColumn.DataPropertyName = "Tieu_De";
            this.tieuDeDataGridViewTextBoxColumn.HeaderText = "Tieu_De";
            this.tieuDeDataGridViewTextBoxColumn.Name = "tieuDeDataGridViewTextBoxColumn";
            // 
            // hoTenDataGridViewTextBoxColumn
            // 
            this.hoTenDataGridViewTextBoxColumn.DataPropertyName = "HoTen";
            this.hoTenDataGridViewTextBoxColumn.HeaderText = "HoTen";
            this.hoTenDataGridViewTextBoxColumn.Name = "hoTenDataGridViewTextBoxColumn";
            // 
            // soTkDataGridViewTextBoxColumn
            // 
            this.soTkDataGridViewTextBoxColumn.DataPropertyName = "So_Tk";
            this.soTkDataGridViewTextBoxColumn.HeaderText = "So_Tk";
            this.soTkDataGridViewTextBoxColumn.Name = "soTkDataGridViewTextBoxColumn";
            // 
            // dataExcelBindingSource
            // 
            this.dataExcelBindingSource.DataSource = typeof(VietQR.Data_Excel);
            // 
            // bt_xuatFilePdf
            // 
            this.bt_xuatFilePdf.Location = new System.Drawing.Point(22, 91);
            this.bt_xuatFilePdf.Name = "bt_xuatFilePdf";
            this.bt_xuatFilePdf.Size = new System.Drawing.Size(113, 23);
            this.bt_xuatFilePdf.TabIndex = 2;
            this.bt_xuatFilePdf.Text = "Xuất File PDF";
            this.bt_xuatFilePdf.UseVisualStyleBackColor = true;
            this.bt_xuatFilePdf.Click += new System.EventHandler(this.bt_xuatFilePdf_Click);
            // 
            // lb_laytemplate
            // 
            this.lb_laytemplate.AutoSize = true;
            this.lb_laytemplate.Location = new System.Drawing.Point(19, 21);
            this.lb_laytemplate.Name = "lb_laytemplate";
            this.lb_laytemplate.Size = new System.Drawing.Size(71, 13);
            this.lb_laytemplate.TabIndex = 1;
            this.lb_laytemplate.TabStop = true;
            this.lb_laytemplate.Text = "Lấy Template";
            this.lb_laytemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_laytemplate_LinkClicked);
            // 
            // bt_LoadExcel
            // 
            this.bt_LoadExcel.Location = new System.Drawing.Point(22, 47);
            this.bt_LoadExcel.Name = "bt_LoadExcel";
            this.bt_LoadExcel.Size = new System.Drawing.Size(132, 23);
            this.bt_LoadExcel.TabIndex = 0;
            this.bt_LoadExcel.Text = "Load Template";
            this.bt_LoadExcel.UseVisualStyleBackColor = true;
            this.bt_LoadExcel.Click += new System.EventHandler(this.bt_LoadExcel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel File|*.xlsx";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Tạo File VietQR BIDV - tunn1@bidv.com.vn - Ver: 2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataExcelBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lb_laytemplate;
        private System.Windows.Forms.Button bt_LoadExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tieuDeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTkDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataExcelBindingSource;
        private System.Windows.Forms.Button bt_xuatFilePdf;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_tenchutk;
        private System.Windows.Forms.MaskedTextBox tb_sotk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_taoma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_tieude;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

