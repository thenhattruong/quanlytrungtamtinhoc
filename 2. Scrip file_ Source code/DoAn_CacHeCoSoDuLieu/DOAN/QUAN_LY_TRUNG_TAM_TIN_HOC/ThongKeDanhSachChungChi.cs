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
    public partial class ThongKeDanhSachChungChi : Form
    {
        public ThongKeDanhSachChungChi()
        {
            InitializeComponent();
        }
        private SQL sqlInstance = SQL.GetInstance();

        private void rbnDat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnDaNhan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnChuaNhan_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvThongKeChungChi, saveFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThongKeChungChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            catch (Exception )
            {
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable result = new DataTable();

                if (rbnDat.Checked)
                {
                    string query = "SELECT * FROM TimKiemHocVienDatChungChi()";
                    result = sqlInstance.ExecuteQuery(query);
                }
                else if (rbnDaNhan.Checked)
                {
                    string query = "SELECT * FROM TimKiemHocVienDaNhanChungChi()";
                    result = sqlInstance.ExecuteQuery(query);
                }
                else if (rbnChuaNhan.Checked)
                {
                    string query = "SELECT * FROM TimKiemHocVienChuaNhanChungChi()";
                    result = sqlInstance.ExecuteQuery(query);
                }

                dgvThongKeChungChi.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ThongKeDanhSachChungChi_Load(object sender, EventArgs e)
        {

        }
    }
}
