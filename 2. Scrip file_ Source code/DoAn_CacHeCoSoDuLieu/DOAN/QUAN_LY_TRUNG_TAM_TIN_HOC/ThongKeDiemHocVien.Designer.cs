namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class ThongKeDiemHocVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeDiemHocVien));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMaHocVien = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnInDiem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxKetQuaTimKiem = new System.Windows.Forms.GroupBox();
            this.dgvThongKeDiemHocVien = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxKetQuaTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDiemHocVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(332, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(568, 45);
            this.label2.TabIndex = 33;
            this.label2.Text = "THỐNG KÊ ĐIỂM HỌC VIÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 32);
            this.label1.TabIndex = 32;
            this.label1.Text = "Mã học viên";
            // 
            // cbxMaHocVien
            // 
            this.cbxMaHocVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxMaHocVien.FormattingEnabled = true;
            this.cbxMaHocVien.Location = new System.Drawing.Point(269, 41);
            this.cbxMaHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMaHocVien.Name = "cbxMaHocVien";
            this.cbxMaHocVien.Size = new System.Drawing.Size(235, 33);
            this.cbxMaHocVien.TabIndex = 31;
            this.cbxMaHocVien.SelectedIndexChanged += new System.EventHandler(this.cbxMaHocVien_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTimKiem.FlatAppearance.BorderSize = 3;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(23, 36);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(130, 46);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnInDiem);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(654, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(539, 108);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 3;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(406, 36);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 46);
            this.button4.TabIndex = 4;
            this.button4.Text = "THOÁT";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnInDiem
            // 
            this.btnInDiem.BackColor = System.Drawing.Color.White;
            this.btnInDiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInDiem.FlatAppearance.BorderSize = 3;
            this.btnInDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDiem.Location = new System.Drawing.Point(190, 36);
            this.btnInDiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnInDiem.Name = "btnInDiem";
            this.btnInDiem.Size = new System.Drawing.Size(177, 46);
            this.btnInDiem.TabIndex = 1;
            this.btnInDiem.Text = "IN ĐIỂM";
            this.btnInDiem.UseVisualStyleBackColor = false;
            this.btnInDiem.Click += new System.EventHandler(this.btnInDiem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbxMaHocVien);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(51, 91);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(539, 108);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // gbxKetQuaTimKiem
            // 
            this.gbxKetQuaTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.gbxKetQuaTimKiem.Controls.Add(this.dgvThongKeDiemHocVien);
            this.gbxKetQuaTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxKetQuaTimKiem.ForeColor = System.Drawing.Color.Black;
            this.gbxKetQuaTimKiem.Location = new System.Drawing.Point(40, 255);
            this.gbxKetQuaTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxKetQuaTimKiem.Name = "gbxKetQuaTimKiem";
            this.gbxKetQuaTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxKetQuaTimKiem.Size = new System.Drawing.Size(1123, 399);
            this.gbxKetQuaTimKiem.TabIndex = 36;
            this.gbxKetQuaTimKiem.TabStop = false;
            // 
            // dgvThongKeDiemHocVien
            // 
            this.dgvThongKeDiemHocVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvThongKeDiemHocVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKeDiemHocVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeDiemHocVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeDiemHocVien.Location = new System.Drawing.Point(-101, 40);
            this.dgvThongKeDiemHocVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThongKeDiemHocVien.Name = "dgvThongKeDiemHocVien";
            this.dgvThongKeDiemHocVien.RowHeadersWidth = 51;
            this.dgvThongKeDiemHocVien.Size = new System.Drawing.Size(1240, 440);
            this.dgvThongKeDiemHocVien.TabIndex = 0;
            // 
            // ThongKeDiemHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1216, 810);
            this.Controls.Add(this.gbxKetQuaTimKiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKeDiemHocVien";
            this.Text = "ThongKeDiemHocVien";
            this.Load += new System.EventHandler(this.ThongKeDiemHocVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxKetQuaTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDiemHocVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMaHocVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnInDiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbxKetQuaTimKiem;
        private System.Windows.Forms.DataGridView dgvThongKeDiemHocVien;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}