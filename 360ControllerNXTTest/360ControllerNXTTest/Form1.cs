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
    struct SensorData
    {
        public int light1Pct;
        public int light2Pct;
        public int sonarCm;
    }

    public partial class Form1 : Form
    {
        const string PORT = "usb";
        bool isActive;
        bool isRecording;
        Brick<Sensor, Sensor, Sensor, Sensor> nxt;
        NXTLightSensor ls1;
        NXTLightSensor ls2;
        Sonar sonar;
        Queue<MoveCommand> commandQueue;

        public Form1()
        {
            InitializeComponent();
            nxt = new Brick<Sensor, Sensor, Sensor, Sensor>(PORT);
            ls1 = new NXTLightSensor(LightMode.Off);
            ls2 = new NXTLightSensor(LightMode.Off);
            sonar = new Sonar(SonarMode.Centimeter);
            nxt.Sensor1 = ls1;
            nxt.Sensor2 = ls2;
            nxt.Sensor3 = sonar;
            commandQueue = new Queue<MoveCommand>();
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

        // Testing methods
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
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

        private void boomDownButton_Click(object sender, EventArgs e)
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

        private void rPincerCloseButton_Click(object sender, EventArgs e)
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

        private void ttRightButton_Click(object sender, EventArgs e)
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

        private void updateReadouts(SensorData newData)
        {
            Light1Value.Text = newData.light1Pct.ToString();
            Light2Value.Text = newData.light2Pct.ToString();
            UltrasonicValue.Text = newData.sonarCm.ToString();

            // update readouts
            Light1Value.Update();
            Light2Value.Update();
            UltrasonicValue.Update();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
