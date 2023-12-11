namespace UR2FinalExamComputerSciencePortion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GrayPictureBox = new System.Windows.Forms.PictureBox();
            this.DecoratedPictureBox = new System.Windows.Forms.PictureBox();
            this.CoordsTextBox = new System.Windows.Forms.TextBox();
            this.GrayMin = new System.Windows.Forms.TrackBar();
            this.GrayMax = new System.Windows.Forms.TrackBar();
            this.GrayMinLabel = new System.Windows.Forms.TextBox();
            this.GrayMaxLabel = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.SendSerial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMax)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(779, 412);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(147, 64);
            this.BrowseBtn.TabIndex = 0;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(454, 427);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // GrayPictureBox
            // 
            this.GrayPictureBox.Location = new System.Drawing.Point(494, 24);
            this.GrayPictureBox.Name = "GrayPictureBox";
            this.GrayPictureBox.Size = new System.Drawing.Size(572, 384);
            this.GrayPictureBox.TabIndex = 2;
            this.GrayPictureBox.TabStop = false;
            // 
            // DecoratedPictureBox
            // 
            this.DecoratedPictureBox.Location = new System.Drawing.Point(1086, 30);
            this.DecoratedPictureBox.Name = "DecoratedPictureBox";
            this.DecoratedPictureBox.Size = new System.Drawing.Size(644, 375);
            this.DecoratedPictureBox.TabIndex = 3;
            this.DecoratedPictureBox.TabStop = false;
            // 
            // CoordsTextBox
            // 
            this.CoordsTextBox.Location = new System.Drawing.Point(1111, 411);
            this.CoordsTextBox.Name = "CoordsTextBox";
            this.CoordsTextBox.Size = new System.Drawing.Size(125, 27);
            this.CoordsTextBox.TabIndex = 4;
            // 
            // GrayMin
            // 
            this.GrayMin.Location = new System.Drawing.Point(29, 459);
            this.GrayMin.Maximum = 255;
            this.GrayMin.Minimum = 1;
            this.GrayMin.Name = "GrayMin";
            this.GrayMin.Size = new System.Drawing.Size(276, 56);
            this.GrayMin.TabIndex = 5;
            this.GrayMin.Value = 1;
            this.GrayMin.Scroll += new System.EventHandler(this.GrayMin_Scroll);
            // 
            // GrayMax
            // 
            this.GrayMax.Location = new System.Drawing.Point(355, 449);
            this.GrayMax.Maximum = 255;
            this.GrayMax.Minimum = 1;
            this.GrayMax.Name = "GrayMax";
            this.GrayMax.Size = new System.Drawing.Size(276, 56);
            this.GrayMax.TabIndex = 6;
            this.GrayMax.Value = 1;
            this.GrayMax.Scroll += new System.EventHandler(this.GrayMax_Scroll);
            // 
            // GrayMinLabel
            // 
            this.GrayMinLabel.Location = new System.Drawing.Point(224, 488);
            this.GrayMinLabel.Name = "GrayMinLabel";
            this.GrayMinLabel.Size = new System.Drawing.Size(98, 27);
            this.GrayMinLabel.TabIndex = 7;
            // 
            // GrayMaxLabel
            // 
            this.GrayMaxLabel.Location = new System.Drawing.Point(537, 488);
            this.GrayMaxLabel.Name = "GrayMaxLabel";
            this.GrayMaxLabel.Size = new System.Drawing.Size(69, 27);
            this.GrayMaxLabel.TabIndex = 8;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(1253, 411);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(442, 146);
            this.textBoxOutput.TabIndex = 9;
            // 
            // SendSerial
            // 
            this.SendSerial.Location = new System.Drawing.Point(1137, 488);
            this.SendSerial.Name = "SendSerial";
            this.SendSerial.Size = new System.Drawing.Size(71, 24);
            this.SendSerial.TabIndex = 10;
            this.SendSerial.Text = "send";
            this.SendSerial.UseVisualStyleBackColor = true;
            this.SendSerial.Click += new System.EventHandler(this.SendSerial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 583);
            this.Controls.Add(this.SendSerial);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.GrayMaxLabel);
            this.Controls.Add(this.GrayMinLabel);
            this.Controls.Add(this.GrayMax);
            this.Controls.Add(this.GrayMin);
            this.Controls.Add(this.CoordsTextBox);
            this.Controls.Add(this.DecoratedPictureBox);
            this.Controls.Add(this.GrayPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BrowseBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BrowseBtn;
        private PictureBox pictureBox1;
        private PictureBox GrayPictureBox;
        private PictureBox DecoratedPictureBox;
        private TextBox CoordsTextBox;
        private TrackBar GrayMin;
        private TrackBar GrayMax;
        private TextBox GrayMinLabel;
        private TextBox GrayMaxLabel;
        private TextBox textBoxOutput;
        private Button SendSerial;
    }
}