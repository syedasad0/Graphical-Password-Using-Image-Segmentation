using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace gfoidl.Imaging
{
	/// <summary>
	/// Extension methods for Image
	/// </summary>
	public static class ImageExtension
	{
		/// <summary>
		/// Crops an image according to a selection rectangel
		/// </summary>
		/// <param name="image">
		/// the image to be cropped
		/// </param>
		/// <param name="selection">
		/// the selection
		/// </param>
		/// <returns>
		/// cropped image
		/// </returns>
		public static Image Crop(this Image image, Rectangle selection)
		{
			Bitmap bmp = image as Bitmap;

			// Check if it is a bitmap:
			if (bmp == null)
				throw new ArgumentException("Kein gültiges Bild (Bitmap)");

			// Crop the image:
			Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

			// Release the resources:
			image.Dispose();



            
			return cropBmp;
		}
        //public Image AddGridlines(Image img, int gridSize)
        //{
        //    Graphics g = Graphics.FromImage(img);
        //    int x = gridSize;
        //    int y = gridSize;
        //    while (x < img.Width)
        //    {
        //        g.DrawLine(Pens.Orange, x, 0, x, img.Height);
        //        x += gridSize;
        //    }
        //    while (y < img.Height)
        //    {
        //        g.DrawLine(Pens.Orange, 0, y, img.Width, y);
        //        y += gridSize;
        //    }
        //    return img;
        //}
		//---------------------------------------------------------------------
		/// <summary>
		/// Fits an image to the size of a picturebox
		/// </summary>
		/// <param name="image">
		/// image to be fit
		/// </param>
		/// <param name="picBox">
		/// picturebox in that the image should fit
		/// </param>
		/// <returns>
		/// fitted image
		/// </returns>
		/// <remarks>
		/// Although the picturebox has the SizeMode-property that offers
		/// the same functionality an OutOfMemory-Exception is thrown
		/// when assigning images to a picturebox several times.
		/// 
		/// AFAIK the SizeMode is designed for assigning an image to
		/// picturebox only once.
		/// </remarks>
        public static Image Fit2PictureBox(this Image image, PictureBox picBox)
		{
			Bitmap bmp = null;
			Graphics g;

			// Scale:
			double scaleY = (double)image.Width / picBox.Width;
			double scaleX = (double)image.Height / picBox.Height;
			double scale = scaleY < scaleX ? scaleX : scaleY;

			// Create new bitmap:
			bmp = new Bitmap(
				(int)((double)image.Width / scale),
				(int)((double)image.Height / scale));

			// Set resolution of the new image:
			bmp.SetResolution(
				image.HorizontalResolution,
				image.VerticalResolution);

			// Create graphics:
			g = Graphics.FromImage(bmp);

			// Set interpolation mode:
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;

			// Draw the new image:
			g.DrawImage(
				image,
				new Rectangle(			// Ziel
					0, 0,
					bmp.Width, bmp.Height),
				new Rectangle(			// Quelle
					0, 0,
					image.Width, image.Height),
				GraphicsUnit.Pixel);

            //Draw lines
            //Pen myPen = new Pen(Color.Red);
            //myPen.Width = 30;
            //g.DrawLine(myPen, 30, 30, 45, 65);

            //g.DrawLine(myPen, 1, 1, 45, 65);



			// Release the resources of the graphics:
			g.Dispose();
			
			// Release the resources of the origin image:
			image.Dispose();

            

			return bmp;
		}
	}
}