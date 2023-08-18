namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class ThongKeDiemLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeDiemLop));
            this.gbxChonThongTin = new System.Windows.Forms.GroupBox();
            this.cbxChonMaLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnInDiem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvThongKeDiemLop = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbxChonThongTin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDiemLop)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxChonThongTin
            // 
            this.gbxChonThongTin.BackColor = System.Drawing.Color.Transparent;
            this.gbxChonThongTin.Controls.Add(this.cbxChonMaLop);
            this.gbxChonThongTin.Controls.Add(this.label2);
            this.gbxChonThongTin.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxChonThongTin.ForeColor = System.Drawing.Color.White;
            this.gbxChonThongTin.Location = new System.Drawing.Point(71, 81);
            this.gbxChonThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.gbxChonThongTin.Name = "gbxChonThongTin";
            this.gbxChonThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.gbxChonThongTin.Size = new System.Drawing.Size(478, 128);
            this.gbxChonThongTin.TabIndex = 13;
            this.gbxChonThongTin.TabStop = false;
            this.gbxChonThongTin.Text = "Chọn thông tin";
            // 
            // cbxChonMaLop
            // 
            this.cbxChonMaLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxChonMaLop.FormattingEnabled = true;
            this.cbxChonMaLop.Location = new System.Drawing.Point(215, 49);
            this.cbxChonMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.cbxChonMaLop.Name = "cbxChonMaLop";
            this.cbxChonMaLop.Size = new System.Drawing.Size(226, 33);
            this.cbxChonMaLop.TabIndex = 1;
            this.cbxChonMaLop.SelectedIndexChanged += new System.EventHandler(this.cbxChonMaLop_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn mã lớp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(453, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 45);
            this.label1.TabIndex = 12;
            this.label1.Text = "BẢNG ĐIỂM LỚP";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTimKiem.FlatAppearance.BorderSize = 3;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(34, 46);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 56);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnInDiem);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(610, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(567, 128);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(402, 46);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(128, 55);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnInDiem
            // 
            this.btnInDiem.BackColor = System.Drawing.Color.White;
            this.btnInDiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInDiem.FlatAppearance.BorderSize = 3;
            this.btnInDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInDiem.Location = new System.Drawing.Point(218, 46);
            this.btnInDiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnInDiem.Name = "btnInDiem";
            this.btnInDiem.Size = new System.Drawing.Size(132, 55);
            this.btnInDiem.TabIndex = 1;
            this.btnInDiem.Text = "IN ĐIỂM";
            this.btnInDiem.UseVisualStyleBackColor = false;
            this.btnInDiem.Click += new System.EventHandler(this.btnInDiem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvThongKeDiemLop);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(71, 270);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1106, 487);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // dgvThongKeDiemLop
            // 
            this.dgvThongKeDiemLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvThongKeDiemLop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKeDiemLop.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeDiemLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeDiemLop.Location = new System.Drawing.Point(8, 35);
            this.dgvThongKeDiemLop.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThongKeDiemLop.Name = "dgvThongKeDiemLop";
            this.dgvThongKeDiemLop.RowHeadersWidth = 51;
            this.dgvThongKeDiemLop.Size = new System.Drawing.Size(1070, 431);
            this.dgvThongKeDiemLop.TabIndex = 0;
            // 
            // ThongKeDiemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1221, 816);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxChonThongTin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKeDiemLop";
            this.Text = "ThongKeDiemLop";
            this.Load += new System.EventHandler(this.ThongKeDiemLop_Load);
            this.gbxChonThongTin.ResumeLayout(false);
            this.gbxChonThongTin.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDiemLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxChonThongTin;
        private System.Windows.Forms.ComboBox cbxChonMaLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnInDiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvThongKeDiemLop;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}