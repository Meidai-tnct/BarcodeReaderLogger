using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeLogger
{
    public partial class Form1 : Form
    {
        string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            filename = "log_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
            textBox3.Text = filename;

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true))
                {
                }
            }
            catch
            {
                MessageBox.Show("ファイル：" + filename + "を閉じてください。");
            }

            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string tmp = DateTime.Now.ToString() + "," + textBox1.Text;
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true))
                    {
                        sw.WriteLine(tmp);
                    }
                }
                catch
                {
                    MessageBox.Show("ファイル：" + filename + "を閉じてください。");
                }
                textBox2.AppendText(tmp + Environment.NewLine);

                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ファイルを開く
            System.Diagnostics.Process.Start(filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // フォルダを開く
            System.Diagnostics.Process.Start(Environment.CurrentDirectory);
        }
    }
}
