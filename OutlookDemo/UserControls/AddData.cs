using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OutlookDemo.UserControls
{
    public partial class AddData : UserControl
    {
        private int number;
        private const string dba = @"Data Source=Data\Savollar.db;Version=3;";
        //  private const string dba = @"Data Source=Savollar.db;Version=3;";
        DataTable dt = new DataTable();
        public AddData()
        {
            InitializeComponent();
        }
        private void populate()
        {  //SQLiteDataAdapter da = new SQLiteDataAdapter("select Id, Savol, Ajavob, Bjavob, Cjavob, Djavob, Ejavob from QuesTab", con);
            using (SQLiteConnection con = new SQLiteConnection(dba))
            using (SQLiteCommand com = new SQLiteCommand("SELECT Savol FROM QuesTab", con))

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(com))
            {
                con.Open();
                com.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                con.Close();


            }


            //    SQLiteConnection con = new SQLiteConnection(dba);
            //SQLiteCommand cmd = new SQLiteCommand("select Savol from QuesTab", con);
            //con.Open();
            //SQLiteDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    guna2DataGridView1.Rows.Add( reader["Savol"]);
            //}
            //reader.Close();
            //con.Close();
        }
        private void AddData_Load(object sender, EventArgs e)
        {
            populate();



        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Savolni kiriting");
            }
            else
            {

                using (SQLiteConnection con = new SQLiteConnection(dba))


                using (SQLiteCommand com = new SQLiteCommand("INSERT INTO QuesTab(  Savol, Ajavob, Bjavob, Cjavob, Djavob, Ejavob)values (  @Savol, @Ajavob, @Bjavob, @Cjavob, @Djavob, @Ejavob) ", con))
                {
                    con.Open();
                    com.Parameters.AddWithValue("Savol", textBox1.Text);
                    com.Parameters.AddWithValue("Ajavob", textBox2.Text);
                    com.Parameters.AddWithValue("Bjavob", textBox3.Text);
                    com.Parameters.AddWithValue("Cjavob", textBox4.Text);
                    com.Parameters.AddWithValue("Djavob", textBox5.Text);
                    com.Parameters.AddWithValue("Ejavob", textBox6.Text);
                    com.ExecuteNonQuery();
                    con.Close();



                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                populate();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string a = "SELECT * FROM QuesTab WHERE Savol='" + guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
            using (SQLiteConnection con = new SQLiteConnection(dba))
            using (SQLiteCommand command = new SQLiteCommand(a, con))

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        number = Convert.ToInt32(row["Id"]);
                        textBox1.Text = row["Savol"].ToString();
                        textBox2.Text = row["Ajavob"].ToString();
                        textBox3.Text = row["Bjavob"].ToString();
                        textBox4.Text = row["Cjavob"].ToString();
                        textBox5.Text = row["Djavob"].ToString();
                        textBox6.Text = row["Ejavob"].ToString();


                    }
                }
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            using (SQLiteConnection con = new SQLiteConnection(dba))
                try
                {
                    if (textBox1.Text == "")

                    {
                        MessageBox.Show("O'zgartirmioqchi bo'lgan ma'lumotingizni tanlang");
                    }
                    else
                    {
                        con.Open();

                        string query = "UPDATE  QuesTab SET Savol=@Savol, Ajavob=@Ajavob, Bjavob=@Bjavob, Cjavob=@Cjavob, Djavob=@Djavob, Ejavob=@Ejavob where Id=" + number.ToString();

                        SQLiteCommand com = new SQLiteCommand(query, con);
                        //  com.Parameters.AddWithValue("@Id", textBox7.Text);
                        com.Parameters.AddWithValue("@Savol", textBox1.Text);
                        com.Parameters.AddWithValue("@Ajavob", textBox2.Text);
                        com.Parameters.AddWithValue("@Bjavob", textBox3.Text);
                        com.Parameters.AddWithValue("@Cjavob", textBox4.Text);
                        com.Parameters.AddWithValue("@Djavob", textBox5.Text);
                        com.Parameters.AddWithValue("@Ejavob", textBox6.Text);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Ma'lumot o'zgardi");
                        con.Close();

                        populate();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(dba))
                try
                {
                    //if (textBox1.Text == "")
                    //{
                    //    MessageBox.Show("O'chirmoqchi bo'lgan ma'lumotingizni tanlang");
                    //}

                    //else
                    //{
                    con.Open();
                    string query = "DELETE FROM QuesTab WHERE Savol='" + textBox1.Text + "'";

                    SQLiteCommand cmd = new SQLiteCommand(query, con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ma'lumot o'chirildi");
                    con.Close();
                    populate();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    //  }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Savol", guna2TextBox1.Text);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //string a = "TRUNCATE TABLE QuesTab";
            //using (SQLiteConnection con = new SQLiteConnection(dba))
            //using (SQLiteCommand command = new SQLiteCommand(a, con))
            //{
            //    con.Open();
            //    command.ExecuteNonQuery();
            //    con.Close();
            //}





            using (SQLiteConnection con = new SQLiteConnection(dba))
                try
                {
                    //if (textBox1.Text == "")
                    //{
                    //    MessageBox.Show("O'chirmoqchi bo'lgan ma'lumotingizni tanlang");
                    //}

                    //else
                    //{
                    con.Open();
                    string query = "DELETE FROM QuesTab ";

                    SQLiteCommand cmd = new SQLiteCommand(query, con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ma'lumot o'chirildi");
                    con.Close();
                    populate();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    //  }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string sourceFilePath = @"Data\Savollar.db";

            // SaveFileDialog yaratamiz va sozlamalarni belgilaymiz
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DB files (*.db)|*.db";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Faylni saqlash uchun manzilni olish
                string targetFilePath = saveFileDialog.FileName;

                try
                {
                    // Faylni kuchirish
                    File.Copy(sourceFilePath, targetFilePath, true);
                    MessageBox.Show("Fayl muvaffaqiyatli saqlandi!", "Muvaffaqiyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
          
        }
    }
}

