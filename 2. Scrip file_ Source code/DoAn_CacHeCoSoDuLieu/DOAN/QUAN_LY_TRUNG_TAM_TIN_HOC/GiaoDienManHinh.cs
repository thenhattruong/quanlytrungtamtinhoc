using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    public partial class GiaoDienManHinh : Form
    {
        public GiaoDienManHinh()
        {
            InitializeComponent();
            panel.Size = this.ClientSize;
            panel.Dock = DockStyle.Fill;
      
        }
        public void HideSomeFunctionalities()
        {
            // Lặp qua các item con bên trong menuCapNhat và ẩn đi
            foreach (ToolStripMenuItem item in menuCapNhat.DropDownItems)
            {
                // Kiểm tra tên của item và ẩn nếu cần
                if (item.Name == "ItemLopHoc" || item.Name == "ItemPhongHoc" || item.Name == "ItemGiaoVien" || item.Name == "ItemKhoaHoc")
                {
                    item.Enabled = false;
                }
            }
        }
        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThayDoiMatKhau thayDoiMatKhau = new ThayDoiMatKhau();
            this.Hide();
            thayDoiMatKhau.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Hide();
            dangNhap.Show();
        }

        private void họcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatHocVien capNhatHocVien = new CapNhatHocVien();
            capNhatHocVien.TopLevel = false;
            capNhatHocVien.FormBorderStyle = FormBorderStyle.None;
            capNhatHocVien.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatHocVien);
            capNhatHocVien.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatHocVien.Size = panel.Size;
            capNhatHocVien.Show();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatDiem capNhatDiem = new CapNhatDiem();
            capNhatDiem.TopLevel = false;
            capNhatDiem.FormBorderStyle = FormBorderStyle.None;
            capNhatDiem.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatDiem);
            capNhatDiem.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatDiem.Size = panel.Size;
            capNhatDiem.Show();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatLopHoc capNhatLopHoc = new CapNhatLopHoc();
            capNhatLopHoc.TopLevel = false;
            capNhatLopHoc.FormBorderStyle = FormBorderStyle.None;
            capNhatLopHoc.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatLopHoc);
            capNhatLopHoc.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatLopHoc.Size = panel.Size;
            capNhatLopHoc.Show();
        }

        private void khóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatKhoaHoc capNhatKhoaHoc = new CapNhatKhoaHoc();
            capNhatKhoaHoc.TopLevel = false;
            capNhatKhoaHoc.FormBorderStyle = FormBorderStyle.None;
            capNhatKhoaHoc.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatKhoaHoc);
            capNhatKhoaHoc.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatKhoaHoc.Size = panel.Size;
            capNhatKhoaHoc.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatGiaoVien capNhatGiaoVien = new CapNhatGiaoVien();
            capNhatGiaoVien.TopLevel = false;
            capNhatGiaoVien.FormBorderStyle = FormBorderStyle.None;
            capNhatGiaoVien.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatGiaoVien);
            capNhatGiaoVien.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatGiaoVien.Size = panel.Size;
            capNhatGiaoVien.Show();
        }

        private void phòngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatPhongHoc capNhatPhongHoc = new CapNhatPhongHoc();
            capNhatPhongHoc.TopLevel = false;
            capNhatPhongHoc.FormBorderStyle = FormBorderStyle.None;
            capNhatPhongHoc.Dock = DockStyle.Fill;
            panel.Controls.Add(capNhatPhongHoc);
            capNhatPhongHoc.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            capNhatPhongHoc.Size = panel.Size;
            capNhatPhongHoc.Show();
        }

        private void họcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            TimKiemHocVien timKiemHocVien = new TimKiemHocVien();
            timKiemHocVien.TopLevel = false;
            timKiemHocVien.FormBorderStyle = FormBorderStyle.None;
            timKiemHocVien.Dock = DockStyle.Fill;
            panel.Controls.Add(timKiemHocVien);
            timKiemHocVien.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            timKiemHocVien.Size = panel.Size;
            timKiemHocVien.Show();
        }

        private void giáoViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            TimKiemGiaoVien timKiemGiaoVien = new TimKiemGiaoVien();
            timKiemGiaoVien.TopLevel = false;
            timKiemGiaoVien.FormBorderStyle = FormBorderStyle.None;
            timKiemGiaoVien.Dock = DockStyle.Fill;
            panel.Controls.Add(timKiemGiaoVien);
            timKiemGiaoVien.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            timKiemGiaoVien.Size = panel.Size;
            timKiemGiaoVien.Show();
        }

        private void danhSáchKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            TimKiemDiem timKiemDiem = new TimKiemDiem();
            timKiemDiem.TopLevel = false;
            timKiemDiem.FormBorderStyle = FormBorderStyle.None;
            timKiemDiem.Dock = DockStyle.Fill;
            panel.Controls.Add(timKiemDiem);
            timKiemDiem.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            timKiemDiem.Size = panel.Size;
            timKiemDiem.Show();
        }

        private void danhSáchLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            ThongKeDanhSachLop thongKeDanhSachLop = new ThongKeDanhSachLop();
            thongKeDanhSachLop.TopLevel = false;
            thongKeDanhSachLop.FormBorderStyle = FormBorderStyle.None;
            thongKeDanhSachLop.Dock = DockStyle.Fill;
            panel.Controls.Add(thongKeDanhSachLop);
            thongKeDanhSachLop.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            thongKeDanhSachLop.Size = panel.Size;
            thongKeDanhSachLop.Show();
        }

        private void danhSáchĐạtChứngChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            ThongKeDanhSachChungChi thongKeDanhSachChungChi = new ThongKeDanhSachChungChi();
            thongKeDanhSachChungChi.TopLevel = false;
            thongKeDanhSachChungChi.FormBorderStyle = FormBorderStyle.None;
            thongKeDanhSachChungChi.Dock = DockStyle.Fill;
            panel.Controls.Add(thongKeDanhSachChungChi);
            thongKeDanhSachChungChi.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            thongKeDanhSachChungChi.Size = panel.Size;
            thongKeDanhSachChungChi.Show();
        }

        private void danhSáchThiLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            ThongKeDanhSachThiLai thongKeDanhSachThiLai = new ThongKeDanhSachThiLai();
            thongKeDanhSachThiLai.TopLevel = false;
            thongKeDanhSachThiLai.FormBorderStyle = FormBorderStyle.None;
            thongKeDanhSachThiLai.Dock = DockStyle.Fill;
            panel.Controls.Add(thongKeDanhSachThiLai);
            thongKeDanhSachThiLai.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            thongKeDanhSachThiLai.Size = panel.Size;
            thongKeDanhSachThiLai.Show();
        }

        private void điểmHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            ThongKeDiemHocVien thongKeDiemHocVien = new ThongKeDiemHocVien();
            thongKeDiemHocVien.TopLevel = false;
            thongKeDiemHocVien.FormBorderStyle = FormBorderStyle.None;
            thongKeDiemHocVien.Dock = DockStyle.Fill;
            panel.Controls.Add(thongKeDiemHocVien);
            thongKeDiemHocVien.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            thongKeDiemHocVien.Size = panel.Size;
            thongKeDiemHocVien.Show();
        }

        private void điểmLớpHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            ThongKeDiemLop thongKeDiemLop = new ThongKeDiemLop();
            thongKeDiemLop.TopLevel = false;
            thongKeDiemLop.FormBorderStyle = FormBorderStyle.None;
            thongKeDiemLop.Dock = DockStyle.Fill;
            panel.Controls.Add(thongKeDiemLop);
            thongKeDiemLop.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            thongKeDiemLop.Size = panel.Size;
            thongKeDiemLop.Show();
        }

        private void inBiênLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            InBienLai inBienLai = new InBienLai();
            inBienLai.TopLevel = false;
            inBienLai.FormBorderStyle = FormBorderStyle.None;
            inBienLai.Dock = DockStyle.Fill;
            panel.Controls.Add(inBienLai);
            inBienLai.Location = new Point(0, 0); // Đặt vị trí Form2 trong Panel tại góc trên bên trái
            inBienLai.Size = panel.Size;
            inBienLai.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GiaoDienManHinh_Load(object sender, EventArgs e)
        {

        }
    }
}
