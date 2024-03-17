using System.Diagnostics;

namespace ImageDownsizerApplication
{
    public partial class Form1 : Form
    {
        private Bitmap myBitmap;
        public Form1()
        {
            InitializeComponent();
            DownSizeBtn.Enabled = false;
            DownSizeParallel.Enabled = false;
            ScalingInput.Enabled = false;

        }

        private void SelectImg_Click(object sender, EventArgs e)
        {
            statusLabel.Text = $"Setting image for resizing...";
            ProcessFiles();
            statusLabel.Text = "Image ready to be resized. :)";
            DownSizeBtn.Enabled = true;
            DownSizeParallel.Enabled = true;
            ScalingInput.Enabled = true;
        }

        private void ProcessFiles()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "img",
                Filter = "img files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        myBitmap = new Bitmap(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void DownSizeBtn_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                String scaling = ScalingInput.Text;
                int scale;
                if (scaling != null && int.TryParse(scaling, out scale))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Bitmap resizedImage = ImageDownsizerUtils.downScale(myBitmap, scale);
                    stopwatch.Stop();
                    PictureBox imageControl = new PictureBox();
                    imageControl.Height = resizedImage.Height;
                    imageControl.Width = resizedImage.Width;

                    if (resizedImage.Width > Width / 2 || resizedImage.Height > Height / 2)
                    {
                        AutoScroll = true;
                    }

                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image myThumbnail = resizedImage.GetThumbnailImage(resizedImage.Width, resizedImage.Height, myCallback, IntPtr.Zero);
                    imageControl.Image = myThumbnail;

                    pictureBox1.Size = new Size(imageControl.Width, imageControl.Height);
                    pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Size.Width + 15, pictureBox1.Location.Y);
                    pictureBox1.Controls.Add(imageControl);
                    timeNoParallel.Text = stopwatch.ElapsedMilliseconds.ToString();
                }
            }
        }

        private void DownSizeParallel_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                String scaling = ScalingInput.Text;
                int scale;
                if (scaling != null && int.TryParse(scaling, out scale))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Bitmap resizedImage = ImageDownsizerUtils.downScaleParallel(myBitmap, scale);
                    stopwatch.Stop();

                    PictureBox imageControl = new PictureBox();
                    imageControl.Height = resizedImage.Height;
                    imageControl.Width = resizedImage.Width;

                    if (resizedImage.Width > Width / 2 || resizedImage.Height > Height / 2)
                    {
                        AutoScroll = true;
                    }

                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image myThumbnail = resizedImage.GetThumbnailImage(resizedImage.Width, resizedImage.Height, myCallback, IntPtr.Zero);
                    imageControl.Image = myThumbnail;

                    pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Size.Width + 15, pictureBox1.Location.Y);
                    pictureBox2.Size = new Size(imageControl.Width, imageControl.Height);
                    pictureBox2.Controls.Add(imageControl);
                    TimeParallel.Text = stopwatch.ElapsedMilliseconds.ToString();
                }
            }
        }
    }
}