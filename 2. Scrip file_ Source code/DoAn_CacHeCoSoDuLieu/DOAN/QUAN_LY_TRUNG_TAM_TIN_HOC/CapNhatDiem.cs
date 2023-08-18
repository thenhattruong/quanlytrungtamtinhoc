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
    public partial class CapNhatDiem : Form
    {
        private SQL sqlInstance = SQL.GetInstance();
        public CapNhatDiem()
        {
            InitializeComponent();
        }

        private void EnableInputControls(bool enable)
        {
            cbxMaHocVien.Enabled = enable;
            cbxMaKhoaHoc.Enabled = enable;
            cbxMaLop.Enabled = enable;
            tbxDiemQT.Enabled = enable;
            tbxDiemGK.Enabled = enable;
            tbxDiemCK.Enabled = enable;
            radioButton1.Enabled = enable;
            radioButton2.Enabled = enable;
        }

        private void EnableButtons(bool themMoi, bool sua, bool xoa, bool luu)
        {
            btnNhapMoi.Enabled = themMoi;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
            btnLuu.Enabled = luu;
        }

        private void ClearInputFields()
        {
            cbxMaHocVien.Text = "";
            cbxMaKhoaHoc.Text = "";
            cbxMaLop.Text = "";
            tbxDiemQT.Text = "";
            tbxDiemGK.Text = "";
            tbxDiemCK.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
        }

        private void CapNhatDiem_Load(object sender, EventArgs e)
        {
            // HIện lên dataview
            string query = "SELECT * FROM DIEM";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatDiem.DataSource = result;
            // hiện lên mahocvien
            string queryMaHocVien = "SELECT MAHV FROM DIEM";
            DataTable resultMaHocVien = sqlInstance.ExecuteQuery(queryMaHocVien);

            if (resultMaHocVien != null && resultMaHocVien.Rows.Count > 0)
            {
                cbxMaHocVien.DataSource = resultMaHocVien;
                cbxMaHocVien.DisplayMember = "MAHV";
                cbxMaHocVien.ValueMember = "MAHV";
            }
            // hiện lên malop
            string queryMaLop = "SELECT MaLop FROM LOPHOC";
            DataTable resultMaLop = sqlInstance.ExecuteQuery(queryMaLop);

            if (resultMaLop.Rows.Count > 0)
            {
                cbxMaLop.DataSource = resultMaLop;
                cbxMaLop.DisplayMember = "MaLop";
                cbxMaLop.ValueMember = "MaLop";
            }
            // hiện lên khoahoc
            string queryMaKH = "SELECT MaKH FROM KHOAHOC";
            DataTable resultMaKH = sqlInstance.ExecuteQuery(queryMaKH);

            if (resultMaKH.Rows.Count > 0)
            {
                cbxMaKhoaHoc.DataSource = resultMaKH;
                cbxMaKhoaHoc.DisplayMember = "MaKH";
                cbxMaKhoaHoc.ValueMember = "MaKH";
            }
        }

        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM DIEM";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatDiem.DataSource = result;
        }

        
        private void tbxGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tbxTongDiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tbxDiemCK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbxMaKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbxDiemGK_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxDiemQT_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaHocVien.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm của học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaHocVien.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaDiemHocVien", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa điểm của học viên thành công!");

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }

      
        private DataRow selectedDataRow;
        private bool isEditMode = false; // Ban đầu ở trạng thái thêm mới

        private void dgvCapNhatDiem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatDiem.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string mahv = selectedRow.Cells["MAHV"].Value.ToString();
                string khoahoc = selectedRow.Cells["MAKH"].Value.ToString();
                string malop = selectedRow.Cells["MALOP"].Value.ToString();
                string diemqt = selectedRow.Cells["DIEMQT"].Value.ToString();
                string diemgk = selectedRow.Cells["DIEMGK"].Value.ToString();
                string diemck = selectedRow.Cells["DIEMCK"].Value.ToString();
                string tongdiem = selectedRow.Cells["TONGDIEM"].Value.ToString();
                string xeploai = selectedRow.Cells["XEPLOAI"].Value.ToString();
                string ghichu = selectedRow.Cells["GHICHU"].Value.ToString();
                string tinhtrang = selectedRow.Cells["TINHTRANG"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaHocVien.Text = mahv;
                cbxMaKhoaHoc.Text = khoahoc;
                cbxMaLop.Text = malop;
                tbxDiemQT.Text = diemqt;
                tbxDiemGK.Text = diemgk;
                tbxDiemCK.Text = diemck;

                if (tinhtrang == "đã nhận")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string mahv = cbxMaHocVien.Text;
            string khoahoc = cbxMaKhoaHoc.Text;
            string malop = cbxMaLop.Text;
            string diemqt = tbxDiemQT.Text;
            string diemgk = tbxDiemGK.Text;
            string diemck = tbxDiemCK.Text;
            string tinhtrang = radioButton1.Checked ? "1" : "0"; // Đã nhận: 1, Chưa nhận: 0

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(mahv) || string.IsNullOrWhiteSpace(khoahoc) || string.IsNullOrWhiteSpace(malop)
                || string.IsNullOrWhiteSpace(diemqt) || string.IsNullOrWhiteSpace(diemgk) || string.IsNullOrWhiteSpace(diemck))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (float.TryParse(diemqt, out float parsedDiemQT) &&
                float.TryParse(diemgk, out float parsedDiemGK) &&
                float.TryParse(diemck, out float parsedDiemCK))
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(isEditMode ? "SuaDiemHocVien" : "ThemDiemHocVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);
                        command.Parameters.AddWithValue("@MAKH", khoahoc);
                        command.Parameters.AddWithValue("@MALOP", malop);
                        command.Parameters.AddWithValue("@DIEMQT", parsedDiemQT);
                        command.Parameters.AddWithValue("@DIEMGK", parsedDiemGK);
                        command.Parameters.AddWithValue("@DIEMCK", parsedDiemCK);
                        command.Parameters.AddWithValue("@TINHTRANG", tinhtrang);

                        if (isEditMode)
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Sửa thông tin điểm thành công!", "Thông báo", MessageBoxButtons.OK);
                            btnSua.Enabled = true;
                        }
                        else
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Thêm điểm thất bại!", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                    }
                }

                // Đặt lại trạng thái biến cờ
                isEditMode = false;

                // Sau khi thêm hoặc sửa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNhapMoi_Click_1(object sender, EventArgs e)
        {          
                // Cho phép nhập mới, vô hiệu hóa sửa và xóa
                EnableInputControls(true);
                EnableButtons(false, false, false, true);
                ClearInputFields();

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (cbxMaHocVien.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm của học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaHocVien.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaDiemHocVien", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }
                    MessageBox.Show("Xóa điểm của học viên thành công!", "Thông báo", MessageBoxButtons.OK);


                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
             if (dgvCapNhatDiem.SelectedRows.Count > 0)
                {
                selectedDataRow = ((DataRowView)dgvCapNhatDiem.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                cbxMaKhoaHoc.Text = selectedDataRow["MAKH"].ToString();
                cbxMaLop.Text = selectedDataRow["MALOP"].ToString();
                tbxDiemQT.Text = selectedDataRow["DIEMQT"].ToString(); ;
                tbxDiemGK.Text = selectedDataRow["DIEMGK"].ToString();
                tbxDiemCK.Text = selectedDataRow["DIEMCK"].ToString();

                // Khóa cột Mã học viên và số biên lai để không cho sửa
                cbxMaHocVien.Enabled = false;

                // Hiển thị nút Lưu và ẩn nút Sửa
                btnLuu.Enabled = true;
                btnSua.Enabled = false;

                // Đặt biến cờ vào trạng thái sửa
                isEditMode = true;
             }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị các nút và cho phép sửa, xóa, nhập mới
            EnableButtons(true, true, true, true);
            // xóa sạch dữ liệu đang hiện
            ClearInputFields();
        }

        private void tbxDiemQT_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
    
}
