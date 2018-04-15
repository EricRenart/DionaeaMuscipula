namespace _360ControllerNXTTest
{
    partial class SensorStatus
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
            this.SensorDialogTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.setSensBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.setSensButton = new System.Windows.Forms.Button();
            this.currSensLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.curerntSensReadingLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.setSensBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SensorDialogTitle
            // 
            this.SensorDialogTitle.AutoSize = true;
            this.SensorDialogTitle.Location = new System.Drawing.Point(77, 19);
            this.SensorDialogTitle.Name = "SensorDialogTitle";
            this.SensorDialogTitle.Size = new System.Drawing.Size(249, 25);
            this.SensorDialogTitle.TabIndex = 0;
            this.SensorDialogTitle.Text = "Ultrasonic Sensor Status";
            this.SensorDialogTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set Sensitivity:";
            // 
            // setSensBox
            // 
            this.setSensBox.Location = new System.Drawing.Point(172, 197);
            this.setSensBox.Name = "setSensBox";
            this.setSensBox.Size = new System.Drawing.Size(120, 31);
            this.setSensBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Sensitivity:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // setSensButton
            // 
            this.setSensButton.Location = new System.Drawing.Point(298, 188);
            this.setSensButton.Name = "setSensButton";
            this.setSensButton.Size = new System.Drawing.Size(85, 47);
            this.setSensButton.TabIndex = 4;
            this.setSensButton.Text = "Set";
            this.setSensButton.UseVisualStyleBackColor = true;
            // 
            // currSensLabel
            // 
            this.currSensLabel.AutoSize = true;
            this.currSensLabel.Location = new System.Drawing.Point(212, 145);
            this.currSensLabel.Name = "currSensLabel";
            this.currSensLabel.Size = new System.Drawing.Size(163, 25);
            this.currSensLabel.TabIndex = 5;
            this.currSensLabel.Text = "<SENSITIVITY>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sensor Value:";
            // 
            // curerntSensReadingLabel
            // 
            this.curerntSensReadingLabel.AutoSize = true;
            this.curerntSensReadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curerntSensReadingLabel.Location = new System.Drawing.Point(165, 78);
            this.curerntSensReadingLabel.Name = "curerntSensReadingLabel";
            this.curerntSensReadingLabel.Size = new System.Drawing.Size(161, 37);
            this.curerntSensReadingLabel.TabIndex = 7;
            this.curerntSensReadingLabel.Text = "<VALUE>";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(108, 265);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(165, 34);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SensorStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 311);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.curerntSensReadingLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currSensLabel);
            this.Controls.Add(this.setSensButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setSensBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SensorDialogTitle);
            this.Name = "SensorStatus";
            this.Text = "SensorStatus";
            ((System.ComponentModel.ISupportInitialize)(this.setSensBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SensorDialogTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown setSensBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setSensButton;
        private System.Windows.Forms.Label currSensLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label curerntSensReadingLabel;
        private System.Windows.Forms.Button closeButton;
    }
}