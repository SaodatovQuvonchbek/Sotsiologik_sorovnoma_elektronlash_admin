using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using OutlookDemo.UserControls;
using System.IO;

namespace OutlookDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                string dbFilePath = "Data\\Savollar.db";

                FileAttributes attributes = File.GetAttributes(dbFilePath);

                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    attributes &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(dbFilePath, attributes);
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 118, b.Location.Y - 30);
            imgSlide.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UC_Inbox uc = new UC_Inbox();
            addUserControl(uc);


        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {UC_Inbox uc =new UC_Inbox();
            addUserControl(uc);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = DateTime.Now.ToString("T");
        }

        private void guna2Button7_MouseHover(object sender, EventArgs e)
        {
            //label2.Visible = true;
        }

        private void guna2Button7_MouseLeave(object sender, EventArgs e)
        {
           // label2.Visible = false;
        }

        private void guna2Button6_MouseHover(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void guna2Button6_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void uC_Inbox1_Load(object sender, EventArgs e)
        {

        }

        private void  guna2Button2_Click(object sender, EventArgs e)
        {
            AddData addData=new AddData();  
            addUserControl(addData);    
        }

        private  void guna2Button3_Click(object sender, EventArgs e)
        {
            statistika statistika = new statistika();
            addUserControl(statistika);
        }

        private  void guna2Button4_Click(object sender, EventArgs e)
        {
        Sotsoalagik sotsoalagik =new Sotsoalagik();
            addUserControl(sotsoalagik);


        }

        private void guna2Button8_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void guna2Button8_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
