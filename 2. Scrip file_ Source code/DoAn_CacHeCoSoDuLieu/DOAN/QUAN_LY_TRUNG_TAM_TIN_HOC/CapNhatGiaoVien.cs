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
    public partial class CapNhatGiaoVien : Form
    {
        public CapNhatGiaoVien()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();
        private void EnableInputControls(bool enable)
        {
            cbxMaGiaoVien.Enabled = enable;
            tbxHoVaTen.Enabled = enable;
            dtpNgaySinh.Enabled = enable;
            tbxDiaChi.Enabled = enable;
            tbxDienThoai.Enabled = enable;
            tbxTrinhDo.Enabled = enable;
            rbnNam.Enabled = enable;
            rbnNu.Enabled = enable;
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
            cbxMaGiaoVien.Text = "";
            tbxHoVaTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            tbxDiaChi.Text = "";
            tbxDienThoai.Text = "";
            tbxTrinhDo.Text = "";
            rbnNam.Checked = true;
            rbnNu.Checked = false;
        }

        private void CapNhatGiaoVien_Load(object sender, EventArgs e)
        {
            // HIện lên dataview
            string query = "SELECT * FROM GIAOVIEN";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatGiaoVien.DataSource = result;
            // hiện lên magiaovien
            string queryMaGiaoVien = "SELECT MAGV FROM GIAOVIEN";
            DataTable resultMaGiaoVien = sqlInstance.ExecuteQuery(queryMaGiaoVien);

            if (resultMaGiaoVien != null && resultMaGiaoVien.Rows.Count > 0)
            {
                cbxMaGiaoVien.DataSource = resultMaGiaoVien;
                cbxMaGiaoVien.DisplayMember = "MAGV";
                cbxMaGiaoVien.ValueMember = "MAGV";
            }
        }
        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM GIAOVIEN";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatGiaoVien.DataSource = result;
        }

        private DataRow selectedDataRow;
        private bool isEditMode = false; // Ban đầu ở trạng thái thêm mới

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
            string magv = cbxMaGiaoVien.Text;
            string hoten = tbxHoVaTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string diachi = tbxDiaChi.Text;
            string dienthoai = tbxDienThoai.Text;
            string trinhdo = tbxTrinhDo.Text;
            string gioitinh = rbnNam.Checked ? "Nam" : "Nữ";
            if (ngaysinh.Date == DateTime.Today.Date)
            {
                MessageBox.Show("Ngày sinh của giáo viên không được bằng ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(magv) || string.IsNullOrWhiteSpace(hoten)
                || string.IsNullOrWhiteSpace(diachi) || string.IsNullOrWhiteSpace(dienthoai) || string.IsNullOrWhiteSpace(trinhdo)
                || string.IsNullOrWhiteSpace(gioitinh))
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
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM GIAOVIEN WHERE MAGV = @MAGV", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAGV", magv);
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Mã giáo viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng quá trình thêm
                        }
                    }

                    // Gọi thủ tục ThemHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("ThemGiaoVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAGV", magv);
                        command.Parameters.AddWithValue("@HOTEN", hoten);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        command.Parameters.AddWithValue("@DIACHI", diachi);
                        command.Parameters.AddWithValue("@DIENTHOAI", dienthoai);
                        command.Parameters.AddWithValue("@TRINHDO", trinhdo);
                        command.Parameters.AddWithValue("@GIOITINH", gioitinh);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OKCancel);

            }
            else
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();

                    // Gọi stored procedure CapNhatHocVien
                    using (SqlCommand command = new SqlCommand("SuaThongTinGiaoVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAGV", magv);
                        command.Parameters.AddWithValue("@HOTEN", hoten);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        command.Parameters.AddWithValue("@DIACHI", diachi);
                        command.Parameters.AddWithValue("@DIENTHOAI", dienthoai);
                        command.Parameters.AddWithValue("@TRINHDO", trinhdo);
                        command.Parameters.AddWithValue("@GIOITINH", gioitinh);
                    }
                }
                MessageBox.Show("Sửa thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OKCancel);

                btnSua.Enabled = true;
            }

            // Đặt lại trạng thái biến cờ
            isEditMode = false;

            // Sau khi thêm hoặc sửa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
            LoadDataGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCapNhatGiaoVien.SelectedRows.Count > 0)
            {
                selectedDataRow = ((DataRowView)dgvCapNhatGiaoVien.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                tbxHoVaTen.Text = selectedDataRow["HOTEN"].ToString();
                dtpNgaySinh.Value = DateTime.Parse(selectedDataRow["NGAYSINH"].ToString());
                tbxDiaChi.Text = selectedDataRow["DIACHI"].ToString();
                tbxDienThoai.Text = selectedDataRow["DIENTHOAI"].ToString();
                tbxTrinhDo.Text = selectedDataRow["TRINHDO"].ToString();
                // Không hiển thị số biên lai vì nó không được sửa

                if (selectedDataRow["GIOITINH"].ToString() == "Nam")
                {
                    rbnNam.Checked = true;
                    rbnNu.Checked = false;
                }
                else
                {
                    rbnNam.Checked = false;
                    rbnNu.Checked = true;
                }

                // Khóa cột Mã học viên và số biên lai để không cho sửa
                cbxMaGiaoVien.Enabled = false;

                // Hiển thị nút Lưu và ẩn nút Sửa
                btnLuu.Enabled = true;
                btnSua.Enabled = false;

                // Đặt biến cờ vào trạng thái sửa
                isEditMode = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaGiaoVien.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giáo viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string magv = cbxMaGiaoVien.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaGiaoVien", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAGV", magv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa giáo viên thành công!", "Thông báo", MessageBoxButtons.OKCancel);

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }

        private void dgvCapNhatGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatGiaoVien.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string magv = selectedRow.Cells["MAGV"].Value.ToString();
                string hoten = selectedRow.Cells["HOTEN"].Value.ToString();
                string ngaysinh = selectedRow.Cells["NGAYSINH"].Value.ToString();
                string diachi = selectedRow.Cells["DIACHI"].Value.ToString();
                string dienthoai = selectedRow.Cells["DIENTHOAI"].Value.ToString();
                string trinhdo = selectedRow.Cells["TRINHDO"].Value.ToString();
                string gioitinh = selectedRow.Cells["GIOITINH"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaGiaoVien.Text = magv;
                tbxHoVaTen.Text = hoten;
                dtpNgaySinh.Value = DateTime.Parse(ngaysinh);
                tbxDiaChi.Text = diachi;
                tbxDienThoai.Text = dienthoai;
                tbxTrinhDo.Text = trinhdo;

                if (gioitinh == "Nam")
                {
                    rbnNam.Checked = true;
                    rbnNu.Checked = false;
                }
                else
                {
                    rbnNam.Checked = false;
                    rbnNu.Checked = true;
                }
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

