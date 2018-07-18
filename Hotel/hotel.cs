using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Hotel : Form
    {
        public Hotel()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private string connString = "Data Source=VSITESTUDENT;Initial Catalog = Hotel; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection GetSqlConnection(string connString) {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }

        private void FillDataGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pPrikazSvihHotela";
                cmd.Connection = GetSqlConnection(connString);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
            }
        }



        private void unosHotela(object sender, EventArgs e)
        {
      
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pUnosHotela";
                cmd.Parameters.AddWithValue("@naziv", this.comboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@adresa", this.comboBox2.Text.Trim());
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();

              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                FillDataGridView();
            }
        }

        private void ispravakHotela(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pIspravakHotela";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@naziv", this.comboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@adresa", this.comboBox2.Text.Trim());
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ispravak hotela", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                FillDataGridView();
            }

        }

        private void brisanjeHotela(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pBrisanjeHotela";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "brisanje hotela", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                FillDataGridView();
            }


        }


    }
}
