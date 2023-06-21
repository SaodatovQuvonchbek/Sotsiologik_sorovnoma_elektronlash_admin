using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
namespace OutlookDemo.UserControls
{
    public partial class Sotsoalagik : UserControl
    {
        public Sotsoalagik()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "So'rovnoma natijalari  (*.ks)|*.ks",
                Multiselect = true,
                Title = " Fayl tanlang"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                LoadFilesAndMergeLines(fileNames);
            }
            RemoveLastThreeLines(textBox2);
        }

        private void LoadFilesAndMergeLines(string[] fileNames)
        {

            List<List<string>> allFileLines = new List<List<string>>();

            int k = 1;
            foreach (string fileName in fileNames)
            {
                List<string> fileLines = new List<string>(File.ReadAllLines(fileName));
                allFileLines.Add(fileLines);

            }

            StringBuilder result = new StringBuilder();

            bool hasMoreLines;
            int lineNumber = 0;

            do
            {
               
                    result.AppendLine(Environment.NewLine + k + "-savol" + Environment.NewLine);
                hasMoreLines = false;
                int s = 1;
                foreach (List<string> fileLines in allFileLines)
                {
                   
                        if (lineNumber < fileLines.Count)
                        {

                            result.AppendLine(s+" - javob   "+fileLines[lineNumber] + "  ");
                            hasMoreLines = true;

                        }
                    s++;
                }

                lineNumber++;
                k++;
              

            } while (hasMoreLines);
          
                textBox2.Text = result.ToString();
            
            //int linesToRemove = 3; // o'chiriladigan qatorlar soni
            //int totalLines = textBox2.Lines.Length; // matndagi umumiy qatorlar soni
            //int startCharIndex = textBox2.GetFirstCharIndexFromLine(totalLines - linesToRemove); // o'chiriladigan qatorlar boshlanishi
            //int startCharCount = textBox2.TextLength - textBox2.GetFirstCharIndexFromLine(totalLines - linesToRemove); // o'chiriladigan qatorlar uzunligi
            //textBox2.Text = textBox2.Text.Remove(startCharIndex, startCharCount); // matndan o'chiriladigan qatorlar olib tashlanadi

        }
     //   oxirgi 3 ta qatorni uchrirish
        private void RemoveLastThreeLines(TextBox textBox)
        {
            string[] lines = textBox.Lines;
            int removeCount = Math.Min(3, lines.Length);
            Array.Resize(ref lines, lines.Length - removeCount);
            textBox.Lines = lines;
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            Document doc = word.Documents.Add();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word Fayl|*.docx";
            saveFileDialog1.Title = "Word Fayl ";
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
  MessageBox.Show("Fayl muvaffaqiyatli saqlandi!", "So'rovnoma natijalari", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

