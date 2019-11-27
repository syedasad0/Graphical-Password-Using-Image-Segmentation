using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class success : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=ThreeLevelDB;Integrated Security=True");

        public success()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterPassword e1 = new EnterPassword();
            e1.Show();
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }

        private void success_Load(object sender, EventArgs e)
        {
            
        }
    }
}
