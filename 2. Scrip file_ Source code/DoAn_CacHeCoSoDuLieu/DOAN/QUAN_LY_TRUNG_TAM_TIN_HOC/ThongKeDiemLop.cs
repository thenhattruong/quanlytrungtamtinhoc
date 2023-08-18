﻿using System;
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
    public partial class ThongKeDiemLop : Form
    {
        public ThongKeDiemLop()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMaLop = cbxChonMaLop.SelectedValue.ToString(); // Lấy giá trị đã chọn trong combobox

                // Thay đổi truy vấn để gọi hàm TimDiemHocVienTheoLop và truyền tham số vào
                string query = $"SELECT * FROM TimDiemHocVienTheoLop(@MALOP)";

                // Tạo kết nối SQL và thực hiện truy vấn
                using (SqlConnection connection = new SqlConnection(sqlInstance.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào truy vấn
                        command.Parameters.AddWithValue("@MALOP", selectedMaLop);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ truy vấn
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // Tạo DataTable để chứa dữ liệu
                        DataTable result = new DataTable();
                        dataAdapter.Fill(result);

                        // Đổ dữ liệu vào dataview
                        dgvThongKeDiemLop.DataSource = result;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không tải được danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxChonMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private void ThongKeDiemLop_Load(object sender, EventArgs e)
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

        private void btnInDiem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvThongKeDiemLop, saveFileDialog1.FileName);
            }
        }
    }
}
