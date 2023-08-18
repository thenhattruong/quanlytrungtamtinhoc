namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    partial class ThongKeDanhSachChungChi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeDanhSachChungChi));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnDat = new System.Windows.Forms.RadioButton();
            this.rbnChuaNhan = new System.Windows.Forms.RadioButton();
            this.rbnDaNhan = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvThongKeChungChi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInDanhSach = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeChungChi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(360, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 45);
            this.label1.TabIndex = 15;
            this.label1.Text = "DANH SÁCH CHỨNG CHỈ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnDat);
            this.groupBox1.Controls.Add(this.rbnChuaNhan);
            this.groupBox1.Controls.Add(this.rbnDaNhan);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(23, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1165, 164);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn cách tìm kiếm";
            // 
            // rbnDat
            // 
            this.rbnDat.AutoSize = true;
            this.rbnDat.Checked = true;
            this.rbnDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnDat.Location = new System.Drawing.Point(28, 43);
            this.rbnDat.Margin = new System.Windows.Forms.Padding(4);
            this.rbnDat.Name = "rbnDat";
            this.rbnDat.Size = new System.Drawing.Size(326, 29);
            this.rbnDat.TabIndex = 7;
            this.rbnDat.TabStop = true;
            this.rbnDat.Text = "Danh sách học viên đạt chứng chỉ";
            this.rbnDat.UseVisualStyleBackColor = true;
            this.rbnDat.CheckedChanged += new System.EventHandler(this.rbnDat_CheckedChanged);
            // 
            // rbnChuaNhan
            // 
            this.rbnChuaNhan.AutoSize = true;
            this.rbnChuaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnChuaNhan.Location = new System.Drawing.Point(28, 127);
            this.rbnChuaNhan.Margin = new System.Windows.Forms.Padding(4);
            this.rbnChuaNhan.Name = "rbnChuaNhan";
            this.rbnChuaNhan.Size = new System.Drawing.Size(372, 29);
            this.rbnChuaNhan.TabIndex = 7;
            this.rbnChuaNhan.Text = "Danh sách học viên chưa lấy chứng chỉ";
            this.rbnChuaNhan.UseVisualStyleBackColor = true;
            this.rbnChuaNhan.CheckedChanged += new System.EventHandler(this.rbnChuaNhan_CheckedChanged);
            // 
            // rbnDaNhan
            // 
            this.rbnDaNhan.AutoSize = true;
            this.rbnDaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbnDaNhan.Location = new System.Drawing.Point(28, 87);
            this.rbnDaNhan.Margin = new System.Windows.Forms.Padding(4);
            this.rbnDaNhan.Name = "rbnDaNhan";
            this.rbnDaNhan.Size = new System.Drawing.Size(351, 29);
            this.rbnDaNhan.TabIndex = 1;
            this.rbnDaNhan.Text = "Danh sách học viên đã lấy chứng chỉ";
            this.rbnDaNhan.UseVisualStyleBackColor = true;
            this.rbnDaNhan.CheckedChanged += new System.EventHandler(this.rbnDaNhan_CheckedChanged);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(787, 293);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 49);
            this.button2.TabIndex = 24;
            this.button2.Text = "THOÁT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTim
            // 
            this.btnTim.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTim.FlatAppearance.BorderSize = 3;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTim.Location = new System.Drawing.Point(294, 293);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(157, 51);
            this.btnTim.TabIndex = 23;
            this.btnTim.Text = "TÌM";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click_1);
            // 
            // dgvThongKeChungChi
            // 
            this.dgvThongKeChungChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvThongKeChungChi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKeChungChi.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeChungChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeChungChi.Location = new System.Drawing.Point(0, 43);
            this.dgvThongKeChungChi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThongKeChungChi.Name = "dgvThongKeChungChi";
            this.dgvThongKeChungChi.RowHeadersWidth = 51;
            this.dgvThongKeChungChi.Size = new System.Drawing.Size(1192, 296);
            this.dgvThongKeChungChi.TabIndex = 0;
            this.dgvThongKeChungChi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKeChungChi_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvThongKeChungChi);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(32, 352);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1165, 437);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.BackColor = System.Drawing.Color.White;
            this.btnInDanhSach.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInDanhSach.FlatAppearance.BorderSize = 3;
            this.btnInDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDanhSach.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInDanhSach.Location = new System.Drawing.Point(525, 290);
            this.btnInDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Size = new System.Drawing.Size(212, 60);
            this.btnInDanhSach.TabIndex = 26;
            this.btnInDanhSach.Text = "IN DANH SÁCH";
            this.btnInDanhSach.UseVisualStyleBackColor = false;
            this.btnInDanhSach.Click += new System.EventHandler(this.btnInDanhSach_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // ThongKeDanhSachChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1214, 844);
            this.Controls.Add(this.btnInDanhSach);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKeDanhSachChungChi";
            this.Text = "ThongKeDanhSachChungChi";
            this.Load += new System.EventHandler(this.ThongKeDanhSachChungChi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeChungChi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnDat;
        private System.Windows.Forms.RadioButton rbnChuaNhan;
        private System.Windows.Forms.RadioButton rbnDaNhan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvThongKeChungChi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInDanhSach;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}