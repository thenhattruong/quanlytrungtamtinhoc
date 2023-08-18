namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class TimKiemDiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemDiem));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxMaLop = new System.Windows.Forms.ComboBox();
            this.rbnMaLop = new System.Windows.Forms.RadioButton();
            this.rbnMaHocVien = new System.Windows.Forms.RadioButton();
            this.cbxMaHocVien = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvTimKiemDiem = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemDiem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(435, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "TÌM KIẾM ĐIỂM";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbxMaLop);
            this.groupBox1.Controls.Add(this.rbnMaLop);
            this.groupBox1.Controls.Add(this.rbnMaHocVien);
            this.groupBox1.Controls.Add(this.cbxMaHocVien);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(13, 110);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1198, 186);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn cách tìm kiếm";
            // 
            // cbxMaLop
            // 
            this.cbxMaLop.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxMaLop.FormattingEnabled = true;
            this.cbxMaLop.Location = new System.Drawing.Point(437, 125);
            this.cbxMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMaLop.Name = "cbxMaLop";
            this.cbxMaLop.Size = new System.Drawing.Size(253, 39);
            this.cbxMaLop.TabIndex = 6;
            this.cbxMaLop.SelectedIndexChanged += new System.EventHandler(this.cbxMaLop_SelectedIndexChanged);
            // 
            // rbnMaLop
            // 
            this.rbnMaLop.AutoSize = true;
            this.rbnMaLop.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnMaLop.Location = new System.Drawing.Point(234, 125);
            this.rbnMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.rbnMaLop.Name = "rbnMaLop";
            this.rbnMaLop.Size = new System.Drawing.Size(98, 30);
            this.rbnMaLop.TabIndex = 5;
            this.rbnMaLop.Text = "Mã lớp";
            this.rbnMaLop.UseVisualStyleBackColor = true;
            this.rbnMaLop.CheckedChanged += new System.EventHandler(this.rbnMaLop_CheckedChanged);
            // 
            // rbnMaHocVien
            // 
            this.rbnMaHocVien.AutoSize = true;
            this.rbnMaHocVien.Checked = true;
            this.rbnMaHocVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnMaHocVien.Location = new System.Drawing.Point(234, 57);
            this.rbnMaHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.rbnMaHocVien.Name = "rbnMaHocVien";
            this.rbnMaHocVien.Size = new System.Drawing.Size(148, 30);
            this.rbnMaHocVien.TabIndex = 4;
            this.rbnMaHocVien.TabStop = true;
            this.rbnMaHocVien.Text = "Mã học viên";
            this.rbnMaHocVien.UseVisualStyleBackColor = true;
            this.rbnMaHocVien.CheckedChanged += new System.EventHandler(this.rbnMaHocVien_CheckedChanged);
            // 
            // cbxMaHocVien
            // 
            this.cbxMaHocVien.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxMaHocVien.FormattingEnabled = true;
            this.cbxMaHocVien.Location = new System.Drawing.Point(437, 57);
            this.cbxMaHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMaHocVien.Name = "cbxMaHocVien";
            this.cbxMaHocVien.Size = new System.Drawing.Size(253, 39);
            this.cbxMaHocVien.TabIndex = 2;
            this.cbxMaHocVien.SelectedIndexChanged += new System.EventHandler(this.cbxMaHocVien_SelectedIndexChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(622, 328);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(129, 47);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTimKiem.FlatAppearance.BorderSize = 3;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(341, 325);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 52);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvTimKiemDiem
            // 
            this.dgvTimKiemDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimKiemDiem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTimKiemDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiemDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimKiemDiem.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimKiemDiem.Location = new System.Drawing.Point(0, 56);
            this.dgvTimKiemDiem.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimKiemDiem.Name = "dgvTimKiemDiem";
            this.dgvTimKiemDiem.RowHeadersWidth = 51;
            this.dgvTimKiemDiem.Size = new System.Drawing.Size(1198, 325);
            this.dgvTimKiemDiem.TabIndex = 0;
            this.dgvTimKiemDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiemDiem_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvTimKiemDiem);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(13, 383);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1198, 477);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // TimKiemDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1248, 801);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimKiemDiem";
            this.Text = "TimKiemDiem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemDiem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxMaLop;
        private System.Windows.Forms.RadioButton rbnMaLop;
        private System.Windows.Forms.RadioButton rbnMaHocVien;
        private System.Windows.Forms.ComboBox cbxMaHocVien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTimKiemDiem;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}