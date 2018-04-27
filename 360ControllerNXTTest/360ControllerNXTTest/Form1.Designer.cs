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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            // controllerTestButton
            // 
            this.controllerTestButton.Location = new System.Drawing.Point(6, 74);
            this.controllerTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.controllerTestButton.Name = "controllerTestButton";
            this.controllerTestButton.Size = new System.Drawing.Size(302, 59);
            this.controllerTestButton.TabIndex = 1;
            this.controllerTestButton.Text = "Controller Connection Test";
            this.controllerTestButton.UseVisualStyleBackColor = true;
            this.controllerTestButton.Click += new System.EventHandler(this.Button2_Click);
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
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 158);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller Bindings";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "(DPad Up) Move Arm Up";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "(DPad Down) Move Arm Down";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "(DPad Left) Move Arm Left";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "(DPad Right) Move Arm Right";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "[LB] Open Claw";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "[RB] Close Claw";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(109, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "(Y) Playback Path";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(18, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "(X) Record Path";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(77, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "(A) Enable/Disable Hand Tracking";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(213, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "(B) Disconnect";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ttRightButton);
            this.Controls.Add(this.boomDownButton);
            this.Controls.Add(this.ttLeftButton);
            this.Controls.Add(this.boomUpButton);
            this.Controls.Add(this.lpincerOpenButton);
            this.Controls.Add(this.controllerTestButton);
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
        private System.Windows.Forms.Button controllerTestButton;
        private System.Windows.Forms.Button lpincerOpenButton;
        private System.Windows.Forms.Button rPincerCloseButton;
        private System.Windows.Forms.Button boomUpButton;
        private System.Windows.Forms.Button ttLeftButton;
        private System.Windows.Forms.Button boomDownButton;
        private System.Windows.Forms.Button ttRightButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

