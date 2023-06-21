using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace OutlookDemo.UserControls
{
    public partial class statistika : UserControl
    {
        public statistika()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    // fayl nomlari ro'yxati
            //    List<string> fileNames = new List<string>();

            //    // fayl yozish joyi
            //    string folderPath = @"C:\MyFolder\";

            //    // folder ichidagi barcha fayllarni olamiz
            //    fileNames = Directory.GetFiles(folderPath, "*.txt").ToList();

            //    // fayl nomlarini listboxda ko'rsatamiz
            //    foreach (string fileName in fileNames)
            //    {
            //        listBox1.Items.Add(System.IO.Path.GetFileName(fileName));
            //

            //string content = File.ReadAllText("file.txt");

            // malumotlarni textboxda chiqarish
            // listBox1.Text = content;
            // txt fayllari uchun qavs orqali to'plamlash uchun Directory sinfi


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
          
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; // Bu qatarda bitta faylni emas, ko'plab fayllarni tanlash imkoniyati mavjud.
            ofd.Filter = "Text Files (*.bmm)|*.bmm";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    // Faylni o'qish uchun StreamReader obyekti yaratish.
                    using (StreamReader reader = new StreamReader(file))
                    {
                        // Faylni text boxga yozish.
                        textBox1.Text += reader.ReadToEnd() + Environment.NewLine;
                    }
                }
            }


            textBox2.Text = "";
            string s = textBox1.Text;
            string[] satr = s.Split('\n');

            string[,] array = new string[satr.Length, satr[0].Length];

            for (int i = 0; i < satr.Length; i++)
            {
                for (int j = 0; j < satr[i].Length; j++)
                {
                    array[i, j] = satr[i][j].ToString();
                }
            }

            int[,] mas = Hisobla(array);
            string ss = "";
          //  string num1 = "";
            double num;

            for (int i = 0; i < mas.GetLength(1)-1; i++)
            {
              
                num =0;
                ss = "";
                ss += (i + 1) + "-savol";
                if (mas[0, i] != 0)
                {
                   
                num += mas[0, i];
                    ss += $"\tA-{mas[0, i]} ta  ";
                }
                   
                if (mas[1, i] != 0)
                {
                   
                    ss += $"\tB-{mas[1, i]} ta";
                    num += mas[1, i];
                }
                   
                if (mas[2, i] != 0)
                {
                    num += mas[2, i];
                    ss += $"\tC-{mas[2, i]} ta";
                }
                if (mas[3, i] != 0)
                {
                    num += mas[3, i];
                    ss += $"\tD-{mas[3, i]} ta";
                }
                if (mas[4, i] != 0)
                {
                    num += mas[4, i];
                    ss += $"\tE-{mas[4, i]} ta ";
                }

                ss += System.Environment.NewLine;
                textBox2.Text += ss;
             
                //   textBox2.Text += num;
            }
           


            //guna2Button1.Enabled = false;
            textBox1.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        public static int[,] Hisobla(string[,] a)
        {
            int col = a.GetLength(1);
            int[,] array = new int[5, col];
            int cntA = 0, cntB = 0, cntC = 0, cntD = 0, cntE = 0;

            for (int i = 0; i < a.GetLength(1); i++)
            {
                cntA = 0;
                cntB = 0;
                cntC = 0;
                cntD = 0;
                cntE = 0;
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    if (a[j, i] == "A")
                        cntA++;
                    if (a[j, i] == "B")
                        cntB++;
                    if (a[j, i] == "C")
                        cntC++;
                    if (a[j, i] == "D")
                        cntD++;
                    if (a[j, i] == "E")
                        cntE++;
                }
                array[0, i] = cntA;
                array[1, i] = cntB;
                array[2, i] = cntC;
                array[3, i] = cntD;
                array[4, i] = cntE;
            }
            return array;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            //  Stream myStream;


            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "Word Document|*.docx";
            //saveFileDialog1.Title = "Save a Word Document";
            //saveFileDialog1.ShowDialog();
            //if (saveFileDialog1.FileName != "")
            //{
            //    using (StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile()))
            //    {
            //        writer.Write(textBox2.Text);
            //    }
            //}

            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            Document doc = word.Documents.Add();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word Fayl|*.docx";
            saveFileDialog1.Title = "Word Fayl";
            saveFileDialog1.ShowDialog();

           
            string fileName = saveFileDialog1.FileName;

           
            if (fileName.Trim() == "")
            {
                return;
            }

          
            string textToSave = textBox2.Text;

         
            doc.Content.Text = textToSave;


            object fileNameObject = fileName;
            doc.SaveAs2(ref fileNameObject);

            word.Quit();

  MessageBox.Show("Fayl muvaffaqiyatli saqlandi!", "Test natijalari", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }

}

