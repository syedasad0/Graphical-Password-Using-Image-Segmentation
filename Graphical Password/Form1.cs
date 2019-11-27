using System.Drawing;
using System.Windows.Forms;
using gfoidl.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;


namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private Image _originalImage;
		private bool _selecting;
		private Rectangle _selection;
		//---------------------------------------------------------------------
		public Form1()
		{
			InitializeComponent();
		}

        string s = "";
        
		//---------------------------------------------------------------------
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Save just a copy of the image on no reference!
			_originalImage = pictureBox1.Image.Clone() as Image;

            System.Drawing.Pen _redPen = new System.Drawing.Pen(Color.Red, 3);
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.DrawLine(_redPen, new Point(0, 252), new Point(1900, 252));
            graphics.DrawLine(_redPen, new Point(0, 504), new Point(1900, 504));
            //graphics.DrawLine(_redPen, new Point(0, 758), new Point(1900, 758));

            graphics.DrawLine(_redPen, new Point(340, 0), new Point(340, 1900));
            graphics.DrawLine(_redPen, new Point(680, 0), new Point(680, 1900));
            graphics.DrawLine(_redPen, new Point(1060, 0), new Point(1060, 1900));
            
		}
		//---------------------------------------------------------------------
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			// Starting point of the selection:
			if (e.Button == MouseButtons.Left)
			{
				_selecting = true;
				_selection = new Rectangle(new Point(e.X, e.Y), new Size());

                textBox1.Text = e.X.ToString();
                textBox2.Text = e.Y.ToString();
			}
		}
		//---------------------------------------------------------------------
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			// Update the actual size of the selection:
			if (_selecting)
			{
				_selection.Width = e.X - _selection.X;
				_selection.Height = e.Y - _selection.Y;

				// Redraw the picturebox:

                textBox3.Text = _selection.Height.ToString();
                textBox4.Text = _selection.Width.ToString();

                textBox5.Text = _selection.X.ToString();
                textBox6.Text = _selection.Y.ToString();

				pictureBox1.Refresh();
			}
		}
		//---------------------------------------------------------------------
		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && _selecting)
			{
				// Create cropped image:
				Image img = pictureBox1.Image.Crop(_selection);

				// Fit image to the picturebox:
				pictureBox1.Image = img.Fit2PictureBox(pictureBox1);

				_selecting = false;
			}
		}
		//---------------------------------------------------------------------
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (_selecting)
			{
				// Draw a rectangle displaying the current selection
				Pen pen = Pens.GreenYellow;
				e.Graphics.DrawRectangle(pen, _selection);
			}
		}
		//---------------------------------------------------------------------
		private void button1_Click(object sender, System.EventArgs e)
		{
			
            pictureBox1.Image = _originalImage.Clone() as Image;
            System.Drawing.Pen _redPen = new System.Drawing.Pen(Color.Red, 3);
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.DrawLine(_redPen, new Point(0, 252), new Point(1900, 252));
            graphics.DrawLine(_redPen, new Point(0, 504), new Point(1900, 504));
            //graphics.DrawLine(_redPen, new Point(0, 758), new Point(1900, 758));

            graphics.DrawLine(_redPen, new Point(340, 0), new Point(340, 1900));
            graphics.DrawLine(_redPen, new Point(680, 0), new Point(680, 1900));
            graphics.DrawLine(_redPen, new Point(1060, 0), new Point(1060, 1900));
		}

        private void button2_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(sfd.FileName, format);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                {
                    //_selection = new Rectangle(new Point(0, 0), new Size());
                    //_selection.Width = 110;
                    //_selection.Height = 110;

                    //Image img = pictureBox1.Image.Crop(_selection);
                    //// Fit image to the picturebox:
                    //pictureBox2.Image = img.Fit2PictureBox(pictureBox1);

                    Bitmap bitmap = new Bitmap(pictureBox1.Image, new Size(1024,768));
                 
                    Rectangle rect = new Rectangle(0, 0, 335, 250);
                    Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = cropped;

                    Rectangle rect1 = new Rectangle(342, 0, 335, 250);
                    Bitmap cropped1 = bitmap.Clone(rect1, bitmap.PixelFormat);
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Image = cropped1;


                    Rectangle rect2 = new Rectangle(687, 0, 335, 250);
                    Bitmap cropped2 = bitmap.Clone(rect2, bitmap.PixelFormat);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox4.Image = cropped2;


                    Rectangle rect3 = new Rectangle(0, 256, 335, 250);
                    Bitmap cropped3 = bitmap.Clone(rect3, bitmap.PixelFormat);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox5.Image = cropped3;

                    Rectangle rect4 = new Rectangle(342, 256, 335, 250);
                    Bitmap cropped4 = bitmap.Clone(rect4, bitmap.PixelFormat);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox6.Image = cropped4;

                    Rectangle rect5 = new Rectangle(686, 256, 335, 250);
                    Bitmap cropped5 = bitmap.Clone(rect5, bitmap.PixelFormat);
                    pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox7.Image = cropped5;


                    Rectangle rect6 = new Rectangle(0, 508, 335, 250);
                    Bitmap cropped6 = bitmap.Clone(rect6, bitmap.PixelFormat);
                    pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox8.Image = cropped6;

                    Rectangle rect7 = new Rectangle(342, 508, 335, 250);
                    Bitmap cropped7 = bitmap.Clone(rect7, bitmap.PixelFormat);
                    pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox9.Image = cropped7;

                    Rectangle rect8 = new Rectangle(686, 508, 335, 250);
                    Bitmap cropped8 = bitmap.Clone(rect8, bitmap.PixelFormat);
                    pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox10.Image = cropped8;

                }

                //{
                //    _selection = new Rectangle(new Point(113, 0), new Size());
                //    _selection.Width = 110;
                //    _selection.Height = 110;

                //    Image img1 = pictureBox1.Image.Crop(_selection);
                //    // Fit image to the picturebox:
                //    pictureBox3.Image = img1;
                    
                //}

                button5.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please Enter ID");
            }
            else
            {
                s = textBox7.Text;
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                var _with1 = OpenFileDialog1;
                _with1.CheckFileExists = true;
                _with1.ShowReadOnly = false;
                _with1.Filter = "All Files|*.*|Bitmap Files (*)|*.bmp;*.gif;*.jpg";
                _with1.FilterIndex = 2;
                if (_with1.ShowDialog() == DialogResult.OK)
                {
                    // Load the specified file into a PictureBox Connection.control.
                    pictureBox1.Image = Image.FromFile(_with1.FileName);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"Image\" + s))
                {
                    Directory.CreateDirectory(@"Image\" + s);
                }
                s = textBox7.Text;
                pictureBox2.Image.Save(@"Image\" + s + @"\1.jpg");
                pictureBox3.Image.Save(@"Image\" + s + @"\2.jpg");
                pictureBox4.Image.Save(@"Image\" + s + @"\3.jpg");
                pictureBox5.Image.Save(@"Image\" + s + @"\4.jpg");
                pictureBox6.Image.Save(@"Image\" + s + @"\5.jpg");
                pictureBox7.Image.Save(@"Image\" + s + @"\6.jpg");
                pictureBox8.Image.Save(@"Image\" + s + @"\7.jpg");
                pictureBox9.Image.Save(@"Image\" + s + @"\8.jpg");
                pictureBox10.Image.Save(@"Image\" + s + @"\9.jpg");
                
                SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=ThreeLevelDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Insert into Img values('" + s + "','123456789')", con);
                cmd.ExecuteNonQuery();
                DialogResult d = MessageBox.Show("User Registered Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (d == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        
	}
}