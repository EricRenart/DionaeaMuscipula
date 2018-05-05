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

    struct MovementInfo
    {
        public int dA;
        public int dB;
        public int dC;

        public MovementInfo(int dAi, int dBi, int dCi)
        {
            dA = dAi;
            dB = dBi;
            dC = dCi;
        }

        public static MovementInfo Difference(MovementInfo m1, MovementInfo m2)
        {
            int ddA = m2.dA - m1.dA;
            int ddB = m2.dB - m1.dB;
            int ddC = m2.dC - m1.dC;
            return new MovementInfo(ddA, ddB, ddC);
        }

        public string ToString()
        {
            return "--------------- \n dA: " + dA + "\ndB: "+dB+"\ndC: "+dC+"\n----------------";
        }

    }

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
        bool SONAR_ENABLED = true;
        const bool SONAR_TESTING_MODE = false;
        bool WRESTLING_ENABLED = true;
        const bool BEGGING = false; // Change this to false to disable the periodic "Please, is anybody around" phrase
        bool HOLDING_OBJECT = false;

        // Ints
        int SONAR_THRESHOLD = 22; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut
        const int CLAW_LOCK_INTERVAL = 25; // lock the claw for ~5 sec after hand is freed via touch sensor
        const int BEG_INTERVAL = 150; // beg for human contact every ~30s by playing an rso
        const int ARM_WRESTLE_INTERVAL = 150; // total duration of the random arm movement in "wrestle mode"
        const int NUMBER_OF_ARM_MOVEMENTS = 100; // number of random movements the robot arm will make when it enters "wrestle mode"
        const int MOVEMENT_RANGE = 500; // number of degrees the robot arm is limited to moving to in a direction during the arm wrestling 
        const int SLEW_SPEED = 15; // speed of the arm when it is slewn by the keyboard
        const int WRESTLE_GRIP_STRENGTH = 100;
        const int PLAYBACK_TIMEOUT = 50;
        const int GRAB_STRENGTH = 40;
        const int SLEW_SPEED_CLAW = 10;

        // END MOVEMENT SETTINGS

        Queue<MovementInfo> commandQueue;

        public RobotThread(Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxti)
        {
            nxt = nxti;
            isActive = true;
            clawLock = false;
            tauntPlayed = false;
            commandQueue = new Queue<MovementInfo>();
        }

        public void start()
        {
            nxt.Connection.Open();

            // load sensors
            nxt.Sensor1 = new TouchSensor();
            nxt.Sensor4 = new Sonar();
            int sonar = 0;

            nxt.PlaySoundFile("letmeshakehand.rso", false);

            // ----------- Main Loop ---------------

            while (isActive)
            {
                // take motor's initial position
                int dInitA = nxt.MotorA.GetTachoCount();
                int dInitB = nxt.MotorB.GetTachoCount();
                int dInitC = nxt.MotorC.GetTachoCount();
                MovementInfo initialInfo = new MovementInfo(dInitA, dInitB, dInitC);
                //Console.WriteLine(initialInfo.ToString());

                if (SONAR_ENABLED)
                {
                    sonar = nxt.Sensor4.ReadDistance();
                    if (!SONAR_TESTING_MODE)
                    {
                        Console.WriteLine("Sonar: " + sonar);
                    }
                }

                // get the current key pressed and move the arm appropriately
                while (Form1.keyPressed == 'w')
                {
                    nxt.MotorB.On(SLEW_SPEED);
                }
                while (Form1.keyPressed == 'a')
                {
                    nxt.MotorA.On(SLEW_SPEED);
                }
                while (Form1.keyPressed == 's')
                {
                    nxt.MotorB.On(-1 * SLEW_SPEED);
                }
                while (Form1.keyPressed == 'd')
                {
                    nxt.MotorA.On(-1 * SLEW_SPEED);
                }
                while (Form1.keyPressed == 'q')
                {
                    nxt.MotorC.On(SLEW_SPEED_CLAW);
                }
                while (Form1.keyPressed == 'e')
                {
                    // close the claw manually
                    if (!HOLDING_OBJECT)
                    {
                        HOLDING_OBJECT = true;
                        nxt.MotorC.On(-1*GRAB_STRENGTH);
                        Thread.Sleep(1000);
                        nxt.MotorC.Off();
                    }
                    else
                    {
                        // manual release of claw
                        HOLDING_OBJECT = false;
                        nxt.MotorC.On(GRAB_STRENGTH);
                        Thread.Sleep(2000);
                        nxt.MotorC.Off();
                    }
 
                    Form1.keyPressed = ' ';
                }
                if (Form1.keyPressed == 'r')
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
                if (Form1.keyPressed == (char)40)
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
                if(Form1.keyPressed == 'p')
                {
                    nxt.MotorA.Off();
                    nxt.MotorB.Off();
                    nxt.MotorC.Off();
                    PlaybackMovements();
                }
                if (Form1.keyPressed == ' ')
                {
                    nxt.MotorA.Off();
                    nxt.MotorB.Off();
                    nxt.MotorC.Off();
                }
                 
                // Capture the hand if it is within the capture interval and the claw is not locked.
                if (SONAR_ENABLED && WRESTLING_ENABLED && !SONAR_TESTING_MODE)
                {

                    if (sonar <= SONAR_THRESHOLD && !HOLDING_OBJECT)
                    {
                        nxt.MotorC.On(-1*WRESTLE_GRIP_STRENGTH);
                        HOLDING_OBJECT = true;
                        ArmWrestle(ARM_WRESTLE_INTERVAL, NUMBER_OF_ARM_MOVEMENTS);
                        nxt.MotorC.On(WRESTLE_GRIP_STRENGTH);
                        Thread.Sleep(1000);
                        WRESTLING_ENABLED = false;
                    }
                }
                else if(SONAR_ENABLED && !WRESTLING_ENABLED && !SONAR_TESTING_MODE)
                {
                    if (sonar <= SONAR_THRESHOLD && !HOLDING_OBJECT)
                    {
                        // simply grab object without wrestling
                        nxt.MotorC.On(-1 * GRAB_STRENGTH);
                        HOLDING_OBJECT = true;
                        Thread.Sleep(500);
                        //nxt.MotorC.Brake();
                    }
                }
                if(HOLDING_OBJECT)
                {
                    nxt.MotorC.On(-1 * GRAB_STRENGTH);
                }

                if (SONAR_TESTING_MODE)
                {
                    // test the sonar sensor without triggering arm wrestling
                    Console.WriteLine(sonar + "cm");
                    if (sonar <= SONAR_THRESHOLD)
                    {
                        Console.WriteLine("*** TRIGGERED ***");
                        //nxt.MotorC.On(-100);
                       // Thread.Sleep(2000);
                       // nxt.MotorC.On(100);
                        //Thread.Sleep(500);
                        //nxt.MotorC.Off();
                    }
                }

                // 5 second grace period after the touch sensor is pressed (assuming this loop takes ~1ms to step)
                if (clawLock)
                {
                    lockElapsed++;
                    if (lockElapsed >= CLAW_LOCK_INTERVAL)
                    {
                        clawLock = false;
                        tauntPlayed = false;
                        lockElapsed = 0;
                        begTimerElapsed = 0;
                    }
                }

                // beg for human contact every 30s or so
                begTimerElapsed++;
                if (begTimerElapsed >= BEG_INTERVAL && BEGGING)
                {
                    nxt.PlaySoundFile("isanybodyaround.rso", false);
                    begTimerElapsed = 0;
                }

                // record the displacement of the motor since the start of this loop
                int dFinalA = nxt.MotorA.GetTachoCount();
                int dFinalB = nxt.MotorB.GetTachoCount();
                int dFinalC = nxt.MotorC.GetTachoCount();

                // calculate the displacement of the motors and store them in the queue
                MovementInfo finalInfo = new MovementInfo(dFinalA, dFinalB, dFinalC);
                MovementInfo displacement = MovementInfo.Difference(initialInfo, finalInfo);
                //Console.WriteLine(finalInfo.ToString());
                //Console.WriteLine(displacement.ToString());
                commandQueue.Enqueue(displacement);
                Console.WriteLine("Queue Length: " + commandQueue.Count());
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
        
        private void PlaybackMovements()
        {
            // move to the start
            MovementInfo toStart = MovementToStart();
            MoveFromInfo(toStart);
            while(nxt.MotorA.IsRunning() || nxt.MotorB.IsRunning() || nxt.MotorC.IsRunning())
            {
                Thread.Sleep(100);
            }
            int queueLength = commandQueue.Count();

            for (int i = 0; i < queueLength; i++)
            {
                MovementInfo current = commandQueue.Dequeue();
                MoveFromInfo(current);
                Console.WriteLine("Queue Length: " + commandQueue.Count() + " Executing [dA ="+current.dA+" dB="+current.dB+" dC="+current.dC+"]");
                int timeout = 0;
                while (nxt.MotorA.IsRunning() || nxt.MotorB.IsRunning() || nxt.MotorC.IsRunning())
                {
                    Thread.Sleep(1);
                    timeout++;
                    Console.WriteLine("Timeout: " + timeout + "/"+PLAYBACK_TIMEOUT);
                    if(timeout >= PLAYBACK_TIMEOUT)
                    {
                        break;
                    }
                    
                }
            }
            commandQueue.Clear();
            Form1.keyPressed = ' ';
        }

        private MovementInfo MovementToStart()
        {
            int dCA = 0;
            int dCB = 0;
            int dCC = 0;
            MovementInfo[] queueArray = commandQueue.ToArray();
            for(int i = 0; i < queueArray.Length; i++)
            {
                MovementInfo info = queueArray[i];
                dCA += info.dA;
                dCB += info.dB;
                dCC += info.dC;
            }
            return new MovementInfo(-1*dCA, -1*dCB, -1*dCC);
        }

        private void MoveFromInfo(MovementInfo info)
        {
            if (info.dA < 0)
            {
                nxt.MotorA.On(-1 * SLEW_SPEED, (uint)(Math.Abs(info.dA)));
            }
            else if (info.dA == 0)
            {
                nxt.MotorA.Off();
            }
            else
            {
                nxt.MotorA.On(SLEW_SPEED, (uint)info.dA);
            }

            if (info.dB < 0)
            {
                nxt.MotorB.On(-1 * SLEW_SPEED, (uint)(Math.Abs(info.dB)));
            }
            else if (info.dB == 0)
            {
                nxt.MotorB.Off();
            }
            else
            {
                nxt.MotorB.On(SLEW_SPEED, (uint)info.dB);
            }

            if (info.dC < 0)
            {
                nxt.MotorC.On(-1 * SLEW_SPEED, (uint)(Math.Abs(info.dC))); // this hangs when dC gets too negative
            }
            else if (info.dC == 0)
            {
                nxt.MotorC.Off();
            }
            else
            {
                nxt.MotorC.On(SLEW_SPEED, (uint)info.dC);
            }


        }
}
}
