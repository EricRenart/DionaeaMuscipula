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
            this.controllerTestButton = new System.Windows.Forms.Button();
            this.lpincerOpenButton = new System.Windows.Forms.Button();
            this.rPincerCloseButton = new System.Windows.Forms.Button();
            this.boomUpButton = new System.Windows.Forms.Button();
            this.ttLeftButton = new System.Windows.Forms.Button();
            this.boomDownButton = new System.Windows.Forms.Button();
            this.ttRightButton = new System.Windows.Forms.Button();
            this.startControllerInputButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nxtTestButton
            // 
            this.nxtTestButton.Location = new System.Drawing.Point(6, 6);
            this.nxtTestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nxtTestButton.Name = "nxtTestButton";
            this.nxtTestButton.Size = new System.Drawing.Size(302, 59);
            this.nxtTestButton.TabIndex = 0;
            this.nxtTestButton.Text = "NXT Connection Test";
            this.nxtTestButton.UseVisualStyleBackColor = true;
            this.nxtTestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // controllerTestButton
            // 
            this.controllerTestButton.Location = new System.Drawing.Point(6, 69);
            this.controllerTestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controllerTestButton.Name = "controllerTestButton";
            this.controllerTestButton.Size = new System.Drawing.Size(302, 59);
            this.controllerTestButton.TabIndex = 1;
            this.controllerTestButton.Text = "Controller Connection Test";
            this.controllerTestButton.UseVisualStyleBackColor = true;
            this.controllerTestButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lpincerOpenButton
            // 
            this.lpincerOpenButton.Location = new System.Drawing.Point(11, 257);
            this.lpincerOpenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lpincerOpenButton.Name = "lpincerOpenButton";
            this.lpincerOpenButton.Size = new System.Drawing.Size(117, 51);
            this.lpincerOpenButton.TabIndex = 3;
            this.lpincerOpenButton.Text = "Pincer OPEN";
            this.lpincerOpenButton.UseVisualStyleBackColor = true;
            this.lpincerOpenButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // rPincerCloseButton
            // 
            this.rPincerCloseButton.Location = new System.Drawing.Point(191, 257);
            this.rPincerCloseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rPincerCloseButton.Name = "rPincerCloseButton";
            this.rPincerCloseButton.Size = new System.Drawing.Size(120, 51);
            this.rPincerCloseButton.TabIndex = 6;
            this.rPincerCloseButton.Text = "Pincer CLOSE";
            this.rPincerCloseButton.UseVisualStyleBackColor = true;
            this.rPincerCloseButton.Click += new System.EventHandler(this.rPincerCloseButton_Click);
            // 
            // boomUpButton
            // 
            this.boomUpButton.Location = new System.Drawing.Point(96, 144);
            this.boomUpButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boomUpButton.Name = "boomUpButton";
            this.boomUpButton.Size = new System.Drawing.Size(117, 26);
            this.boomUpButton.TabIndex = 7;
            this.boomUpButton.Text = "Boom UP";
            this.boomUpButton.UseVisualStyleBackColor = true;
            this.boomUpButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // ttLeftButton
            // 
            this.ttLeftButton.Location = new System.Drawing.Point(11, 174);
            this.ttLeftButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ttLeftButton.Name = "ttLeftButton";
            this.ttLeftButton.Size = new System.Drawing.Size(117, 26);
            this.ttLeftButton.TabIndex = 8;
            this.ttLeftButton.Text = "Turntable LEFT";
            this.ttLeftButton.UseVisualStyleBackColor = true;
            this.ttLeftButton.Click += new System.EventHandler(this.Button8_Click);
            // 
            // boomDownButton
            // 
            this.boomDownButton.Location = new System.Drawing.Point(96, 204);
            this.boomDownButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boomDownButton.Name = "boomDownButton";
            this.boomDownButton.Size = new System.Drawing.Size(117, 26);
            this.boomDownButton.TabIndex = 9;
            this.boomDownButton.Text = "Boom DOWN";
            this.boomDownButton.UseVisualStyleBackColor = true;
            this.boomDownButton.Click += new System.EventHandler(this.boomDownButton_Click);
            // 
            // ttRightButton
            // 
            this.ttRightButton.Location = new System.Drawing.Point(191, 174);
            this.ttRightButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ttRightButton.Name = "ttRightButton";
            this.ttRightButton.Size = new System.Drawing.Size(117, 26);
            this.ttRightButton.TabIndex = 10;
            this.ttRightButton.Text = "Turntable RIGHT";
            this.ttRightButton.UseVisualStyleBackColor = true;
            this.ttRightButton.Click += new System.EventHandler(this.ttRightButton_Click);
            // 
            // startControllerInputButton
            // 
            this.startControllerInputButton.BackColor = System.Drawing.Color.IndianRed;
            this.startControllerInputButton.Location = new System.Drawing.Point(11, 321);
            this.startControllerInputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startControllerInputButton.Name = "startControllerInputButton";
            this.startControllerInputButton.Size = new System.Drawing.Size(297, 44);
            this.startControllerInputButton.TabIndex = 11;
            this.startControllerInputButton.Text = "Controller: SAFE";
            this.startControllerInputButton.UseVisualStyleBackColor = false;
            this.startControllerInputButton.Click += new System.EventHandler(this.startControllerInputButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 369);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 22);
            this.button1.TabIndex = 12;
            this.button1.Text = "Ultrasonic Sensor Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 401);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Record Control Sequence";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(162, 401);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 34);
            this.button3.TabIndex = 14;
            this.button3.Text = "Playback Stored Sequence";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 448);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startControllerInputButton);
            this.Controls.Add(this.ttRightButton);
            this.Controls.Add(this.boomDownButton);
            this.Controls.Add(this.ttLeftButton);
            this.Controls.Add(this.boomUpButton);
            this.Controls.Add(this.rPincerCloseButton);
            this.Controls.Add(this.lpincerOpenButton);
            this.Controls.Add(this.controllerTestButton);
            this.Controls.Add(this.nxtTestButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "MonoBrick Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nxtTestButton;
        private System.Windows.Forms.Button controllerTestButton;
        private System.Windows.Forms.Button lpincerOpenButton;
        private System.Windows.Forms.Button rPincerCloseButton;
        private System.Windows.Forms.Button boomUpButton;
        private System.Windows.Forms.Button ttLeftButton;
        private System.Windows.Forms.Button boomDownButton;
        private System.Windows.Forms.Button ttRightButton;
        private System.Windows.Forms.Button startControllerInputButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

