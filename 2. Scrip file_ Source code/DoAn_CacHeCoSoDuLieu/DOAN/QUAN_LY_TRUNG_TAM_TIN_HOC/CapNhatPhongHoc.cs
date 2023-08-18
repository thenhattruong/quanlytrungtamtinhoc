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
    public partial class CapNhatPhongHoc : Form
    {
        public CapNhatPhongHoc()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();
        private void EnableInputControls(bool enable)
        {
            cbxMaPhongHoc.Enabled = enable;
            tbxTenPhongHoc.Enabled = enable;
            tbxTinhTrang.Enabled = enable;
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
            cbxMaPhongHoc.Text = "";
            tbxTenPhongHoc.Text = "";
            tbxTinhTrang.Text = "";
        }
        private void CapNhatPhongHoc_Load(object sender, EventArgs e)
        {
            // HIện lên dataview
            string query = "SELECT * FROM PHONGHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatPhongHoc.DataSource = result;
            // hiện lên mahocvien
            string queryMaHocVien = "SELECT MAPHONG FROM PHONGHOC";
            DataTable resultMaHocVien = sqlInstance.ExecuteQuery(queryMaHocVien);

            if (resultMaHocVien != null && resultMaHocVien.Rows.Count > 0)
            {
                cbxMaPhongHoc.DataSource = resultMaHocVien;
                cbxMaPhongHoc.DisplayMember = "MAPHONG";
                cbxMaPhongHoc.ValueMember = "MAPHONG";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị các nút và cho phép sửa, xóa, nhập mới
            EnableButtons(true, true, true, true);
            // xóa sạch dữ liệu đang hiện
            ClearInputFields();
        }

        private void dgvCapNhatKhoaHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatPhongHoc.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string mahv = selectedRow.Cells["MAPHONG"].Value.ToString();
                string malop = selectedRow.Cells["TENPHONG"].Value.ToString();
                string hoten = selectedRow.Cells["TINHTRANG"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaPhongHoc.Text = mahv;
                tbxTenPhongHoc.Text = malop;
                tbxTinhTrang.Text = hoten;
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            // Cho phép nhập mới, vô hiệu hóa sửa và xóa
            EnableInputControls(true);
            EnableButtons(false, false, false, true);
            ClearInputFields();
        }
        private DataRow selectedDataRow;
        private bool isEditMode = false; // Ban đầu ở trạng thái thêm mới
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string maphong = cbxMaPhongHoc.Text;
            string tenphong = tbxTenPhongHoc.Text;
            string tinhtrang = tbxTinhTrang.Text;

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(maphong) || string.IsNullOrWhiteSpace(tenphong) || string.IsNullOrWhiteSpace(tinhtrang))

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
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM PHONGHOC WHERE MAPHONG = @MAPHONG", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAPHONG", maphong);
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Mã phòng học đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng quá trình thêm
                        }
                    }

                    // Gọi thủ tục ThemHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("ThemPhongHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhong", maphong);
                        command.Parameters.AddWithValue("@TenPhong", tenphong);
                        command.Parameters.AddWithValue("@TinhTrang", tinhtrang);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm phòng học thành công!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();

                    // Gọi stored procedure CapNhatHocVien
                    using (SqlCommand command = new SqlCommand("SuaThongTinPhongHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhong", maphong);
                        command.Parameters.AddWithValue("@TenPhong", tenphong);
                        command.Parameters.AddWithValue("@TinhTrang", tinhtrang);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sửa thông tin phòng học thành công!");
                btnSua.Enabled = true;
            }
            // Đặt lại trạng thái biến cờ
            isEditMode = false;

            // Sau khi thêm hoặc sửa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM PHONGHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatPhongHoc.DataSource = result;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCapNhatPhongHoc.SelectedRows.Count > 0)
            {
                selectedDataRow = ((DataRowView)dgvCapNhatPhongHoc.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                tbxTenPhongHoc.Text = selectedDataRow["TenPhong"].ToString();
                tbxTinhTrang.Text = selectedDataRow["TinhTrang"].ToString();

                // Khóa cột Mã học viên và số biên lai để không cho sửa
                cbxMaPhongHoc.Enabled = false;

                // Hiển thị nút Lưu và ẩn nút Sửa
                btnLuu.Enabled = true;
                btnSua.Enabled = false;

                // Đặt biến cờ vào trạng thái sửa
                isEditMode = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaPhongHoc.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaPhongHoc.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaPhongHoc", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhong", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa phòng học thành công!");

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }
    }
}
