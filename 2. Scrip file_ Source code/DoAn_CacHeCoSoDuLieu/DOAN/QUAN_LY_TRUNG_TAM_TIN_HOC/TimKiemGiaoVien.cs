using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_TRUNG_TAM_TIN_HOC
{
    public partial class TimKiemGiaoVien : Form
    {
        public TimKiemGiaoVien()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();

        private void rbnMaGiaoVien_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnTenGiaoVien_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbxThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = tbxThongTinTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Hãy nhập thông tin tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable result = new DataTable();

                if (rbnMaGiaoVien.Checked)
                {
                    string query = $"SELECT * FROM dbo.TimKiemGiaoVienTheoMa('{searchText}')";
                    result = sqlInstance.ExecuteQuery(query);
                }
                else if (rbnTenGiaoVien.Checked)
                {
                    string query = $"SELECT * FROM dbo.TimKiemGiaoVienTheoTen(N'{searchText}')";
                    result = sqlInstance.ExecuteQuery(query);
                }

                dgvTimKiemGiaoVien.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvTimKiemGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimKiemGiaoVien_Load(object sender, EventArgs e)
        {

        }
    }
}
