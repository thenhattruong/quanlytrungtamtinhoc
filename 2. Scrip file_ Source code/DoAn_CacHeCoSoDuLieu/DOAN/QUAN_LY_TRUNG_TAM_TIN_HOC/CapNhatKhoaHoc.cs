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
    public partial class CapNhatKhoaHoc : Form
    {
        public CapNhatKhoaHoc()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();
        private void EnableInputControls(bool enable)
        {
            cbxMaKhoaHoc.Enabled = enable;
            tbxTenKhoaHoc.Enabled = enable;
            tbxGhiChu.Enabled = enable;
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
            cbxMaKhoaHoc.Text = "";
            tbxTenKhoaHoc.Text = "";
            tbxGhiChu.Text = "";
        }

        private void CapNhatKhoaHoc_Load(object sender, EventArgs e)
        {
            // HIện lên dataview
            string query = "SELECT * FROM KHOAHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatKhoaHoc.DataSource = result;
            // hiện lên ma khóa học
            string queryMaKhoaHoc = "SELECT MAKH FROM KHOAHOC";
            DataTable resultMaHocVien = sqlInstance.ExecuteQuery(queryMaKhoaHoc);

            if (resultMaHocVien != null && resultMaHocVien.Rows.Count > 0)
            {
                cbxMaKhoaHoc.DataSource = resultMaHocVien;
                cbxMaKhoaHoc.DisplayMember = "MAKH";
                cbxMaKhoaHoc.ValueMember = "MAKH";
            }
        }
        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM KHOAHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatKhoaHoc.DataSource = result;
        }

        private void dgvCapNhatKhoaHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatKhoaHoc.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string mahv = selectedRow.Cells["MAKH"].Value.ToString();
                string malop = selectedRow.Cells["TENKH"].Value.ToString();
                string hoten = selectedRow.Cells["GHICHU"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaKhoaHoc.Text = mahv;
                tbxTenKhoaHoc.Text = malop;
                tbxGhiChu.Text = hoten;
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            // Cho phép nhập mới, vô hiệu hóa sửa và xóa
            EnableInputControls(true);
            EnableButtons(false, false, false, true);
            ClearInputFields();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string makh = cbxMaKhoaHoc.Text;
            string malop = tbxTenKhoaHoc.Text;
            string hoten = tbxGhiChu.Text;

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(makh) || string.IsNullOrWhiteSpace(malop) || string.IsNullOrWhiteSpace(hoten))

            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra biến cờ để xác định xem đang ở trạng thái thêm mới hay sửa
            if (!isEditMode)
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM KHOAHOC WHERE MAKH = @MAKH", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAKH", makh);
                        int existingCount = (int)checkCommand.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("Mã khoá học đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng quá trình thêm
                        }
                    }

                    // Gọi thủ tục ThemHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("ThemKhoaHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAKH", makh);
                        command.Parameters.AddWithValue("@TENKH", malop);
                        command.Parameters.AddWithValue("@GHICHU", hoten);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm khoá học thành công!", "Thông báo", MessageBoxButtons.OKCancel);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();

                    // Gọi stored procedure CapNhatHocVien
                    using (SqlCommand command = new SqlCommand("SuaThongTinKhoaHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAKH", makh);
                        command.Parameters.AddWithValue("@TENKH", malop);
                        command.Parameters.AddWithValue("@GHICHU", hoten);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sửa thông tin khoá học thành công!", "Thông báo", MessageBoxButtons.OKCancel);
                btnSua.Enabled = true;
            }

            // Đặt lại trạng thái biến cờ
            isEditMode = false;

            // Sau khi thêm hoặc sửa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
            LoadDataGrid();
        }
        private DataRow selectedDataRow;
        private bool isEditMode = false; // Ban đầu ở trạng thái thêm mới

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaKhoaHoc.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoá học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaKhoaHoc.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaKhoaHoc", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAKH", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa khoá học thành công!", "Thông báo", MessageBoxButtons.OKCancel);

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCapNhatKhoaHoc.SelectedRows.Count > 0)
            {
                selectedDataRow = ((DataRowView)dgvCapNhatKhoaHoc.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                cbxMaKhoaHoc.Text = selectedDataRow["MAKH"].ToString();
                tbxTenKhoaHoc.Text = selectedDataRow["TENKH"].ToString();
                tbxGhiChu.Text = selectedDataRow["GHICHU"].ToString();

                // Khóa cột Mã học viên và số biên lai để không cho sửa
                cbxMaKhoaHoc.Enabled = false;

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
    }
}
