namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class TimKiemHocVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemHocVien));
            this.label1 = new System.Windows.Forms.Label();
            this.gbxChonCachTimKiem = new System.Windows.Forms.GroupBox();
            this.rbnTenHocVien = new System.Windows.Forms.RadioButton();
            this.rbnMaHocVien = new System.Windows.Forms.RadioButton();
            this.gbxThongTinCanTimKiem = new System.Windows.Forms.GroupBox();
            this.btnHuongDanTimKiem = new System.Windows.Forms.Button();
            this.tbxTimKiem = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKem = new System.Windows.Forms.Button();
            this.gbxKetQuaTimKiem = new System.Windows.Forms.GroupBox();
            this.dgvTimKiemHocVien = new System.Windows.Forms.DataGridView();
            this.gbxChonCachTimKiem.SuspendLayout();
            this.gbxThongTinCanTimKiem.SuspendLayout();
            this.gbxKetQuaTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHocVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "TÌM KIẾM THÔNG TIN HỌC VIÊN";
            // 
            // gbxChonCachTimKiem
            // 
            this.gbxChonCachTimKiem.BackColor = System.Drawing.Color.White;
            this.gbxChonCachTimKiem.Controls.Add(this.rbnTenHocVien);
            this.gbxChonCachTimKiem.Controls.Add(this.rbnMaHocVien);
            this.gbxChonCachTimKiem.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxChonCachTimKiem.Location = new System.Drawing.Point(26, 124);
            this.gbxChonCachTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxChonCachTimKiem.Name = "gbxChonCachTimKiem";
            this.gbxChonCachTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxChonCachTimKiem.Size = new System.Drawing.Size(665, 165);
            this.gbxChonCachTimKiem.TabIndex = 12;
            this.gbxChonCachTimKiem.TabStop = false;
            this.gbxChonCachTimKiem.Text = "Chọn cách tìm kiếm";
            // 
            // rbnTenHocVien
            // 
            this.rbnTenHocVien.AutoSize = true;
            this.rbnTenHocVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnTenHocVien.Location = new System.Drawing.Point(20, 106);
            this.rbnTenHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.rbnTenHocVien.Name = "rbnTenHocVien";
            this.rbnTenHocVien.Size = new System.Drawing.Size(155, 30);
            this.rbnTenHocVien.TabIndex = 1;
            this.rbnTenHocVien.TabStop = true;
            this.rbnTenHocVien.Text = "Tên học viên";
            this.rbnTenHocVien.UseVisualStyleBackColor = true;
            this.rbnTenHocVien.CheckedChanged += new System.EventHandler(this.rbnTenHocVien_CheckedChanged);
            // 
            // rbnMaHocVien
            // 
            this.rbnMaHocVien.AutoSize = true;
            this.rbnMaHocVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnMaHocVien.Location = new System.Drawing.Point(20, 40);
            this.rbnMaHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.rbnMaHocVien.Name = "rbnMaHocVien";
            this.rbnMaHocVien.Size = new System.Drawing.Size(148, 30);
            this.rbnMaHocVien.TabIndex = 0;
            this.rbnMaHocVien.TabStop = true;
            this.rbnMaHocVien.Text = "Mã học viên";
            this.rbnMaHocVien.UseVisualStyleBackColor = true;
            this.rbnMaHocVien.CheckedChanged += new System.EventHandler(this.rbnMaHocVien_CheckedChanged);
            // 
            // gbxThongTinCanTimKiem
            // 
            this.gbxThongTinCanTimKiem.BackColor = System.Drawing.Color.White;
            this.gbxThongTinCanTimKiem.Controls.Add(this.btnHuongDanTimKiem);
            this.gbxThongTinCanTimKiem.Controls.Add(this.tbxTimKiem);
            this.gbxThongTinCanTimKiem.Controls.Add(this.btnThoat);
            this.gbxThongTinCanTimKiem.Controls.Add(this.btnTimKem);
            this.gbxThongTinCanTimKiem.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxThongTinCanTimKiem.Location = new System.Drawing.Point(742, 124);
            this.gbxThongTinCanTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxThongTinCanTimKiem.Name = "gbxThongTinCanTimKiem";
            this.gbxThongTinCanTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxThongTinCanTimKiem.Size = new System.Drawing.Size(550, 202);
            this.gbxThongTinCanTimKiem.TabIndex = 14;
            this.gbxThongTinCanTimKiem.TabStop = false;
            this.gbxThongTinCanTimKiem.Text = "Thông tin cần tìm kiếm";
            // 
            // btnHuongDanTimKiem
            // 
            this.btnHuongDanTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHuongDanTimKiem.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuongDanTimKiem.Location = new System.Drawing.Point(395, 62);
            this.btnHuongDanTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuongDanTimKiem.Name = "btnHuongDanTimKiem";
            this.btnHuongDanTimKiem.Size = new System.Drawing.Size(65, 46);
            this.btnHuongDanTimKiem.TabIndex = 6;
            this.btnHuongDanTimKiem.Text = "?";
            this.btnHuongDanTimKiem.UseVisualStyleBackColor = false;
            this.btnHuongDanTimKiem.Click += new System.EventHandler(this.btnHuongDanTimKiem_Click);
            // 
            // tbxTimKiem
            // 
            this.tbxTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbxTimKiem.Location = new System.Drawing.Point(30, 60);
            this.tbxTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTimKiem.Multiline = true;
            this.tbxTimKiem.Name = "tbxTimKiem";
            this.tbxTimKiem.Size = new System.Drawing.Size(321, 48);
            this.tbxTimKiem.TabIndex = 4;
            this.tbxTimKiem.TextChanged += new System.EventHandler(this.tbxTimKiem_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(355, 122);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 45);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKem
            // 
            this.btnTimKem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTimKem.FlatAppearance.BorderSize = 3;
            this.btnTimKem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKem.Location = new System.Drawing.Point(120, 122);
            this.btnTimKem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKem.Name = "btnTimKem";
            this.btnTimKem.Size = new System.Drawing.Size(139, 43);
            this.btnTimKem.TabIndex = 1;
            this.btnTimKem.Text = "TÌM KIẾM";
            this.btnTimKem.UseVisualStyleBackColor = true;
            this.btnTimKem.Click += new System.EventHandler(this.btnTimKem_Click);
            // 
            // gbxKetQuaTimKiem
            // 
            this.gbxKetQuaTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.gbxKetQuaTimKiem.Controls.Add(this.dgvTimKiemHocVien);
            this.gbxKetQuaTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxKetQuaTimKiem.ForeColor = System.Drawing.Color.Black;
            this.gbxKetQuaTimKiem.Location = new System.Drawing.Point(26, 356);
            this.gbxKetQuaTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxKetQuaTimKiem.Name = "gbxKetQuaTimKiem";
            this.gbxKetQuaTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxKetQuaTimKiem.Size = new System.Drawing.Size(1225, 360);
            this.gbxKetQuaTimKiem.TabIndex = 15;
            this.gbxKetQuaTimKiem.TabStop = false;
            // 
            // dgvTimKiemHocVien
            // 
            this.dgvTimKiemHocVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimKiemHocVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTimKiemHocVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiemHocVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemHocVien.Location = new System.Drawing.Point(0, 40);
            this.dgvTimKiemHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimKiemHocVien.Name = "dgvTimKiemHocVien";
            this.dgvTimKiemHocVien.RowHeadersWidth = 51;
            this.dgvTimKiemHocVien.Size = new System.Drawing.Size(1249, 275);
            this.dgvTimKiemHocVien.TabIndex = 0;
            this.dgvTimKiemHocVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiemHocVien_CellContentClick);
            // 
            // TimKiemHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1367, 985);
            this.Controls.Add(this.gbxKetQuaTimKiem);
            this.Controls.Add(this.gbxThongTinCanTimKiem);
            this.Controls.Add(this.gbxChonCachTimKiem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimKiemHocVien";
            this.Text = "TimKiemHocVien";
            this.gbxChonCachTimKiem.ResumeLayout(false);
            this.gbxChonCachTimKiem.PerformLayout();
            this.gbxThongTinCanTimKiem.ResumeLayout(false);
            this.gbxThongTinCanTimKiem.PerformLayout();
            this.gbxKetQuaTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHocVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxChonCachTimKiem;
        private System.Windows.Forms.RadioButton rbnTenHocVien;
        private System.Windows.Forms.RadioButton rbnMaHocVien;
        private System.Windows.Forms.GroupBox gbxThongTinCanTimKiem;
        private System.Windows.Forms.Button btnHuongDanTimKiem;
        private System.Windows.Forms.TextBox tbxTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKem;
        private System.Windows.Forms.GroupBox gbxKetQuaTimKiem;
        private System.Windows.Forms.DataGridView dgvTimKiemHocVien;
    }
}