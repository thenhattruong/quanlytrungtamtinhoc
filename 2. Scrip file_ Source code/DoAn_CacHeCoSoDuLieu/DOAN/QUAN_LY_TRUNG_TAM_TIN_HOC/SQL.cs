using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;  // Thêm thư viện này để sử dụng MessageBox
using System.Data;  // Thêm thư viện này để sử dụng DataTable

 namespace QUAN_LY_TRUNG_TAM_TIN_HOC
    {
        public class SQL
        {
            private SqlConnection con;
            private static SQL instance;
            private string connectionString = "Data Source=THENHAT-PC\\SQLEXPRESS;Initial Catalog=DOAN_QLTRUNGTAMTINHOC;Integrated Security=True";

            public SqlConnection Connection
            {
                get { return con; }
            }
            public string ConnectionString
            {
                get { return connectionString; }
            }
        private SQL()
            {
                con = new SqlConnection(connectionString);
            }

            public static SQL GetInstance()
            {
                if (instance == null)
                {
                    instance = new SQL();
                }
                return instance;
            }

            public DataTable ExecuteQuery(string query)
            {
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return dataTable;
            }
        public DataTable ExecuteQueryWithParams(SqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                using (cmd)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dataTable;
        }

    }
        
 }
