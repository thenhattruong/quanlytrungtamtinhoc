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
    public partial class ThongKeDanhSachThiLai : Form
    {
        public ThongKeDanhSachThiLai()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();

        private void cbxChonMaHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMaLop = cbxChonMaLop.SelectedValue.ToString(); // Lấy giá trị đã chọn trong combobox

                // Truy vấn dữ liệu dựa trên mã lớp đã chọn
                string query = $"SELECT * FROM TimKiemHocVienThiLaiTheoLop('{selectedMaLop}')";
                DataTable result = sqlInstance.ExecuteQuery(query);

                // Đổ dữ liệu vào dataview
                dgvThongKeThiLai.DataSource = result;
            }
            catch (Exception)
            {
                MessageBox.Show("Không tải được danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ThongKeDanhSachThiLai_Load(object sender, EventArgs e)
        {
            string queryMaLop = "SELECT MaLop FROM LOPHOC";
            DataTable resultMaLop = sqlInstance.ExecuteQuery(queryMaLop);

            if (resultMaLop.Rows.Count > 0)
            {
                cbxChonMaLop.DataSource = resultMaLop;
                cbxChonMaLop.DisplayMember = "MaLop";
                cbxChonMaLop.ValueMember = "MaLop";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Thống kê";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        // Kiểm tra nếu giá trị của ô không phải là null
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = ""; // Hoặc giá trị bạn muốn hiển thị khi là giá trị null
                        }
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Xuất dữ liệu ra Excel thất bại!", "Thông báo");
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvThongKeThiLai, saveFileDialog1.FileName);
            }
        }

        private void dgvThongKeThiLai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
