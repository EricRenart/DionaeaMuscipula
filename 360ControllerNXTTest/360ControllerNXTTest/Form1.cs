using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonoBrick.NXT;
using System.Threading;

namespace _360ControllerNXTTest
{
    public partial class Form1 : Form
    {
        const string PORT = "usb";
        bool isWiimoteEnabled;
        Brick<Sensor, Sensor, Sensor, Sensor> nxt;
        RobotCommunicator communicator;


        public Form1()
        {
            InitializeComponent();
            nxt = new Brick<Sensor, Sensor, Sensor, Sensor>(PORT);
            // spin up a RobotCommunicator instance
            communicator = new RobotCommunicator(nxt);
            Thread commThread = new Thread(new ThreadStart(communicator.Start));
            commThread.Start();
            Console.WriteLine("Robot communication thread started.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                motorTestSequence(nxt, 20, 3000);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                double leftMotorSpeed = 10;
                double rightMotorSpeed = 10;
                
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void motorTestSequence(Brick<Sensor,Sensor,Sensor,Sensor> brick, int power, int delay)
        {
            brick.Connection.Open();
            brick.MotorA.On((sbyte)power);
            System.Threading.Thread.Sleep(delay);
            brick.MotorA.On((sbyte)(power * -1));
            System.Threading.Thread.Sleep(delay);
            brick.MotorA.Off();
            brick.MotorB.On((sbyte)power);
            System.Threading.Thread.Sleep(delay);
            brick.MotorB.On((sbyte)(power * -1));
            System.Threading.Thread.Sleep(delay);
            brick.MotorB.Off();
            brick.MotorC.On((sbyte)power);
            System.Threading.Thread.Sleep(delay);
            brick.MotorC.On((sbyte)(power * -1));
            System.Threading.Thread.Sleep(delay);
            brick.MotorC.Off();
            brick.Connection.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorA.On(20);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorA.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorC.On(10);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorC.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorB.On(20);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorB.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void boomDownButton_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorB.On(-20);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorB.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void rPincerCloseButton_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorC.On(-10);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorC.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void ttRightButton_Click(object sender, EventArgs e)
        {
            if (!isWiimoteEnabled)
            {
                try
                {
                    nxt.Connection.Open();
                    nxt.MotorA.On(-20);
                    System.Threading.Thread.Sleep(1000);
                    nxt.MotorA.Off();
                    nxt.Connection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
