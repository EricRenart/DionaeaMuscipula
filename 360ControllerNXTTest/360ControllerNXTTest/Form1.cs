using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonoBrick.NXT;
using J2i.Net.XInputWrapper;
using System.Threading;

namespace _360ControllerNXTTest
{
    public partial class Form1 : Form
    {
        const string PORT = "usb";
        bool isControllerEnabled;
        Brick<Sensor, Sensor, Sensor, Sensor> nxt;
        Recorder recorder;
        XboxController selectedController;
        Thread actualControllerThread;


        public Form1()
        {
            nxt = new Brick<Sensor, Sensor, Sensor, Sensor>(PORT);
            nxt.Sensor4 = new NXTLightSensor();
            recorder = new Recorder(nxt,30); // Hardcoded for now - change recording duration here
            InitializeComponent();
            isControllerEnabled = false;
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
                selectedController = XboxController.RetrieveController(0);
                double leftMotorSpeed = 10;
                double rightMotorSpeed = 10;
                selectedController.Vibrate(leftMotorSpeed, rightMotorSpeed, TimeSpan.FromSeconds(2.0));
                
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
            if (!isControllerEnabled)
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
            if (!isControllerEnabled)
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
            if (!isControllerEnabled)
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
            if (!isControllerEnabled)
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
            if (!isControllerEnabled)
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
            if (!isControllerEnabled)
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

        private void startControllerInputButton_Click(object sender, EventArgs e)
        {
            if (!isControllerEnabled)
            {
                selectedController = XboxController.RetrieveController(0);
                ControllerThread cThread = new ControllerThread(nxt, selectedController);
                actualControllerThread = new Thread(new ThreadStart(cThread.StartControllerInput));
                actualControllerThread.Start();
            }
            else
            {
                actualControllerThread.Abort();
                isControllerEnabled = false;
            }
        }

        // Updates the controller button to provide feedback to the user
        private void UpdateButton(string text, System.Drawing.Color color)
        {
            startControllerInputButton.Text = text;
            startControllerInputButton.BackColor = color;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Ultrasonic Sensor Details button
            SensorStatus sensStatus = new SensorStatus(nxt.Sensor4);
            sensStatus.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Record button

            // stop all motors
            nxt.MotorA.Off();
            nxt.MotorB.Off();
            nxt.MotorC.Off();

            // start recording
            recorder.StartRecording();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Playback button
            if (recorder.IsLocked())
            {
                Console.WriteLine("Please wait until recording length has finished.");
            }
            else
            {
                recorder.PlaybackRecording();
            }
        }
    }
}
