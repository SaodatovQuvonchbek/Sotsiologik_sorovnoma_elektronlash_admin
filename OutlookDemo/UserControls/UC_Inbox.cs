using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace OutlookDemo.UserControls
{
    public partial class UC_Inbox : UserControl
    {
        private int number;
       // private const string dba = @"Data Source=Data\Savollar.db;Version=3;";
        //  private const string dba = @"Data Source=Savollar.db;Version=3;";
        int current = 0;
        public UC_Inbox()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //guna2HtmlLabel1.Text = DateTime.Now.ToString("T");
        }

        private void UC_Inbox_Load(object sender, EventArgs e)
        {
            //timer1.Start();


            populate();
        }
        private void populate()
        {
            //
            //
            //string dba = @"Data Source=Data\Savollar.db;Version=3;";
            if (!string.IsNullOrEmpty(filePath)) { 
                string dba = $"Data Source={filePath};Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(dba))
            using (SQLiteCommand com = new SQLiteCommand("select Savol from QuesTab", con))

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(com))
            {
                con.Open();
                com.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                con.Close();


            }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Savol", guna2TextBox1.Text);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string dba = $"Data Source={filePath};Version=3;";
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
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string dba = $"Data Source={filePath};Version=3;";
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
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Savol", guna2TextBox1.Text);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string dba = $"Data Source={filePath};Version=3;";

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
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Savolni kiriting");
            }
            else
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    string dba = $"Data Source={filePath};Version=3;";

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
        }
      
        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            TxtEmpty();
            // OpenFileDialogni yaratish
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                // Filters qo'shish
                Filter = "Test savollari  (*.db)|*.db",
                Title = "Test savollari",
                FilterIndex = 1
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                //foreach (string file in openFileDialog1.FileNames)
                //{
                 filePath = openFileDialog1.FileName;
                    // Ma'lumotlar bazasini ochish kodlari
                    string connectionString = $"Data Source={filePath};Version=3;";
                    SQLiteConnection connection = new SQLiteConnection(connectionString);
                    connection.Open();
                    // Bazani ishlatish
                    string query = "select * from QuesTab";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connection);



                    da.Fill(dt);

                    textBox1.Text = dt.Rows[current]["Savol"].ToString();
                    textBox2.Text = dt.Rows[current]["Ajavob"].ToString();
                    textBox3.Text = dt.Rows[current]["Bjavob"].ToString();
                    textBox4.Text = dt.Rows[current]["Cjavob"].ToString();
                    textBox5.Text = dt.Rows[current]["Djavob"].ToString();
                    textBox6.Text = dt.Rows[current]["Ejavob"].ToString();

                    // Uyga qaytish va ulanishni yopish
                    connection.Close();
                // }
                populate();
            }
        }
        string filePath;
        private void TxtEmpty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            //guna2DataGridView1.Rows.Clear();
        }

        private void guna2DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
