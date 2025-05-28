namespace SpotDifferenceGames
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.ChoosePicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelAttempts = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLeft.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(550, 550);
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRight.Location = new System.Drawing.Point(568, 12);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(550, 550);
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Click);
            // 
            // ChoosePicture
            // 
            this.ChoosePicture.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ChoosePicture.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoosePicture.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ChoosePicture.Location = new System.Drawing.Point(12, 580);
            this.ChoosePicture.Name = "ChoosePicture";
            this.ChoosePicture.Size = new System.Drawing.Size(150, 32);
            this.ChoosePicture.TabIndex = 2;
            this.ChoosePicture.Text = "Choose a picture";
            this.ChoosePicture.UseVisualStyleBackColor = false;
            this.ChoosePicture.Click += new System.EventHandler(this.ChoosePicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Agency FB", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(407, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of detected differences:        ";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Agency FB", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(407, 613);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of remaining differences:      ";
            //this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelTimer.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelTimer.Location = new System.Drawing.Point(676, 613);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(42, 24);
            this.labelTimer.TabIndex = 6;
            this.labelTimer.Text = "Timer";
            //this.labelTimer.Click += new System.EventHandler(this.labelTimer_Click);
            // 
            // labelAttempts
            // 
            this.labelAttempts.AutoSize = true;
            this.labelAttempts.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelAttempts.Font = new System.Drawing.Font("Agency FB", 12F);
            this.labelAttempts.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelAttempts.Location = new System.Drawing.Point(676, 581);
            this.labelAttempts.Name = "labelAttempts";
            this.labelAttempts.Size = new System.Drawing.Size(128, 24);
            this.labelAttempts.TabIndex = 7;
            this.labelAttempts.Text = "Remaining attempts:";
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comboBoxLevel.Font = new System.Drawing.Font("Agency FB", 12F);
            this.comboBoxLevel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(178, 581);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(200, 32);
            this.comboBoxLevel.TabIndex = 8;
            this.comboBoxLevel.Text = "Choose a level";
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 704);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.labelAttempts);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChoosePicture);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Name = "Form1";
            this.Text = "Spot the Difference Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button ChoosePicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelAttempts;
        private System.Windows.Forms.ComboBox comboBoxLevel;
    }
}

