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
    public partial class InBienLai : Form
    {
        public InBienLai()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();

        private void cbxChonHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InBienLai_Load(object sender, EventArgs e)
        {
            string queryMaLop = "SELECT MaHV FROM HOCVIEN";
            DataTable resultMaLop = sqlInstance.ExecuteQuery(queryMaLop);

            if (resultMaLop.Rows.Count > 0)
            {
                cbxChonHocVien.DataSource = resultMaLop;
                cbxChonHocVien.DisplayMember = "MaHV";
                cbxChonHocVien.ValueMember = "MaHV";
            }
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (cbxChonHocVien.SelectedItem != null)
                {
                    string maHV = cbxChonHocVien.SelectedItem.ToString(); // Lấy mã học viên từ ComboBox
                    string query = $"SELECT dbo.InBienLaiHocVien('{maHV}') AS BienLai";
                    DataTable result = sqlInstance.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        string bienLai = result.Rows[0]["BienLai"].ToString();

                        // Hiển thị thông tin biên lai trên TextBox
                        textBox1.Text = bienLai;

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Hiển thị thông tin biên lai thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy biên lai cho học viên này.", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiển thị thông tin biên lai thất bại! " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }


        private void btnInDiem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMaHocVien = cbxChonHocVien.SelectedValue.ToString(); // Lấy giá trị đã chọn trong combobox

                // Gọi Stored Procedure và truyền tham số
                string query = $"EXEC InBienLaiHocVien @MAHV = '{selectedMaHocVien}'";

                // Thực hiện truy vấn và lấy dữ liệu
                DataTable result = sqlInstance.ExecuteQuery(query);

                // Đổ dữ liệu vào dataview
                dgvInBienLai.DataSource = result;
            }
            catch (Exception)
            {
                MessageBox.Show("Không tải được danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
