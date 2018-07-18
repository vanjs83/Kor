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

namespace Hotel
{
    public partial class Sobe : Form
    {
        private string connString = "Data Source=VSITESTUDENT;Initial Catalog = Hotel; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection GetSqlConnection(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }


        public Sobe()
        {
            InitializeComponent();
            PrikaziSveHotele();
           
        }

        private void PrikaziSveHotele()
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


                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "naziv";
                   

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prikaz svih hotela", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
            }

        
         
        }



        private void PrikaziSveSobe()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pPrikazSvihSoba";
                cmd.Parameters.AddWithValue("@hotelId", this.comboBox1.SelectedValue);
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


        private void UnosSobe(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pUnosSobe";
                cmd.Parameters.AddWithValue("@hotelId", this.comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@brojSobe", Convert.ToInt32(this.comboBox2.Text.Trim()));
                cmd.Parameters.AddWithValue("@opisSobe", this.textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@tipSobe", this.comboBox3.Text.Trim());
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();
                if(numberEffected == -1)
                {
                    MessageBox.Show( comboBox2.Text,  "Soba je vec ubacena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                PrikaziSveSobe();
            }
        }





        private void IspravakSobe(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pIspravakSoba";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                cmd.Parameters.AddWithValue("@hotelId", Convert.ToInt32(this.comboBox1.SelectedValue));
                cmd.Parameters.AddWithValue("@brojSobe", Convert.ToInt32(this.comboBox2.Text.Trim()));
                cmd.Parameters.AddWithValue("@opisSobe", this.textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@tipSobe", this.comboBox3.Text.Trim());
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
                PrikaziSveSobe();
            }
        }





        private void BrisanjeSobe(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pBrisanjeSoba";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                cmd.Parameters.AddWithValue("@hotelId", Convert.ToInt32(this.comboBox1.SelectedValue));
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "brisanje Sobe", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                PrikaziSveSobe();
            }

        }

        private void PrikaziSobeHotela(object sender, EventArgs e)
        {
            PrikaziSveSobe();
        }
    }
}
