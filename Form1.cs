using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Pipes;
using System.IO.Ports;

namespace UR2FinalExamComputerSciencePortion
{
    public partial class Form1 : Form
    {

        int mGrayMin = 70;
        int mGrayMax = 220;
        public Form1()
        {
            InitializeComponent();
        }
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog lFile = new OpenFileDialog();

            if (lFile.ShowDialog() == DialogResult.OK)
            {

                Mat lOriginalImage = CvInvoke.Imread(lFile.FileName,
                                        Emgu.CV.CvEnum.ImreadModes.AnyColor);
                Mat lOriginalImageDisplay = new Mat();

                //resize to PictureBox aspect ratio
                Size newSize = new Size(pictureBox1.Size.Width,
                                            pictureBox1.Height);
                CvInvoke.Resize(lOriginalImage, lOriginalImageDisplay, newSize);

                // display the original image
                pictureBox1.Image = lOriginalImageDisplay.ToBitmap();

                // convert to binary gray image
                var lGrayImage = lOriginalImageDisplay.ToImage<Gray, byte>()
                                    .ThresholdBinary(new Gray(mGrayMin), new Gray(mGrayMax))
                                    .Mat;
                GrayPictureBox.Image = lGrayImage.ToBitmap();

                // grab an rgb copy
                var lDecoratedImage = lGrayImage.ToImage<Rgb, byte>();

                // find lContours:
                using (VectorOfVectorOfPoint lContours = new VectorOfVectorOfPoint())
                {
                    // Build list of lContours on the gray image
                    CvInvoke.FindContours(lGrayImage, lContours, null, RetrType.List,
                                            ChainApproxMethod.ChainApproxSimple);

                    List<Bgr> lColors = new List<Bgr>{ new Bgr(Color.Red),
                                                        new Bgr(Color.Green),
                                                        new Bgr(Color.Blue),
                                                        new Bgr(Color.Yellow),
                                                        new Bgr(Color.Orange),
                                                        new Bgr(Color.Pink),
                                                        new Bgr(Color.Purple)};

                    for (int i = 0; i < lContours.Size; i++)
                    {

                        double lCurPerimeter = CvInvoke.ArcLength(lContours[i], true);
                        VectorOfPoint lCurApprox = new VectorOfPoint();
                        CvInvoke.ApproxPolyDP(lContours[i], lCurApprox, 0.04 * lCurPerimeter, true);

                        CvInvoke.DrawContours(lDecoratedImage, lContours, i, new MCvScalar(0, 0, 255), 2);

                        //lMoments  center of the shape

                        var lMoments = CvInvoke.Moments(lContours[i]);
                        int lCenterX = (int)(lMoments.M10 / lMoments.M00);
                        int lCenterY = (int)(lMoments.M01 / lMoments.M00);

                        if (lCurApprox.Size == 3)
                        {
                            CvInvoke.PutText(lDecoratedImage, "Triangle", new Point(lCenterX, lCenterY),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                        }

                        if (lCurApprox.Size == 4)
                        {
                            Rectangle rect = CvInvoke.BoundingRectangle(lContours[i]);

                            double ar = (double)rect.Width / rect.Height;

                            if (ar >= 0.95 && ar <= 1.05)
                            {
                                CvInvoke.PutText(lDecoratedImage, "Square", new Point(lCenterX, lCenterY),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                            }
                            else
                            {
                                CvInvoke.PutText(lDecoratedImage, "Rectangle", new Point(lCenterX, lCenterY),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                            }

                        }

                    }

                    CoordsTextBox.Text = $"{lContours.Size} lContours detected.";
                }

                // display decorated image
                DecoratedPictureBox.Image = lDecoratedImage.ToBitmap();
            }
        }

        private void GrayMin_Scroll(object sender, EventArgs e)
        {
            mGrayMin = GrayMin.Value; //int member GrayMin = name of trackbar
            GrayMinLabel.Text = mGrayMin.ToString();
        }

        private void GrayMax_Scroll(object sender, EventArgs e)
        {
            mGrayMax = GrayMax.Value;
            GrayMaxLabel.Text = mGrayMax.ToString();
        }
    }
    

}
