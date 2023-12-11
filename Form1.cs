using System;
using System.Drawing;
using System.Windows.Forms;

namespace UR2FinalExamComputerSciencePortion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Image ResizeImage(Image image, Size newSize)
        {
            // Calculate the aspect ratio to maintain the proportions
            float aspectRatio = (float)image.Width / image.Height;

            // Calculate the new width based on the aspect ratio
            int newWidth = (int)(newSize.Height * aspectRatio);

            // If the new width is greater than the PictureBox width, use the PictureBox width
            if (newWidth > newSize.Width)
            {
                newWidth = newSize.Width;
                newSize.Height = (int)(newWidth / aspectRatio);
            }

            // Create a new Bitmap with the specified size
            Bitmap resizedBitmap = new Bitmap(newSize.Width, newSize.Height);

            // Create a Graphics object and draw the resized image
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newSize.Height);
            }

            return resizedBitmap;
        }
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog lFile = new OpenFileDialog();


            if (lFile.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                Image originalImage = new Bitmap(lFile.FileName);
                Image resizedImage = ResizeImage(originalImage, pictureBox1.Size);
                pictureBox1.Image = resizedImage;
            }

        }
    }
}