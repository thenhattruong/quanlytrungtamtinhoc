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
    public partial class TimKiemDiem : Form
    {
        private SQL sqlInstance = SQL.GetInstance();

        public TimKiemDiem()
        {
            InitializeComponent();
        }

        private void cbxMaHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rbnMaHocVien.Checked)
            {
                string MAHV = cbxMaHocVien.Text;
                DataTable resultData = sqlInstance.ExecuteQuery($"SELECT * FROM TimDiemHocVienTheoMaHocVien('{MAHV}')");
                dgvTimKiemDiem.DataSource = resultData;
            }
            else if (rbnMaLop.Checked)
            {
                string maLop = cbxMaLop.Text;
                DataTable resultData = sqlInstance.ExecuteQuery($"SELECT * FROM TimDiemHocVienTheoLop('{maLop}')");
                dgvTimKiemDiem.DataSource = resultData;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTimKiemDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbnMaHocVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnMaHocVien.Checked)
            {
                // Load dữ liệu mã học viên vào combobox
                DataTable maHocVienData = sqlInstance.ExecuteQuery("SELECT DISTINCT MAHV FROM HOCVIEN");
                cbxMaHocVien.DataSource = maHocVienData;
                cbxMaHocVien.DisplayMember = "MAHV";
            }
            else
            {
                // Xóa dữ liệu khỏi combobox khi không được chọn
                cbxMaHocVien.DataSource = null;
            }
        }

        private void rbnMaLop_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnMaLop.Checked)
            {
                // Load dữ liệu mã lớp vào combobox
                DataTable maLopData = sqlInstance.ExecuteQuery("SELECT DISTINCT MALOP FROM HOCVIEN");
                cbxMaLop.DataSource = maLopData;
                cbxMaLop.DisplayMember = "MALOP";
            }
            else
            {
                // Xóa dữ liệu khỏi combobox khi không được chọn
                cbxMaLop.DataSource = null;
            }
        }
    }
}
