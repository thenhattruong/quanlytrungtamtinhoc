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
    public partial class CapNhatHocVien : Form
    {
        private SQL sqlInstance = SQL.GetInstance();

        public CapNhatHocVien()
        {
            InitializeComponent();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void EnableInputControls(bool enable)
        {
            cbxMaHocVien.Enabled = enable;
            cbxMaLop.Enabled = enable;
            tbxHoVaTen.Enabled = enable;
            dtpNgaySinh.Enabled = enable;
            tbxDiaChi.Enabled = enable;
            tbxNgheNghiep.Enabled = enable;
            tbxTinhTrang.Enabled = enable;
            cbxSoBienLai.Enabled = enable;
            tbxHocPhi.Enabled = enable;
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
            cbxMaHocVien.Text = "";
            cbxMaLop.Text = "";
            tbxHoVaTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            tbxDiaChi.Text = "";
            tbxNgheNghiep.Text = "";
            tbxTinhTrang.Text = "";
            cbxSoBienLai.Text = "";
            tbxHocPhi.Text = "";
            rbnNam.Checked = true;
            rbnNu.Checked = false;
        }
        
        private void CapNhatHocVien_Load(object sender, EventArgs e)
        {
            // HIện lên dataview
            string query = "SELECT * FROM HOCVIEN";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatHocVien.DataSource = result;
            // hiện lên mahocvien
            string queryMaHocVien = "SELECT MAHV FROM HOCVIEN";
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
            // Hiển thị danh sách số biên lai trong combobox
            string querySoBienLai = "SELECT DISTINCT SOBIENLAI FROM HOCVIEN";
            DataTable resultSoBienLai = sqlInstance.ExecuteQuery(querySoBienLai);
            if (resultSoBienLai.Rows.Count > 0)
            {
                cbxSoBienLai.DataSource = resultSoBienLai;
                cbxSoBienLai.DisplayMember = "SOBIENLAI";
                cbxSoBienLai.ValueMember = "SOBIENLAI";
            }
        }

        private void cbxMaHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadDataGrid()
        {
            // Tương tự như phần bạn đã viết trong hàm CapNhatHocVien_Load
            string query = "SELECT * FROM HOCVIEN";
            DataTable result = sqlInstance.ExecuteQuery(query);
            dgvCapNhatHocVien.DataSource = result;
        }
        private void dgvCapNhatHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCapNhatHocVien.Rows[e.RowIndex];

                // Lấy giá trị các cột từ dòng đã chọn
                string mahv = selectedRow.Cells["MAHV"].Value.ToString();
                string malop = selectedRow.Cells["MALOP"].Value.ToString();
                string hoten = selectedRow.Cells["HOTEN"].Value.ToString();
                string ngaysinh = selectedRow.Cells["NGAYSINH"].Value.ToString();
                string diachi = selectedRow.Cells["DIACHI"].Value.ToString();
                string nghenghiep = selectedRow.Cells["NGHENGHIEP"].Value.ToString();
                string tinhtrang = selectedRow.Cells["TINHTRANG"].Value.ToString();
                string sobienlai = selectedRow.Cells["SOBIENLAI"].Value.ToString();
                string hocphi = selectedRow.Cells["HOCPHI"].Value.ToString();
                string gioitinh = selectedRow.Cells["GIOITINH"].Value.ToString();

                // Hiển thị giá trị trong các controls tương ứng
                cbxMaHocVien.Text = mahv;
                cbxMaLop.Text = malop;
                tbxHoVaTen.Text = hoten;
                dtpNgaySinh.Value = DateTime.Parse(ngaysinh);
                tbxDiaChi.Text = diachi;
                tbxNgheNghiep.Text = nghenghiep;
                tbxTinhTrang.Text = tinhtrang;
                cbxSoBienLai.Text = sobienlai;
                tbxHocPhi.Text = hocphi;

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

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gbxThongTinChiTiet_Enter(object sender, EventArgs e)
        {

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbxMaHocVien.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string mahv = cbxMaHocVien.SelectedValue.ToString();

                    // Gọi thủ tục XoaHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("XoaHocVien", sqlInstance.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);

                        sqlInstance.Connection.Open();
                        command.ExecuteNonQuery();
                        sqlInstance.Connection.Close();
                    }

                    MessageBox.Show("Xóa học viên thành công!");

                    // Sau khi xóa, bạn có thể gọi lại hàm LoadDataGrid() để cập nhật datagridview
                    LoadDataGrid();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string mahv = cbxMaHocVien.Text;
            string malop = cbxMaLop.Text;
            string hoten = tbxHoVaTen.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            string diachi = tbxDiaChi.Text;
            string nghenghiep = tbxNgheNghiep.Text;
            string tinhtrang = tbxTinhTrang.Text;
            string sobienlai = cbxSoBienLai.Text;
            string hocphi = tbxHocPhi.Text;
            string gioitinh = rbnNam.Checked ? "Nam" : "Nữ";

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(mahv) || string.IsNullOrWhiteSpace(malop) || string.IsNullOrWhiteSpace(hoten)
                || string.IsNullOrWhiteSpace(diachi) || string.IsNullOrWhiteSpace(nghenghiep) || string.IsNullOrWhiteSpace(tinhtrang)
                || string.IsNullOrWhiteSpace(hocphi))
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
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM HOCVIEN WHERE MAHV = @MAHV", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAHV", mahv);
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Mã học viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng quá trình thêm
                        }
                    }

                    // Gọi thủ tục ThemHocVien từ cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand("ThemHocVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);
                        command.Parameters.AddWithValue("@MALOP", malop);
                        command.Parameters.AddWithValue("@HOTEN", hoten);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        command.Parameters.AddWithValue("@DIACHI", diachi);
                        command.Parameters.AddWithValue("@NGHENGHIEP", nghenghiep);
                        command.Parameters.AddWithValue("@TINHTRANG", tinhtrang);
                        command.Parameters.AddWithValue("@SOBIENLAI", sobienlai);
                        command.Parameters.AddWithValue("@HOCPHI", hocphi);
                        command.Parameters.AddWithValue("@GIOITINH", gioitinh);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm học viên thành công!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();

                    // Gọi stored procedure CapNhatHocVien
                    using (SqlCommand command = new SqlCommand("CapNhatHocVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MAHV", mahv);
                        command.Parameters.AddWithValue("@HOTEN", hoten);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        command.Parameters.AddWithValue("@DIACHI", diachi);
                        command.Parameters.AddWithValue("@NGHENGHIEP", nghenghiep);
                        command.Parameters.AddWithValue("@TINHTRANG", tinhtrang);
                        command.Parameters.AddWithValue("@SOBIENLAI", sobienlai);
                        command.Parameters.AddWithValue("@HOCPHI", hocphi);
                        command.Parameters.AddWithValue("@GIOITINH", gioitinh);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sửa thông tin học viên thành công!");
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
            if (dgvCapNhatHocVien.SelectedRows.Count > 0)
            {
                selectedDataRow = ((DataRowView)dgvCapNhatHocVien.SelectedRows[0].DataBoundItem).Row;

                // Hiển thị thông tin học viên để sửa, loại trừ Mã học viên và số biên lai
                cbxMaLop.Text = selectedDataRow["MALOP"].ToString();
                tbxHoVaTen.Text = selectedDataRow["HOTEN"].ToString();
                dtpNgaySinh.Value = DateTime.Parse(selectedDataRow["NGAYSINH"].ToString());
                tbxDiaChi.Text = selectedDataRow["DIACHI"].ToString();
                tbxNgheNghiep.Text = selectedDataRow["NGHENGHIEP"].ToString();
                tbxTinhTrang.Text = selectedDataRow["TINHTRANG"].ToString();
                // Không hiển thị số biên lai vì nó không được sửa
                tbxHocPhi.Text = selectedDataRow["HOCPHI"].ToString();

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
                cbxMaHocVien.Enabled = false;
                cbxSoBienLai.Enabled = false;

                // Hiển thị nút Lưu và ẩn nút Sửa
                btnLuu.Enabled = true;
                btnSua.Enabled = false;

                // Đặt biến cờ vào trạng thái sửa
                isEditMode = true;
            }
        }


        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            // Cho phép nhập mới, vô hiệu hóa sửa và xóa
            EnableInputControls(true);
            EnableButtons(false, false, false, true);
            ClearInputFields();
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


