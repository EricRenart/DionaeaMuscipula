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

namespace _DionaeaMuscipula
{ 

    public partial class Form1 : Form
    {
        // CONNECTIONS LIST
        // Dorm PC -- com5
        // Surface pro -- com7
        const string DORM_PC = "com6";
        const string SURF_PRO = "com3";
        const string USB = "usb";
        public static char keyPressed;
        Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> brick;


        public Form1()
        {
            InitializeComponent();
            brick = new Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar>(DORM_PC); // set connection option here
            this.KeyPreview = true;
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
            RobotThread thread = new RobotThread(brick);
            Thread newThread = new Thread(new ThreadStart(thread.start));
            newThread.Start();
        }

        private void UpdateReadouts(object sender, EventArgs e)
        {
            Light1Value.Text = brick.Sensor2.ReadAsString();
            Light2Value.Text = brick.Sensor3.ReadAsString();
            UltrasonicValue.Text = brick.Sensor4.ReadAsString();  // update readouts
            Light1Value.Update();
            Light2Value.Update();
            UltrasonicValue.Update();
        }

        private void PlaybackMovements_Click(object sender, EventArgs e)
        {

        }

        // reset key press info
        private void invalidateKeys(Object sender, KeyEventArgs e)
        {
            keyPressed = ' ';
        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.ToString());
            keyPressed = e.KeyChar;
        }
    }
}
