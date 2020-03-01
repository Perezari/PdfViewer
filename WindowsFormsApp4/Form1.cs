using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DirectoryInfo d = new DirectoryInfo(@"Z:\שולחן עבודה\פירוקים\2019\");//Assuming Test is your Folder
            //FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files

            //comboBox1.DataSource = Files;
            //comboBox1.DisplayMember = "Name";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text + comboBox1.Text;

            try
            {
                pdfViewer1.LoadDocument(path);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string root = @"Z:\שולחן עבודה\פירוקים";
                fbd.SelectedPath = root;
                DialogResult folderBrowser = fbd.ShowDialog();

                if (folderBrowser == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    textBox1.Text = fbd.SelectedPath + "\\";

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                    DirectoryInfo d = new DirectoryInfo(fbd.SelectedPath.ToString());//Assuming Test is your Folder
                    FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files

                    comboBox1.DataSource = Files;
                    comboBox1.DisplayMember = "Name";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text + comboBox1.SelectedValue;
        }
    }
}
