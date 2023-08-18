using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    public partial class DangNhap : Form
    {
        private SQL sqlInstance = SQL.GetInstance();
        public DangNhap()
        {
            InitializeComponent();
            checkBoxHienMatKhau.CheckedChanged += checkBox1_CheckedChanged;

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
        private MenuStrip menuCapNhat; // Khai báo biến menuCapNhat trong lớp

        // ...

        public void SomeMethod()
        {
            menuCapNhat = new MenuStrip(); // Gán giá trị cho biến menuCapNhat
        }
        
        private bool CheckLoginCredentials(string username, string password, string userType)
        {
            // Thực hiện kiểm tra thông tin đăng nhập ở đây
            if (userType == "rbnAdmin")
            {
                if ((username == "admin1" || username == "admin2" || username == "admin3") && password == "456")
                {
                    return true; // Đăng nhập thành công cho tài khoản admin
                }
            }
            else if (userType == "rbnGiaoVien")
            {
                if (username == "gv01" && password == "123")
                {
                    return true; // Đăng nhập thành công cho tài khoản giáo viên
                }
            }

            return false; // Đăng nhập không thành công
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userType = rbnAdmin.Checked ? "rbnAdmin" : "rbnGiaoVien";
            string username = tbxMaNhanVien.Text;
            string password = tbxMatKhau.Text;

            bool loginSuccess = CheckLoginCredentials(username, password, userType);

            if (loginSuccess)
            {
                GiaoDienManHinh giaoDienManHinh = new GiaoDienManHinh();

                if (userType == "rbnAdmin")
                {
                    this.Hide();
                    giaoDienManHinh.ShowDialog();
                }
                else if (userType == "rbnGiaoVien")
                {
                    // Ẩn các chức năng không cần thiết ở form giaoDienManHinh dành cho giáo viên
                    giaoDienManHinh.HideSomeFunctionalities(); // Ẩn các chức năng không cần thiết ở form giaoDienManHinh dành cho giáo viên
                    this.Hide();
                    giaoDienManHinh.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra tên đăng nhập và mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem checkbox đã được chọn hay chưa
            if (checkBoxHienMatKhau.Checked)
            {
                // Nếu đã được chọn, hiển thị mật khẩu thay thế cho dấu '*'
                tbxMatKhau.PasswordChar = '\0'; // '\0' là ký tự null, khi đặt PasswordChar thành '\0', textbox sẽ hiển thị mật khẩu thường thay vì dấu '*'
            }
            else
            {
                // Nếu không được chọn, ẩn mật khẩu bằng dấu '*'
                tbxMatKhau.PasswordChar = '*'; // Đặt lại PasswordChar để hiển thị dấu '*' cho mật khẩu
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rbnAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnGiaoVien_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
