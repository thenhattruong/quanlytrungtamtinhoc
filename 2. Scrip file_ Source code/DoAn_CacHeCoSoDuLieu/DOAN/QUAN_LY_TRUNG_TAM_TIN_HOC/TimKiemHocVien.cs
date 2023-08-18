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

    public partial class TimKiemHocVien : Form
    {
        private SQL sqlInstance = SQL.GetInstance();

        public TimKiemHocVien()
        {
            InitializeComponent();
        }

        private void btnTimKem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = tbxTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Hãy nhập thông tin tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable result = new DataTable();

                if (rbnMaHocVien.Checked)
                {
                    string query = $"SELECT * FROM dbo.TimHocVienTheoMaHV('{searchText}')";
                    result = sqlInstance.ExecuteQuery(query);
                }
                else if (rbnTenHocVien.Checked)
                {
                    string query = $"SELECT * FROM dbo.TimKiemHocVienTheoTen(N'{searchText}')";
                    result = sqlInstance.ExecuteQuery(query);
                }

                dgvTimKiemHocVien.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxTimKiem_TextChanged(object sender, EventArgs e)
       {

        }

        private void rbnDanhSachHocVienDatChungChi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnDanhSachHocVienThiLai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnTenHocVien_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rbnMaHocVien_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvTimKiemHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnHuongDanTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nếu tìm bằng mã học viên thì chọn vào ô và nhập mã học viên VD: HV01, HV02. \n Nếu tìm bằng tên học viên thì nhập tên học viên vào VD: Nguyễn Văn A", "Hướng dẫn tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

