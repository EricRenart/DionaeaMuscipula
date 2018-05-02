using MonoBrick.NXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DionaeaMuscipula
{
    class RobotThread
    {
        bool isActive;
        bool clawLock;
        bool tauntPlayed;
        bool keyboardControl; // is keyboard control enabled?
        int lockElapsed = 0;
        int begTimerElapsed = 0;
        Brick<TouchSensor, Sensor,Sensor,Sensor> nxt;
        int lastX, lastY = 0;

        /*
         * VENUS FLYTRAP BOT
         * MOVEMENT SETTINGS
         * 
         * Change the following constant ints to modify the behavior of the robot.
         */

        // Booleans
        const bool LIGHT_SENS_ENABLED = false;
        const bool SONAR_ENABLED = true;
        const bool SONAR_TESTING_MODE = true;
        const bool BEGGING = false; // Change this to false to disable the periodic "Please, is anybody around" phrase

        // Ints
        const int LIGHT_DIFF = 2; //difference between light sensor values in order for the arm to move in a direction
        const int SONAR_THRESHOLD = 25; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut
        const int CLAW_LOCK_INTERVAL = 25; // lock the claw for ~5 sec after hand is freed via touch sensor
        const int BEG_INTERVAL = 150; // beg for human contact every ~30s by playing an rso
        const int ARM_WRESTLE_INTERVAL = 150; // total duration of the random arm movement in "wrestle mode"
        const int NUMBER_OF_ARM_MOVEMENTS = 100; // number of random movements the robot arm will make when it enters "wrestle mode"
        const int MOVEMENT_RANGE = 60; // number of degrees the robot arm is limited to moving to in a direction during the arm wrestling 
        const int SLEW_SPEED = 30; // speed of the arm when it is slewn by the keyboard
        const int SLEW_SPEED_CLAW = 10;
        
        // END MOVEMENT SETTINGS

        public RobotThread(Brick<TouchSensor, Sensor,Sensor,Sensor> nxti)
        {
            nxt = nxti;
            isActive = true;
            clawLock = false;
            tauntPlayed = false;
        }

        public void start()
        {
            // First connect
            nxt.Connection.Open();

            // load sensors
            nxt.Sensor1 = new TouchSensor();

            //nxt.PlaySoundFile("letmeshakehand.rso", false);

            // ----------- Main Loop ---------------

            while (isActive)
            {

                // get the current key pressed and move the arm appropriately
                while(Form1.keyPressed.Equals(Keys.W))
                {
                    nxt.MotorB.On(SLEW_SPEED);
                }
                while(Form1.keyPressed.Equals(Keys.A))
                {
                    nxt.MotorA.On(SLEW_SPEED);
                }
                while(Form1.keyPressed.Equals(Keys.S))
                {
                    nxt.MotorB.On(-1 * SLEW_SPEED);
                }
                while(Form1.keyPressed.Equals(Keys.D))
                {
                    nxt.MotorA.On(-1*SLEW_SPEED);
                }
                while(Form1.keyPressed.Equals(Keys.Q))
                {
                    nxt.MotorC.On(SLEW_SPEED_CLAW);
                }
                while(Form1.keyPressed.Equals(Keys.E))
                {
                    nxt.MotorC.On(-1 * SLEW_SPEED_CLAW);
                }
                if (Form1.keyPressed.Equals(Keys.None))
                {
                    nxt.MotorA.Off();
                    nxt.MotorB.Off();
                    nxt.MotorC.Off();
                }

                // If the touch sensor is pressed...
                if(nxt.Sensor1.Read() == 1)
                {
                    nxt.MotorC.On(-100);
                    Thread.Sleep(2000);
                    nxt.MotorC.On(100);
                    Thread.Sleep(500);
                }
            }

            // --------- End Main Loop -------------
        }

        
       
}
}
