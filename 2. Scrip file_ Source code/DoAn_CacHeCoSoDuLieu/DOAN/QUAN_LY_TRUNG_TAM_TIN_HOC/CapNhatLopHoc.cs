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
    public partial class CapNhatLopHoc : Form
    {
        public CapNhatLopHoc()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();
        private void EnableInputControls(bool enable)
        {
            cbxMaLop.Enabled = enable;
            tbxSiSo.Enabled = enable;
            cbxMaphong.Enabled = enable;
            cbxMagiaovien.Enabled = enable;
            cbxMaKhoaHoc.Enabled = enable;
            tbxCahoc.Enabled = enable;
            dtpNgaybatdau.Enabled = enable;
            dtpNgayketthuc.Enabled = enable;
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
            cbxMaLop.Text = "";
            tbxSiSo.Text = "";
            cbxMaphong.Text = "";
            cbxMagiaovien.Text = "";
            cbxMaKhoaHoc.Text = "";
            tbxCahoc.Text = "";
            dtpNgaybatdau.Value = DateTime.Now;
            dtpNgayketthuc.Value = DateTime.Now;
        }

        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM LOPHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatLopHoc.DataSource = result;
        }

        private void CapNhatLopHoc_Load(object sender, EventArgs e)
        {
            // Hiện lên dataview
            string query = "SELECT * FROM LOPHOC";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatLopHoc.DataSource = result;

            // Hiển thị mã lớp
            string queryMaLop = "SELECT MALOP FROM LOPHOC";
            DataTable resultMaLop = sqlInstance.ExecuteQuery(queryMaLop);

            if (resultMaLop != null && resultMaLop.Rows.Count > 0)
            {
                cbxMaLop.DataSource = resultMaLop;
                cbxMaLop.DisplayMember = "MALOP";
                cbxMaLop.ValueMember = "MALOP";
            }

            // Hiển thị mã phòng
            string queryMaPhong = "SELECT MAPHONG FROM PHONGHOC";
            DataTable resultMaPhong = sqlInstance.ExecuteQuery(queryMaPhong);

            if (resultMaPhong != null && resultMaPhong.Rows.Count > 0)
            {
                cbxMaphong.DataSource = resultMaPhong;
                cbxMaphong.DisplayMember = "MAPHONG";
                cbxMaphong.ValueMember = "MAPHONG";
            }

            // Hiển thị mã giáo viên
            string queryMaGiaoVien = "SELECT MAGV FROM GIAOVIEN";
            DataTable resultMaGiaoVien = sqlInstance.ExecuteQuery(queryMaGiaoVien);

            if (resultMaGiaoVien != null && resultMaGiaoVien.Rows.Count > 0)
            {
                cbxMagiaovien.DataSource = resultMaGiaoVien;
                cbxMagiaovien.DisplayMember = "MAGV";
                cbxMagiaovien.ValueMember = "MAGV";
            }

            // Hiển thị mã khóa học
            string queryMaKhoaHoc = "SELECT MAKH FROM KHOAHOC";
            DataTable resultMaKhoaHoc = sqlInstance.ExecuteQuery(queryMaKhoaHoc);

            if (resultMaKhoaHoc != null && resultMaKhoaHoc.Rows.Count > 0)
            {
                cbxMaKhoaHoc.DataSource = resultMaKhoaHoc;
                cbxMaKhoaHoc.DisplayMember = "MAKH";
                cbxMaKhoaHoc.ValueMember = "MAKH";
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
            string mahv = cbxMaLop.Text;
            string malop = tbxSiSo.Text;
            string hoten = cbxMaphong.Text;
            string diachi = cbxMagiaovien.Text;
            string nghenghiep = cbxMaKhoaHoc.Text;
            string tinhtrang = tbxCahoc.Text;
            DateTime ngaybatdau = dtpNgaybatdau.Value;
            DateTime ngayketthuc = dtpNgayketthuc.Value;

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(mahv) || string.IsNullOrWhiteSpace(malop) || string.IsNullOrWhiteSpace(hoten)
                || string.IsNullOrWhiteSpace(diachi) || string.IsNullOrWhiteSpace(nghenghiep) || string.IsNullOrWhiteSpace(tinhtrang))
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
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM LOPHOC WHERE MALOP = @MALOP", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MALOP", mahv);
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Mã lớp học đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng quá trình thêm
                        }
                    }
                    
                    // Kiểm tra xem ca học có nằm trong khoảng quy định không
                    using (SqlCommand checkCaHocCommand = new SqlCommand("SELECT COUNT(*) FROM LOPHOC WHERE CAHOC = @CAHOC", connection))
                    {
                        checkCaHocCommand.Parameters.AddWithValue("@CAHOC", tinhtrang);
                        int caHocCount = (int)checkCaHocCommand.ExecuteScalar();

                        if (caHocCount == 0)
                        {
                            MessageBox.Show("Ca học không hợp lệ. Ca học phải nằm trong khoảng từ sáng thứ 2 đến tối chủ nhật.Và phải viết hoa chữ cái đầu tiên khi nhập vào", "Lỗi", MessageBoxButtons.OK);
                            return; // Dừng quá trình thêm
                        }
                    }
                    // Gọi thủ tục ThemHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("ThemLopHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MALOP", mahv);
                        command.Parameters.AddWithValue("@SISO", malop);
                        command.Parameters.AddWithValue("@MAPHONG", hoten);
                        command.Parameters.AddWithValue("@MAGV", diachi);
                        command.Parameters.AddWithValue("@MAKH", nghenghiep);
                        command.Parameters.AddWithValue("@CAHOC", tinhtrang);
                        command.Parameters.AddWithValue("@NGAYBATDAU", ngaybatdau);
                        command.Parameters.AddWithValue("@NGAYKETTHUC", ngayketthuc);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();

                    // Gọi stored procedure CapNhatHocVien
                    using (SqlCommand command = new SqlCommand("SuaLopHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MALOP", mahv);
                        command.Parameters.AddWithValue("@SISO", malop);
                        command.Parameters.AddWithValue("@MAPHONG", hoten);
                        command.Parameters.AddWithValue("@MAGV", diachi);
                        command.Parameters.AddWithValue("@MAKH", nghenghiep);
                        command.Parameters.AddWithValue("@CAHOC", tinhtrang);
                        command.Parameters.AddWithValue("@NGAYBATDAU", ngaybatdau);
                        command.Parameters.AddWithValue("@NGAYKETTHUC", ngayketthuc);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sửa thông tin lớp học thành công!", "Thông báo", MessageBoxButtons.OK);
                btnSua.Enabled = true;
            }

            // Đặt lại trạng thái biến cờ
            isEditMode = false;

            // Sau khi thêm hoặc sửa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
            LoadDataGrid();
            
        }
            private DataRow selectedDataRow;
            private bool isEditMode = false; // Ban đầu ở trạng thái thêm mới

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCapNhatLopHoc.SelectedRows.Count > 0)
            {
                selectedDataRow = ((DataRowView)dgvCapNhatLopHoc.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                cbxMaLop.Text = selectedDataRow["MALOP"].ToString();
                tbxSiSo.Text = selectedDataRow["SISO"].ToString();
                cbxMaphong.Text = selectedDataRow["MAPHONG"].ToString();
                cbxMagiaovien.Text = selectedDataRow["MAGV"].ToString();
                cbxMaKhoaHoc.Text = selectedDataRow["MAKH"].ToString();
                // Không hiển thị số biên lai vì nó không được sửa
                tbxCahoc.Text = selectedDataRow["CAHOC"].ToString();
                dtpNgaybatdau.Value = DateTime.Parse(selectedDataRow["NGAYBATDAU"].ToString());
                dtpNgayketthuc.Value = DateTime.Parse(selectedDataRow["NGAYKETTHUC"].ToString());

                // Khóa cột Mã học viên và số biên lai để không cho sửa

                // Hiển thị nút Lưu và ẩn nút Sửa
                btnLuu.Enabled = true;
                btnSua.Enabled = false;

                // Đặt biến cờ vào trạng thái sửa
                isEditMode = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaLop.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaLop.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaLopHoc", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MALOP", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK);

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
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

        private void dgvCapNhatLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatLopHoc.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string mahv = selectedRow.Cells["MALOP"].Value.ToString();
                string malop = selectedRow.Cells["SISO"].Value.ToString();
                string hoten = selectedRow.Cells["MAPHONG"].Value.ToString();
                string ngaysinh = selectedRow.Cells["MAGV"].Value.ToString();
                string diachi = selectedRow.Cells["MAKH"].Value.ToString();
                string nghenghiep = selectedRow.Cells["CAHOC"].Value.ToString();
                string tinhtrang = selectedRow.Cells["NGAYBATDAU"].Value.ToString();
                string tinhtrangs = selectedRow.Cells["NGAYKETTHUC"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaLop.Text = mahv;
                tbxSiSo.Text = malop;
                cbxMaphong.Text = hoten;
                cbxMagiaovien.Text = ngaysinh;
                cbxMaKhoaHoc.Text = diachi;
                tbxCahoc.Text = nghenghiep;
                dtpNgaybatdau.Value = DateTime.Parse(tinhtrang);
                dtpNgayketthuc.Value = DateTime.Parse(tinhtrangs);

            }
        }
    }
}

