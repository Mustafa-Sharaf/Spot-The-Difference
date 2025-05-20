using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave; 

namespace SpotDifferenceGames
{
    public partial class Form1 : Form
    {
      private int imageLoadCount = 0;
      private Timer gameTimer;
      private Timer displayTimer;   
      private int timeLeft;
      private int wrongAttempts = 0;
      private const int MaxWrongAttempts = 6;
      private int gameLevel = 0; 
      private List<(Point location, bool isDifference, bool isLeft)> clickPoints = new List<(Point, bool, bool)>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; 
   
            pictureBoxLeft.MouseClick += PictureBox_Click;
            pictureBoxRight.MouseClick += PictureBox_Click;

            pictureBoxLeft.Paint += PictureBox_Paint;
            pictureBoxRight.Paint += PictureBox_Paint;
        }

        private void ChoosePicture_Click(object sender, EventArgs e)
        {
            if (gameLevel == 0)
            {
                MessageBox.Show("الرجاء اختيار مستوى قبل تحميل الصور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);

                    if (imageLoadCount == 0)
                    {
                        pictureBoxLeft.Image = selectedImage;
                        pictureBoxLeft.Width = selectedImage.Width;
                        pictureBoxLeft.Height = selectedImage.Height;
                        pictureBoxLeft.SizeMode = PictureBoxSizeMode.Normal;
                        imageLoadCount++;
                    }
                    else if (imageLoadCount == 1)
                    {
                        pictureBoxRight.Image = selectedImage;
                        pictureBoxRight.Width = selectedImage.Width;
                        pictureBoxRight.Height = selectedImage.Height;
                        pictureBoxRight.SizeMode = PictureBoxSizeMode.Normal;
                        imageLoadCount++;

                        if (gameLevel >= 2)
                            StartGameTimer();

                        ChoosePicture.Enabled = false;
                    }
                }
            }
        }

