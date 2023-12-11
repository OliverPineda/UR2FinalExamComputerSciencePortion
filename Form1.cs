

using System.Windows.Forms;

namespace UR2FinalExamComputerSciencePortion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog lFile = new OpenFileDialog();


            if (lFile.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                pictureBox1.Image = new System.Drawing.Bitmap(lFile.FileName);
            }

        }
    }
}