using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Pipes;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;

namespace UR2FinalExamComputerSciencePortion
{
    public partial class Form1 : Form
    {
        int mType = 0;
        int mGrayMin = 70;
        int mGrayMax = 220;

        //Serial Communication
        SerialPort mArduinoSerial = new SerialPort();

        int mContoursCount = 0;

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
                            mType = 1;
                        }

                        if (lCurApprox.Size == 4)
                        {
                            mType = 2;
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
                                mContoursCount = 3;
                            }
                          
                        }

                    }
                    mContoursCount += lContours.Size;
                    //mContoursCount = lContours.Size;
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

        private void Form1_Load(object sender, EventArgs e)
        {

                try
                {

                    // Initialize serial port
                    mArduinoSerial.PortName = "COM6";
                    mArduinoSerial.BaudRate = 9600;
                    mArduinoSerial.DataReceived += SerialPort_DataReceived;

                    // Open the serial port
                    mArduinoSerial.Open();

                    // ...
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing serial port: {ex.Message}");
                    Close();
                }

        }

        private void UpdateTextBox(TextBox textBox, string data)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => UpdateTextBox(textBox, data)));
            }
            else
            {
                textBox.Text = data;
            }
        }

        private void DisplayReceivedData(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayReceivedData), data);
            }
            else
            {
                textBoxOutput.AppendText(data + Environment.NewLine); // Use AppendText to add new data and a new line
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = mArduinoSerial.ReadLine();
                DisplayReceivedData(receivedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving data from Arduino: {ex.Message}");
            }
        }

        private void SendDataToArduino(string data)
        {

            try
            {
                if (mArduinoSerial.IsOpen)
                {
                    mArduinoSerial.WriteLine(data);
                }
                else
                {
                    // Handle the case where the serial port is not open
                    MessageBox.Show("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during serial communication
                MessageBox.Show($"Error sending data to Arduino: {ex.Message}");
            }
        }

        private void SendSerial_Click(object sender, EventArgs e)
        {
            SendDataToArduino(mType.ToString());

        }
    }

}
