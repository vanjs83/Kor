using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Gosti : Form
    {
        public Gosti()
        {
            InitializeComponent();
            PrikaziSveHotele();
            PrikaziSveGoste();
        }

        private string connString = "Data Source=VSITESTUDENT;Initial Catalog = Hotel; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection GetSqlConnection(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
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


                comboBox2.DataSource = dt;
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "naziv";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prikazi sve hotele", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                comboBox3.ResetText();

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pPrikazSvihSoba";
                cmd.Parameters.AddWithValue("@hotelId", this.comboBox2.SelectedValue);
                cmd.Connection = GetSqlConnection(connString);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                comboBox3.DataSource = dt;
                comboBox3.ValueMember = "Id";
                comboBox3.DisplayMember = "Broj Sobe";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prikazi sve sobe", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
            }
        }


        private void PrikaziSveGoste()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pPrikazGosta";
                cmd.Connection = GetSqlConnection(connString);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prikaz gosta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
            }
        }


        private void UnosGosta(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pUnosGosta";
                cmd.Parameters.AddWithValue("@sobaId", this.comboBox3.SelectedValue);
                cmd.Parameters.AddWithValue("@ime", this.textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@prezime", this.textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@spol", this.comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@datumRodjenja", this.dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@datumDolaska", this.dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@datumOdlaska", this.dateTimePicker3.Value.Date);
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();
                if (numberEffected == -1)
                {
                    MessageBox.Show("Soba je vec Rezervirana", this.comboBox1.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unos novoga gosta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                PrikaziSveGoste();
            }

        }

        private void PrikaziSveSobeHotela(object sender, EventArgs e)
        {
            PrikaziSveSobe();
        }

        private void BrisanjeGostaHotela(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pBrisanjeGosta";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@sobaId", Convert.ToInt32(this.comboBox3.SelectedValue));
                cmd.Connection = GetSqlConnection(connString);
                int numberEffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Brisanje gosta hotela", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                GetSqlConnection(connString).Close();
                PrikaziSveGoste();
            }
        }

        private void IspraviGostaHotela(object sender, EventArgs e)
        {
             
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pIspravakGosta";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@hotelId", Convert.ToInt32(this.comboBox2.SelectedValue));
                cmd.Parameters.AddWithValue("@sobaId", Convert.ToInt32(this.comboBox3.SelectedValue));
                cmd.Parameters.AddWithValue("@ime", this.textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@prezime", this.textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@spol", this.comboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@datumRođenja", this.dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@datumDolaska", this.dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@datumOdlaska", this.dateTimePicker3.Value.Date);
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
                PrikaziSveGoste();
            }

        }

       
    }
}