        private void PictureBox_Click(object sender, MouseEventArgs e)
        {
            var clickedBox = sender as PictureBox;
            bool isLeft = clickedBox == pictureBoxLeft;

            if (pictureBoxLeft.Image == null || pictureBoxRight.Image == null)
                return;

            int imageX = e.X;
            int imageY = e.Y;

            Bitmap bmpLeft = (Bitmap)pictureBoxLeft.Image;
            Bitmap bmpRight = (Bitmap)pictureBoxRight.Image;

            bool isDifferent = IsRegionDifferent(bmpLeft, bmpRight, imageX, imageY);

            clickPoints.Add((e.Location, isDifferent, isLeft));

            Point mirroredPoint = new Point(e.X, e.Y);
            clickPoints.Add((mirroredPoint, isDifferent, !isLeft));

            pictureBoxLeft.Invalidate();
            pictureBoxRight.Invalidate();

            if (isDifferent)
            {
                PlayMp3("E:\\Fourth year\\Semester2(2024-2025)\\نظم الوسائط المتعددة\\Multimedia Systems\\true answers .mp3");
                label1.Text = $"Number of detected differences: {GetDiscoveredDifferencesCount()}";
                label2.Text = $"Number of detected differences: {5 - GetDiscoveredDifferencesCount()}";
                if (GetDiscoveredDifferencesCount()==5)
                {
                    MessageBox.Show($"مبروك لقد ربحت.", "مبروك", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

            }
            else
            {
                PlayMp3("E:\\Fourth year\\Semester2(2024-2025)\\نظم الوسائط المتعددة\\Multimedia Systems\\wrong answers .mp3");
                if (gameLevel == 3|| gameLevel == 2) 
                {
                    wrongAttempts++;
                    UpdateAttemptsLabel();
                    if (wrongAttempts >= MaxWrongAttempts)
                    {
                        displayTimer?.Stop();
                        gameTimer?.Stop();

                        MessageBox.Show($"لقد خسرت اللعبة! تجاوزت الحد الأقصى للمحاولات (3).", "خسارة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        return;
                    }
                }
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            bool isLeft = pb == pictureBoxLeft;

            foreach (var (location, isDifference, pointIsLeft) in clickPoints)
            {
                if (isDifference)
                {
                    e.Graphics.DrawEllipse(Pens.Green, location.X - 20, location.Y - 20, 40, 40);
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Red, location.X - 15, location.Y - 15, location.X + 15, location.Y + 15);
                    e.Graphics.DrawLine(Pens.Red, location.X - 15, location.Y + 15, location.X + 15, location.Y - 15);
                }
            }
        }



        private int ColorDifference(Color c1, Color c2)
        {
            return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
        }

        private bool IsRegionDifferent(Bitmap left, Bitmap right, int centerX, int centerY, int regionSize = 20, int threshold = 30)
        {   int half = regionSize / 2;
            int diffSum = 0;
            int count = 0;

            for (int y = -half; y <= half; y++)
            {
                for (int x = -half; x <= half; x++)
                {
                    int px = centerX + x;
                    int py = centerY + y;

                    if (px < 0 || py < 0 || px >= left.Width || py >= left.Height) continue;

                    Color c1 = left.GetPixel(px, py);
                    Color c2 = right.GetPixel(px, py);
                    diffSum += ColorDifference(c1, c2);
                    count++;
                }
            }
            int averageDiff = diffSum / count;
            return averageDiff > threshold;
        }

        private void PlayMp3(string path)
        {
            var reader = new AudioFileReader(path);
            var player = new WaveOutEvent();

            player.Init(reader);
            player.Play();

            // تخلص من الموارد عند انتهاء التشغيل
            player.PlaybackStopped += (s, e) =>
            {
                player.Dispose();
                reader.Dispose();
            };
        }

        private void StartGameTimer()
        {
            if (gameLevel >= 2) 
            {
                timeLeft = 60;
                gameTimer = new Timer();
                gameTimer.Interval = 60000;
                gameTimer.Tick += GameTimer_Tick;
                gameTimer.Start();

                displayTimer = new Timer();
                displayTimer.Interval = 1000;
                displayTimer.Tick += DisplayTimer_Tick;
                displayTimer.Start();
                UpdateTimerLabel();
            }
            if (gameLevel == 3)
            {
                wrongAttempts = 0;
                UpdateAttemptsLabel();
            }
            else
            {
                labelAttempts.Text = ""; 
            }
        }

        private void UpdateTimerLabel()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            labelTimer.Text = $"Remaining Time : {minutes:D2}:{seconds:D2}";
        }
        private void UpdateAttemptsLabel()
        {
            labelAttempts.Text = $"Remaining Attempts: {(MaxWrongAttempts - wrongAttempts)/2}";
        }

        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            if (timeLeft <= 0)
            {
                displayTimer.Stop();
            }

            UpdateTimerLabel();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameTimer.Stop();
            MessageBox.Show("انتهى الوقت! لقد خسرت اللعبة.", "انتهى الوقت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }
        private int GetDiscoveredDifferencesCount()
        {
            var uniquePoints = new HashSet<Point>();

            foreach (var (location, isDifference, isLeft) in clickPoints)
            {
                if (isDifference && isLeft)
                {
                    uniquePoints.Add(location);
                }
            }

            return uniquePoints.Count;
        }



        private void label1_Click(object sender, EventArgs e)
        {//الفروقات المكتشفة   
        }

        private void label2_Click(object sender, EventArgs e)
        { //الفروقات المتبقية
        }

        private void labelTimer_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameLevel = comboBoxLevel.SelectedIndex + 1;
            switch (gameLevel)
            {
                case 1:
                    labelTimer.Visible = false;
                    labelAttempts.Visible = false;
                    break;

                case 2:
                    labelTimer.Visible = true;
                    labelAttempts.Visible = false;
                    break;

                case 3:
                    labelTimer.Visible = true;
                    labelAttempts.Visible = true;
                    break;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxLevel.Items.Add("Level 1 without timer");
            comboBoxLevel.Items.Add("Level 2 is timer only.");
            comboBoxLevel.Items.Add("Level 3 timer and Points");
          

        }


    }
}
