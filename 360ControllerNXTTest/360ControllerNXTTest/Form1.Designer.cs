namespace _360ControllerNXTTest
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
            this.lpincerOpenButton = new System.Windows.Forms.Button();
            this.rPincerCloseButton = new System.Windows.Forms.Button();
            this.boomUpButton = new System.Windows.Forms.Button();
            this.ttLeftButton = new System.Windows.Forms.Button();
            this.boomDownButton = new System.Windows.Forms.Button();
            this.ttRightButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UltrasonicValue = new System.Windows.Forms.Label();
            this.Light2Value = new System.Windows.Forms.Label();
            this.Light1Value = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RecordButton = new System.Windows.Forms.Button();
            this.PlaybackButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nxtTestButton
            // 
            this.nxtTestButton.Location = new System.Drawing.Point(6, 11);
            this.nxtTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.nxtTestButton.Name = "nxtTestButton";
            this.nxtTestButton.Size = new System.Drawing.Size(302, 59);
            this.nxtTestButton.TabIndex = 0;
            this.nxtTestButton.Text = "NXT Connection Test";
            this.nxtTestButton.UseVisualStyleBackColor = true;
            this.nxtTestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // lpincerOpenButton
            // 
            this.lpincerOpenButton.Location = new System.Drawing.Point(11, 279);
            this.lpincerOpenButton.Margin = new System.Windows.Forms.Padding(2);
            this.lpincerOpenButton.Name = "lpincerOpenButton";
            this.lpincerOpenButton.Size = new System.Drawing.Size(117, 51);
            this.lpincerOpenButton.TabIndex = 3;
            this.lpincerOpenButton.Text = "Pincer OPEN";
            this.lpincerOpenButton.UseVisualStyleBackColor = true;
            this.lpincerOpenButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // rPincerCloseButton
            // 
            this.rPincerCloseButton.Location = new System.Drawing.Point(180, 124);
            this.rPincerCloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.rPincerCloseButton.Name = "rPincerCloseButton";
            this.rPincerCloseButton.Size = new System.Drawing.Size(120, 51);
            this.rPincerCloseButton.TabIndex = 6;
            this.rPincerCloseButton.Text = "Pincer CLOSE";
            this.rPincerCloseButton.UseVisualStyleBackColor = true;
            this.rPincerCloseButton.Click += new System.EventHandler(this.rPincerCloseButton_Click);
            // 
            // boomUpButton
            // 
            this.boomUpButton.Location = new System.Drawing.Point(96, 166);
            this.boomUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.boomUpButton.Name = "boomUpButton";
            this.boomUpButton.Size = new System.Drawing.Size(117, 26);
            this.boomUpButton.TabIndex = 7;
            this.boomUpButton.Text = "Boom UP";
            this.boomUpButton.UseVisualStyleBackColor = true;
            this.boomUpButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // ttLeftButton
            // 
            this.ttLeftButton.Location = new System.Drawing.Point(11, 196);
            this.ttLeftButton.Margin = new System.Windows.Forms.Padding(2);
            this.ttLeftButton.Name = "ttLeftButton";
            this.ttLeftButton.Size = new System.Drawing.Size(117, 26);
            this.ttLeftButton.TabIndex = 8;
            this.ttLeftButton.Text = "Turntable LEFT";
            this.ttLeftButton.UseVisualStyleBackColor = true;
            this.ttLeftButton.Click += new System.EventHandler(this.Button8_Click);
            // 
            // boomDownButton
            // 
            this.boomDownButton.Location = new System.Drawing.Point(96, 226);
            this.boomDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.boomDownButton.Name = "boomDownButton";
            this.boomDownButton.Size = new System.Drawing.Size(117, 26);
            this.boomDownButton.TabIndex = 9;
            this.boomDownButton.Text = "Boom DOWN";
            this.boomDownButton.UseVisualStyleBackColor = true;
            this.boomDownButton.Click += new System.EventHandler(this.boomDownButton_Click);
            // 
            // ttRightButton
            // 
            this.ttRightButton.Location = new System.Drawing.Point(191, 196);
            this.ttRightButton.Margin = new System.Windows.Forms.Padding(2);
            this.ttRightButton.Name = "ttRightButton";
            this.ttRightButton.Size = new System.Drawing.Size(117, 26);
            this.ttRightButton.TabIndex = 10;
            this.ttRightButton.Text = "Turntable RIGHT";
            this.ttRightButton.UseVisualStyleBackColor = true;
            this.ttRightButton.Click += new System.EventHandler(this.ttRightButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rPincerCloseButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 186);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Override";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UltrasonicValue);
            this.groupBox2.Controls.Add(this.Light2Value);
            this.groupBox2.Controls.Add(this.Light1Value);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 158);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Sensor Readings";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // UltrasonicValue
            // 
            this.UltrasonicValue.AutoSize = true;
            this.UltrasonicValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UltrasonicValue.Location = new System.Drawing.Point(95, 115);
            this.UltrasonicValue.Name = "UltrasonicValue";
            this.UltrasonicValue.Size = new System.Drawing.Size(121, 20);
            this.UltrasonicValue.TabIndex = 5;
            this.UltrasonicValue.Text = "UltrasonicValue";
            // 
            // Light2Value
            // 
            this.Light2Value.AutoSize = true;
            this.Light2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Light2Value.Location = new System.Drawing.Point(182, 55);
            this.Light2Value.Name = "Light2Value";
            this.Light2Value.Size = new System.Drawing.Size(94, 20);
            this.Light2Value.TabIndex = 4;
            this.Light2Value.Text = "Light2Value";
            // 
            // Light1Value
            // 
            this.Light1Value.AutoSize = true;
            this.Light1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Light1Value.Location = new System.Drawing.Point(23, 55);
            this.Light1Value.Name = "Light1Value";
            this.Light1Value.Size = new System.Drawing.Size(94, 20);
            this.Light1Value.TabIndex = 3;
            this.Light1Value.Text = "Light1Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ultrasonic/Prox";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Light 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Light 1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(6, 511);
            this.RecordButton.Margin = new System.Windows.Forms.Padding(2);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(117, 51);
            this.RecordButton.TabIndex = 13;
            this.RecordButton.Text = "Record Path";
            this.RecordButton.UseVisualStyleBackColor = true;
            // 
            // PlaybackButton
            // 
            this.PlaybackButton.Location = new System.Drawing.Point(189, 511);
            this.PlaybackButton.Margin = new System.Windows.Forms.Padding(2);
            this.PlaybackButton.Name = "PlaybackButton";
            this.PlaybackButton.Size = new System.Drawing.Size(117, 51);
            this.PlaybackButton.TabIndex = 14;
            this.PlaybackButton.Text = "Playback Path";
            this.PlaybackButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 568);
            this.Controls.Add(this.PlaybackButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ttRightButton);
            this.Controls.Add(this.boomDownButton);
            this.Controls.Add(this.ttLeftButton);
            this.Controls.Add(this.boomUpButton);
            this.Controls.Add(this.lpincerOpenButton);
            this.Controls.Add(this.nxtTestButton);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MonoBrick Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nxtTestButton;
        private System.Windows.Forms.Button lpincerOpenButton;
        private System.Windows.Forms.Button rPincerCloseButton;
        private System.Windows.Forms.Button boomUpButton;
        private System.Windows.Forms.Button ttLeftButton;
        private System.Windows.Forms.Button boomDownButton;
        private System.Windows.Forms.Button ttRightButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UltrasonicValue;
        private System.Windows.Forms.Label Light2Value;
        private System.Windows.Forms.Label Light1Value;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button PlaybackButton;
    }
}

