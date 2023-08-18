namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class TimKiemGiaoVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemGiaoVien));
            this.label1 = new System.Windows.Forms.Label();
            this.rbnMaGiaoVien = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rbnTenGiaoVien = new System.Windows.Forms.RadioButton();
            this.gbxChonCachTimKiem = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTimKiemGiaoVien = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.gbxChonCachTimKiem.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemGiaoVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(243, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 45);
            this.label1.TabIndex = 13;
            this.label1.Text = "TÌM KIẾM THÔNG TIN GIÁO VIÊN";
            // 
            // rbnMaGiaoVien
            // 
            this.rbnMaGiaoVien.AutoSize = true;
            this.rbnMaGiaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnMaGiaoVien.Location = new System.Drawing.Point(337, 46);
            this.rbnMaGiaoVien.Margin = new System.Windows.Forms.Padding(4);
            this.rbnMaGiaoVien.Name = "rbnMaGiaoVien";
            this.rbnMaGiaoVien.Size = new System.Drawing.Size(170, 33);
            this.rbnMaGiaoVien.TabIndex = 0;
            this.rbnMaGiaoVien.TabStop = true;
            this.rbnMaGiaoVien.Text = "Mã giáo viên";
            this.rbnMaGiaoVien.UseVisualStyleBackColor = true;
            this.rbnMaGiaoVien.CheckedChanged += new System.EventHandler(this.rbnMaGiaoVien_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.tbxThongTinTimKiem);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 184);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1182, 118);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tìm kiếm";
            // 
            // tbxThongTinTimKiem
            // 
            this.tbxThongTinTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbxThongTinTimKiem.Location = new System.Drawing.Point(62, 48);
            this.tbxThongTinTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxThongTinTimKiem.Name = "tbxThongTinTimKiem";
            this.tbxThongTinTimKiem.Size = new System.Drawing.Size(349, 34);
            this.tbxThongTinTimKiem.TabIndex = 4;
            this.tbxThongTinTimKiem.TextChanged += new System.EventHandler(this.tbxThongTinTimKiem_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(745, 48);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(136, 47);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTimKiem.FlatAppearance.BorderSize = 3;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(501, 51);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(154, 40);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rbnTenGiaoVien
            // 
            this.rbnTenGiaoVien.AutoSize = true;
            this.rbnTenGiaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnTenGiaoVien.Location = new System.Drawing.Point(657, 46);
            this.rbnTenGiaoVien.Margin = new System.Windows.Forms.Padding(4);
            this.rbnTenGiaoVien.Name = "rbnTenGiaoVien";
            this.rbnTenGiaoVien.Size = new System.Drawing.Size(180, 33);
            this.rbnTenGiaoVien.TabIndex = 1;
            this.rbnTenGiaoVien.TabStop = true;
            this.rbnTenGiaoVien.Text = "Tên giáo viên";
            this.rbnTenGiaoVien.UseVisualStyleBackColor = true;
            this.rbnTenGiaoVien.CheckedChanged += new System.EventHandler(this.rbnTenGiaoVien_CheckedChanged);
            // 
            // gbxChonCachTimKiem
            // 
            this.gbxChonCachTimKiem.BackColor = System.Drawing.Color.White;
            this.gbxChonCachTimKiem.Controls.Add(this.rbnTenGiaoVien);
            this.gbxChonCachTimKiem.Controls.Add(this.rbnMaGiaoVien);
            this.gbxChonCachTimKiem.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxChonCachTimKiem.Location = new System.Drawing.Point(27, 97);
            this.gbxChonCachTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxChonCachTimKiem.Name = "gbxChonCachTimKiem";
            this.gbxChonCachTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxChonCachTimKiem.Size = new System.Drawing.Size(1182, 99);
            this.gbxChonCachTimKiem.TabIndex = 15;
            this.gbxChonCachTimKiem.TabStop = false;
            this.gbxChonCachTimKiem.Text = "Chọn cách tìm kiếm";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvTimKiemGiaoVien);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(27, 349);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1182, 386);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // dgvTimKiemGiaoVien
            // 
            this.dgvTimKiemGiaoVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimKiemGiaoVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTimKiemGiaoVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiemGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemGiaoVien.Location = new System.Drawing.Point(0, 40);
            this.dgvTimKiemGiaoVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimKiemGiaoVien.Name = "dgvTimKiemGiaoVien";
            this.dgvTimKiemGiaoVien.RowHeadersWidth = 51;
            this.dgvTimKiemGiaoVien.Size = new System.Drawing.Size(1190, 350);
            this.dgvTimKiemGiaoVien.TabIndex = 0;
            this.dgvTimKiemGiaoVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiemGiaoVien_CellContentClick);
            // 
            // TimKiemGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1258, 811);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxChonCachTimKiem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimKiemGiaoVien";
            this.Text = "TimKiemGiaoVien";
            this.Load += new System.EventHandler(this.TimKiemGiaoVien_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxChonCachTimKiem.ResumeLayout(false);
            this.gbxChonCachTimKiem.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemGiaoVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnMaGiaoVien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxThongTinTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton rbnTenGiaoVien;
        private System.Windows.Forms.GroupBox gbxChonCachTimKiem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTimKiemGiaoVien;
    }
}