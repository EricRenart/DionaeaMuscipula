namespace _DionaeaMuscipula
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
            this.nxtTestButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UltrasonicValue = new System.Windows.Forms.Label();
            this.Light2Value = new System.Windows.Forms.Label();
            this.Light1Value = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RecordButton = new System.Windows.Forms.Button();
            this.PlaybackMovements = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nxtTestButton
            // 
            this.nxtTestButton.Location = new System.Drawing.Point(12, 21);
            this.nxtTestButton.Margin = new System.Windows.Forms.Padding(4);
            this.nxtTestButton.Name = "nxtTestButton";
            this.nxtTestButton.Size = new System.Drawing.Size(604, 113);
            this.nxtTestButton.TabIndex = 0;
            this.nxtTestButton.Text = "NXT Connection Test";
            this.nxtTestButton.UseVisualStyleBackColor = true;
            this.nxtTestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UltrasonicValue);
            this.groupBox2.Controls.Add(this.Light2Value);
            this.groupBox2.Controls.Add(this.Light1Value);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(604, 276);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Sensor Readings";
            // 
            // UltrasonicValue
            // 
            this.UltrasonicValue.AutoSize = true;
            this.UltrasonicValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UltrasonicValue.Location = new System.Drawing.Point(190, 221);
            this.UltrasonicValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UltrasonicValue.Name = "UltrasonicValue";
            this.UltrasonicValue.Size = new System.Drawing.Size(242, 37);
            this.UltrasonicValue.TabIndex = 5;
            this.UltrasonicValue.Text = "UltrasonicValue";
            // 
            // Light2Value
            // 
            this.Light2Value.AutoSize = true;
            this.Light2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Light2Value.Location = new System.Drawing.Point(472, 106);
            this.Light2Value.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Light2Value.Name = "Light2Value";
            this.Light2Value.Size = new System.Drawing.Size(187, 37);
            this.Light2Value.TabIndex = 4;
            this.Light2Value.Text = "Light2Value";
            // 
            // Light1Value
            // 
            this.Light1Value.AutoSize = true;
            this.Light1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Light1Value.Location = new System.Drawing.Point(46, 106);
            this.Light1Value.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Light1Value.Name = "Light1Value";
            this.Light1Value.Size = new System.Drawing.Size(185, 37);
            this.Light1Value.TabIndex = 3;
            this.Light1Value.Text = "Light1Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ultrasonic/Prox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Light 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Light 1";
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(13, 445);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(603, 96);
            this.RecordButton.TabIndex = 13;
            this.RecordButton.Text = "Record Movements";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // PlaybackMovements
            // 
            this.PlaybackMovements.Location = new System.Drawing.Point(13, 558);
            this.PlaybackMovements.Name = "PlaybackMovements";
            this.PlaybackMovements.Size = new System.Drawing.Size(603, 96);
            this.PlaybackMovements.TabIndex = 14;
            this.PlaybackMovements.Text = "Playback Movements";
            this.PlaybackMovements.UseVisualStyleBackColor = true;
            this.PlaybackMovements.Click += new System.EventHandler(this.PlaybackMovements_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 685);
            this.Controls.Add(this.PlaybackMovements);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nxtTestButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "MonoBrick Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nxtTestButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UltrasonicValue;
        private System.Windows.Forms.Label Light2Value;
        private System.Windows.Forms.Label Light1Value;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button PlaybackMovements;
    }
}

