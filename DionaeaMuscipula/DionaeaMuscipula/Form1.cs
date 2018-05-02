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
        public static Keys keyPressed;
        Brick<TouchSensor, Sensor,Sensor,Sensor> brick;


        public Form1()
        {
            InitializeComponent();
            brick = new Brick<TouchSensor, Sensor,Sensor,Sensor>(DORM_PC); // set connection option here
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

        private void PlaybackMovements_Click(object sender, EventArgs e)
        {

        }

        // handle key presses
        private void onKeyPress(Object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.ToString());
            keyPressed = e.KeyCode;
        }

        // reset key press info
        private void invalidateKeys(Object sender, KeyEventArgs e)
        {
            keyPressed = Keys.None;
        }
    }
}
