namespace BIDVQR
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
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_mota = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tb_tenchutk = new System.Windows.Forms.TextBox();
            this.tb_sotk = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_taoma = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bt_xuatFilePdf = new System.Windows.Forms.Button();
            this.lb_laytemplate = new System.Windows.Forms.LinkLabel();
            this.bt_LoadExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_tenfilepdf = new System.Windows.Forms.TextBox();
            this.rb_export1file = new System.Windows.Forms.RadioButton();
            this.rb_ExportALLfile = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sttDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataExcelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataExcelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tao QRcode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(503, 27);
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
            this.groupBox1.Controls.Add(this.tb_mota);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.tb_tenchutk);
            this.groupBox1.Controls.Add(this.tb_sotk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_taoma);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 198);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Tài khoản";
            // 
            // tb_mota
            // 
            this.tb_mota.Location = new System.Drawing.Point(184, 104);
            this.tb_mota.Name = "tb_mota";
            this.tb_mota.Size = new System.Drawing.Size(247, 20);
            this.tb_mota.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Mô tả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mẫu card";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "tentcard-1mat",
            "tentcard-2mat",
            "QRCODEBIDV"});
            this.comboBox1.Location = new System.Drawing.Point(61, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 21);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tb_tenchutk
            // 
            this.tb_tenchutk.Location = new System.Drawing.Point(184, 78);
            this.tb_tenchutk.Name = "tb_tenchutk";
            this.tb_tenchutk.Size = new System.Drawing.Size(247, 20);
            this.tb_tenchutk.TabIndex = 1;
            // 
            // tb_sotk
            // 
            this.tb_sotk.Location = new System.Drawing.Point(184, 55);
            this.tb_sotk.Name = "tb_sotk";
            this.tb_sotk.Size = new System.Drawing.Size(247, 20);
            this.tb_sotk.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Số tài khoản/Tài khoản Định danh";
            // 
            // bt_taoma
            // 
            this.bt_taoma.Location = new System.Drawing.Point(335, 150);
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
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên chủ tài khoản";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel File|*.xlsx";
            // 
            // bt_xuatFilePdf
            // 
            this.bt_xuatFilePdf.Location = new System.Drawing.Point(22, 315);
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
            this.lb_laytemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sttDataGridViewTextBoxColumn,
            this.hoTenDataGridViewTextBoxColumn,
            this.soTkDataGridViewTextBoxColumn,
            this.Mo_ta});
            this.dataGridView1.DataSource = this.dataExcelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(463, 396);
            this.dataGridView1.TabIndex = 0;
            // 
            // Mo_ta
            // 
            this.Mo_ta.DataPropertyName = "Mo_ta";
            this.Mo_ta.HeaderText = "Mo_ta";
            this.Mo_ta.Name = "Mo_ta";
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
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.bt_xuatFilePdf);
            this.splitContainer1.Panel2.Controls.Add(this.lb_laytemplate);
            this.splitContainer1.Panel2.Controls.Add(this.bt_LoadExcel);
            this.splitContainer1.Size = new System.Drawing.Size(786, 396);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Mẫu card";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "tentcard-1mat",
            "tentcard-2mat",
            "QRCODEBIDV"});
            this.comboBox2.Location = new System.Drawing.Point(86, 106);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(169, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.rb_export1file);
            this.groupBox3.Controls.Add(this.rb_ExportALLfile);
            this.groupBox3.Location = new System.Drawing.Point(22, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 147);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Xuất File";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tb_tenfilepdf);
            this.groupBox4.Location = new System.Drawing.Point(6, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 51);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tên File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên File";
            // 
            // tb_tenfilepdf
            // 
            this.tb_tenfilepdf.Location = new System.Drawing.Point(58, 17);
            this.tb_tenfilepdf.Name = "tb_tenfilepdf";
            this.tb_tenfilepdf.Size = new System.Drawing.Size(205, 20);
            this.tb_tenfilepdf.TabIndex = 0;
            // 
            // rb_export1file
            // 
            this.rb_export1file.AutoSize = true;
            this.rb_export1file.Checked = true;
            this.rb_export1file.Location = new System.Drawing.Point(161, 33);
            this.rb_export1file.Name = "rb_export1file";
            this.rb_export1file.Size = new System.Drawing.Size(72, 17);
            this.rb_export1file.TabIndex = 2;
            this.rb_export1file.TabStop = true;
            this.rb_export1file.Text = "Xuất 1 file";
            this.rb_export1file.UseVisualStyleBackColor = true;
            this.rb_export1file.CheckedChanged += new System.EventHandler(this.rb_export1file_CheckedChanged);
            // 
            // rb_ExportALLfile
            // 
            this.rb_ExportALLfile.AutoSize = true;
            this.rb_ExportALLfile.Location = new System.Drawing.Point(16, 33);
            this.rb_ExportALLfile.Name = "rb_ExportALLfile";
            this.rb_ExportALLfile.Size = new System.Drawing.Size(94, 17);
            this.rb_ExportALLfile.TabIndex = 1;
            this.rb_ExportALLfile.Text = "Xuất Từng File";
            this.rb_ExportALLfile.UseVisualStyleBackColor = true;
            this.rb_ExportALLfile.CheckedChanged += new System.EventHandler(this.rb_ExportALLfile_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tạo Theo DS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 428);
            this.tabControl1.TabIndex = 3;
            // 
            // sttDataGridViewTextBoxColumn
            // 
            this.sttDataGridViewTextBoxColumn.DataPropertyName = "stt";
            this.sttDataGridViewTextBoxColumn.HeaderText = "stt";
            this.sttDataGridViewTextBoxColumn.Name = "sttDataGridViewTextBoxColumn";
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
            this.dataExcelBindingSource.DataSource = typeof(BIDVQR.Data_Excel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "a";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataExcelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_tenchutk;
        private System.Windows.Forms.MaskedTextBox tb_sotk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_taoma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bt_xuatFilePdf;
        private System.Windows.Forms.LinkLabel lb_laytemplate;
        private System.Windows.Forms.Button bt_LoadExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource dataExcelBindingSource;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_tenfilepdf;
        private System.Windows.Forms.RadioButton rb_export1file;
        private System.Windows.Forms.RadioButton rb_ExportALLfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox tb_mota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mo_ta;
    }
}

