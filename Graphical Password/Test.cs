using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Test : Form
    {
        string s;
        public Test(string s1)
        {
            s = s1;
            
            InitializeComponent();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            random();
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
            Button7.Enabled = true;
            Button8.Enabled = true;
            Button9.Enabled = true;
        }

        public void random()
        {
            textBox1.Text = "";

            ListBox.ObjectCollection list = ListBox1.Items;
            Random rng = new Random();
            int n = list.Count;
            //begin updating
            ListBox1.BeginUpdate();
            while (n > 1)
            {
                n -= 1;
                int k = rng.Next(n + 1);
                object value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            ListBox1.EndUpdate();
            ListBox1.Invalidate();


            {
                string values = ListBox1.Items[0].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button1.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[1].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button2.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[2].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button3.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[3].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button4.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[4].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button5.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[5].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button8.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[6].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button7.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[7].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button6.Location = new Point(convertedItems[0], convertedItems[1]);
            }

            {
                string values = ListBox1.Items[8].ToString();
                string[] tokens = values.Split(',');

                int[] convertedItems = Array.ConvertAll<string, int>(tokens, int.Parse);
                Button9.Location = new Point(convertedItems[0], convertedItems[1]);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=ThreeLevelDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select pattern from Img where userid='" + s + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (textBox1.Text == Convert.ToString(dr[0]))
                {
                    DialogResult d = MessageBox.Show("Login Successfull", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {

                        System.Diagnostics.Process.Start("file:///C:/Users/Deepanshu/Pictures/Graphical%20Password%20By%20Image%20Segmentation/Index/index.html");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Password", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Password", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
            Button1.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
            Button2.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
            Button3.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
            Button4.Enabled = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
            Button5.Enabled = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
            Button6.Enabled = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
            Button7.Enabled = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
            Button8.Enabled = false;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
            Button9.Enabled = false;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            Button1.BackgroundImage = Image.FromFile(@"Image\" + s + @"\1.jpg");
            Button2.BackgroundImage = Image.FromFile(@"Image\" + s + @"\2.jpg");
            Button3.BackgroundImage = Image.FromFile(@"Image\" + s + @"\3.jpg");
            Button4.BackgroundImage = Image.FromFile(@"Image\" + s + @"\4.jpg");
            Button5.BackgroundImage = Image.FromFile(@"Image\" + s + @"\5.jpg");
            Button6.BackgroundImage = Image.FromFile(@"Image\" + s + @"\6.jpg");
            Button7.BackgroundImage = Image.FromFile(@"Image\" + s + @"\7.jpg");
            Button8.BackgroundImage = Image.FromFile(@"Image\" + s + @"\8.jpg");
            Button9.BackgroundImage = Image.FromFile(@"Image\" + s + @"\9.jpg");

            random();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
