namespace ImageDownsizerApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label3 = new Label();
            DownSizeParallel = new Button();
            DownSizeBtn = new Button();
            ScalingInput = new TextBox();
            SelectImg = new Button();
            panel2 = new Panel();
            TimeParallel = new Label();
            label1 = new Label();
            label2 = new Label();
            statusLabel = new Label();
            timeNoParallel = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(DownSizeParallel);
            panel1.Controls.Add(DownSizeBtn);
            panel1.Controls.Add(ScalingInput);
            panel1.Controls.Add(SelectImg);
            panel1.Location = new Point(11, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 85);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 12);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 4;
            label3.Text = "Add Value:";
            // 
            // DownSizeParallel
            // 
            DownSizeParallel.Location = new Point(230, 44);
            DownSizeParallel.Name = "DownSizeParallel";
            DownSizeParallel.Size = new Size(219, 33);
            DownSizeParallel.TabIndex = 2;
            DownSizeParallel.Text = "Parallel Scalling";
            DownSizeParallel.UseVisualStyleBackColor = true;
            DownSizeParallel.Click += DownSizeParallel_Click;
            // 
            // DownSizeBtn
            // 
            DownSizeBtn.Location = new Point(7, 44);
            DownSizeBtn.Name = "DownSizeBtn";
            DownSizeBtn.Size = new Size(219, 33);
            DownSizeBtn.TabIndex = 1;
            DownSizeBtn.Text = "Consequential Scalling";
            DownSizeBtn.UseVisualStyleBackColor = true;
            DownSizeBtn.Click += DownSizeBtn_Click;
            // 
            // ScalingInput
            // 
            ScalingInput.Location = new Point(93, 9);
            ScalingInput.Name = "ScalingInput";
            ScalingInput.Size = new Size(239, 27);
            ScalingInput.TabIndex = 0;
            // 
            // SelectImg
            // 
            SelectImg.Location = new Point(338, 6);
            SelectImg.Name = "SelectImg";
            SelectImg.Size = new Size(111, 32);
            SelectImg.TabIndex = 0;
            SelectImg.Text = "Select Image";
            SelectImg.UseVisualStyleBackColor = true;
            SelectImg.Click += SelectImg_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TimeParallel);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(statusLabel);
            panel2.Controls.Add(timeNoParallel);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(477, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(465, 85);
            panel2.TabIndex = 1;
            // 
            // TimeParallel
            // 
            TimeParallel.AutoSize = true;
            TimeParallel.Location = new Point(391, 50);
            TimeParallel.Name = "TimeParallel";
            TimeParallel.Size = new Size(17, 20);
            TimeParallel.TabIndex = 7;
            TimeParallel.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 14);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 4;
            label1.Text = "Time consequential scalling:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(240, 50);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 6;
            label2.Text = "Time parallel scalling:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(8, 50);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 20);
            statusLabel.TabIndex = 3;
            // 
            // timeNoParallel
            // 
            timeNoParallel.AutoSize = true;
            timeNoParallel.Location = new Point(391, 14);
            timeNoParallel.Name = "timeNoParallel";
            timeNoParallel.Size = new Size(17, 20);
            timeNoParallel.TabIndex = 5;
            timeNoParallel.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 14);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 2;
            label5.Text = "Request status:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(8, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(460, 390);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(477, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(465, 390);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 505);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Image Downsizer App";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button DownSizeBtn;
        private TextBox ScalingInput;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button SelectImg;
        private Button DownSizeParallel;
        private PictureBox pictureBox2;
        private Label label1;
        private Label timeNoParallel;
        private Label label2;
        private Label TimeParallel;
        private Label statusLabel;
        private Label label5;
        private Label label3;
    }
}