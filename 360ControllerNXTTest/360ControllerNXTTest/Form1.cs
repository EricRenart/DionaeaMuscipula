using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoBrick.NXT;
using J2i.Net.XInputWrapper;


namespace _360ControllerNXTTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nxt = new Brick<Sensor, Sensor, Sensor, Sensor>("com3");
            try
            {
                nxt.Connection.Open();
                nxt.MotorB.On(40);
                System.Threading.Thread.Sleep(2000);
                nxt.MotorB.Off();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedController = XboxController.RetrieveController(0);
                double leftMotorSpeed = 10;
                double rightMotorSpeed = 10;
                selectedController.Vibrate(leftMotorSpeed, rightMotorSpeed, TimeSpan.FromSeconds(2.0));
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
