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
        Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxt;
        int lastX, lastY = 0;

        /*
         * VENUS FLYTRAP BOT
         * MOVEMENT SETTINGS
         * 
         * Change the following constant ints to modify the behavior of the robot.
         */

        // Booleans
        const bool LIGHT_SENS_ENABLED = false;
        bool SONAR_ENABLED = true;
        const bool SONAR_TESTING_MODE = true;
        const bool BEGGING = false; // Change this to false to disable the periodic "Please, is anybody around" phrase

        // Ints
        const int LIGHT_DIFF = 2; //difference between light sensor values in order for the arm to move in a direction
        int SONAR_THRESHOLD = 12; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut
        const int CLAW_LOCK_INTERVAL = 25; // lock the claw for ~5 sec after hand is freed via touch sensor
        const int BEG_INTERVAL = 150; // beg for human contact every ~30s by playing an rso
        const int ARM_WRESTLE_INTERVAL = 150; // total duration of the random arm movement in "wrestle mode"
        const int NUMBER_OF_ARM_MOVEMENTS = 100; // number of random movements the robot arm will make when it enters "wrestle mode"
        const int MOVEMENT_RANGE = 60; // number of degrees the robot arm is limited to moving to in a direction during the arm wrestling 
        const int SLEW_SPEED = 30; // speed of the arm when it is slewn by the keyboard
        const int SLEW_SPEED_CLAW = 10;
        
        // END MOVEMENT SETTINGS

        public RobotThread(Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxti)
        {
            nxt = nxti;
            isActive = true;
            clawLock = false;
            tauntPlayed = false;
        }

        public void start()
        {
            // First connect
            try
            {
                nxt.Connection.Open();
            }
            catch (MonoBrick.ConnectionException ce)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ce.InnerException);
            };

            // load sensors
            nxt.Sensor1 = new TouchSensor();
            nxt.Sensor2 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor3 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor4 = new Sonar();
            int light1, light2 = 0;
            int sonar = 0;

            nxt.PlaySoundFile("letmeshakehand.rso", false);

            // ----------- Main Loop ---------------

            while (isActive)
            {
                // read sensor data
                if (LIGHT_SENS_ENABLED)
                {
                    light1 = nxt.Sensor2.ReadLightLevel();
                    light2 = nxt.Sensor3.ReadLightLevel();
                }
                if (SONAR_ENABLED)
                {
                    try
                    {
                        sonar = nxt.Sensor4.ReadDistance();
                    }
                    catch(MonoBrick.ConnectionException ce)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(ce.InnerException);
                        nxt.Connection.Close();
                        nxt.Connection.Open();
                    }
                    catch(MonoBrick.MonoBrickException me)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(me.InnerException);
                        nxt.Connection.Close();
                        nxt.Connection.Open();
                    }
                }

                // get the current key pressed and move the arm appropriately
                while(Form1.keyPressed == 'w')
                {
                    nxt.MotorB.On(SLEW_SPEED);
                }
                while(Form1.keyPressed == 'a')
                {
                    nxt.MotorA.On(SLEW_SPEED);
                }
                while(Form1.keyPressed == 's')
                {
                    nxt.MotorB.On(-1 * SLEW_SPEED);
                }
                while(Form1.keyPressed == 'd')
                {
                    nxt.MotorA.On(-1*SLEW_SPEED);
                }
                while(Form1.keyPressed == 'q')
                {
                    nxt.MotorC.On(SLEW_SPEED_CLAW);
                }
                while(Form1.keyPressed == 'e')
                {
                    nxt.MotorC.On(-1 * SLEW_SPEED_CLAW);
                }
                if(Form1.keyPressed == 'r')
                {
                    if (!SONAR_ENABLED)
                    {
                        Console.WriteLine("Ultrasonic sensor enabled. Use Up/Down keys to change sensitivity");
                        SONAR_ENABLED = true;
                    }
                    else
                    {
                        Console.WriteLine("Ultrasonic sensor disabled.");
                        SONAR_ENABLED = false;
                    }
                    Thread.Sleep(50); // de-bounce
                }
                if(Form1.keyPressed == (char)40)
                {
                    SONAR_THRESHOLD--;
                    Console.WriteLine("Sonar threshold = " + SONAR_THRESHOLD + " cm");
                    Thread.Sleep(50); // de-bounce
                }
                if (Form1.keyPressed == (char)38)
                {
                    SONAR_THRESHOLD++;
                    Console.WriteLine("Sonar threshold = " + SONAR_THRESHOLD + " cm");
                    Thread.Sleep(50); // de-bounce
                }
                if (Form1.keyPressed == ' ')
                {
                    nxt.MotorA.Off();
                    nxt.MotorB.Off();
                    nxt.MotorC.Off();
                }


                if (LIGHT_SENS_ENABLED)
                {
                    // for debugging purposes
                    Console.WriteLine("[" + light1 + "]------[" + light2 + "]");

                    // if the left light sensor reading exceeds the right light sensor reading, move right
                    if (light1 - light2 >= LIGHT_DIFF)
                    {
                        nxt.MotorA.On(-30);
                    }

                    // if the right light sensor reading exceeds the left light sensor reading, move left
                    if (light2 - light1 >= LIGHT_DIFF)
                    {
                        nxt.MotorA.On(30);
                    }


                    // if the difference between sensor values is less than the threshold stop the motor
                    if (Math.Abs(light2 - light1) <= LIGHT_DIFF)
                    {
                        nxt.MotorA.Off();
                    }
                }

                // Capture the hand if it is within the capture interval and the claw is not locked.
                if (SONAR_ENABLED && !SONAR_TESTING_MODE)
                {

                    if (sonar < SONAR_THRESHOLD && !clawLock)
                    {
                        nxt.MotorC.On(-50);
                        ArmWrestle(ARM_WRESTLE_INTERVAL, NUMBER_OF_ARM_MOVEMENTS);
                        nxt.MotorC.On(50);
                        break;
                    }
                }
                
                if(SONAR_TESTING_MODE)
                {
                    // test the sonar sensor without triggering arm wrestling
                    Console.WriteLine(sonar + "cm");
                    if(sonar < SONAR_THRESHOLD)
                    {
                        Console.WriteLine("*** TRIGGERED ***");
                        nxt.MotorC.On(-100);
                        Thread.Sleep(2000);
                        nxt.MotorC.On(100);
                        Thread.Sleep(500);
                        nxt.MotorC.Off();
                    }
                }

                // 5 second grace period after the touch sensor is pressed (assuming this loop takes ~1ms to step)
                if(clawLock)
                {
                    lockElapsed++;
                    if(lockElapsed >= CLAW_LOCK_INTERVAL)
                    {
                        clawLock = false;
                        tauntPlayed = false;
                        lockElapsed = 0;
                        begTimerElapsed = 0;
                    }
                }

                // beg for human contact every 30s or so
                begTimerElapsed++;
                if(begTimerElapsed >= BEG_INTERVAL && BEGGING)
                {
                    nxt.PlaySoundFile("isanybodyaround.rso", false);
                    begTimerElapsed = 0;
                }
            }

            // --------- End Main Loop -------------
        }

        public void ArmWrestle(int duration, int numMovements)
        {
            // moves in different directions once the arm is captured
            if (!tauntPlayed)
            {
                nxt.PlaySoundFile("cannotescape.rso", false);
                Thread.Sleep(3000);
                nxt.PlaySoundFile("chicken.rso", false);
                Thread.Sleep(3000);
                tauntPlayed = true;
            }
            nxt.PlaySoundFile("bonecrack.rso", true);


            // calculate time for each movement
            int movementDuration = duration / numMovements;

            // initial arm movement
            MoveRandom(movementDuration);

            for(int i = 2; i < numMovements; i++)
            {
                MoveOpposite(movementDuration);
                // release the hand if the touch sensor is pressed
                if (nxt.Sensor1.Read() > 0)
                {
                    nxt.MotorC.On(50);
                    nxt.PlaySoundFile("button.rso", false);
                    Thread.Sleep(1000);
                    nxt.MotorC.Off();
                    clawLock = true;
                    break;
                }
                Thread.Sleep(duration);
            }
        }

        private void MoveRandom(int duration)
        {
            nxt.MotorA.ResetTacho();
            nxt.MotorB.ResetTacho();

            // create the RNG
            Random rng = new Random();

            // pick a random direction in the X axis (motor A)
            if (rng.Next(-100, 100) < 0)
            {
                lastX = -1;
            }
            else
            {
                lastX = 1;
            }

            // pick a random direction in the Y axis (motor B)
            if (rng.Next(-100, 100) < 0)
            {
                lastY = -1;
            }
            else
            {
                lastY = 1;
            }

            nxt.MotorA.On((sbyte)(lastX * 100), MOVEMENT_RANGE);
            nxt.MotorB.On((sbyte)(lastY * 100), MOVEMENT_RANGE);
            
        }

        private void MoveOpposite(int movementDuration)
        {
            nxt.MotorA.ResetTacho();
            nxt.MotorB.ResetTacho();


            // perform the movement
            lastX = lastX * -1;
            lastY = lastY * -1;
            nxt.MotorA.On((sbyte)(lastX * 100), MOVEMENT_RANGE);
            nxt.MotorB.On((sbyte)(lastY * 100), MOVEMENT_RANGE);
            Thread.Sleep(movementDuration);
        }
}
}
