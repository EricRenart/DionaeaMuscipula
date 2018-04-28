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
        const string PORT = "com7";
        bool isActive;
        bool isRecording;
        Brick<Sensor,NXTLightSensor,NXTLightSensor,Sonar> nxt;
        Queue<MoveCommand> commandQueue;

        public Form1()
        {
            InitializeComponent();
            nxt = new Brick<Sensor,NXTLightSensor,NXTLightSensor,Sonar>(PORT);
            commandQueue = new Queue<MoveCommand>();
            isActive = true;
            isRecording = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //motorTestSequence(nxt, 20, 3000);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // First connect
            nxt.Connection.Open();

            // load sensors
            nxt.Sensor2 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor3 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor4 = new Sonar();

            Console.WriteLine(nxt.Sensor2.ReadLightLevel());
            Console.WriteLine(nxt.Sensor3.ReadLightLevel());
            

            // Update dialog
            UpdateReadouts();
            

            if(isRecording)
            {
                // Record stuff
            }
            
        }

        private void UpdateReadouts()
        {
            int light1 = nxt.Sensor2.ReadLightLevel();
            int light2 = nxt.Sensor3.ReadLightLevel();
            int us = nxt.Sensor4.ReadDistance();
            Light1Value.Text = light1.ToString();
            Light2Value.Text = light2.ToString();
            UltrasonicValue.Text = us.ToString();  // update readouts
            Light1Value.Update();
            Light2Value.Update();
            UltrasonicValue.Update();
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {

        }

        private void PlaybackMovements_Click(object sender, EventArgs e)
        {

        }
    }
}
