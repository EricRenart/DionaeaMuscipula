using MonoBrick.NXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _DionaeaMuscipula
{
    class RobotThread
    {
        bool isActive;
        bool isRecording;
        Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxt;
        Queue<MoveCommand> commandQueue;
        Random rng;
        Form1 f1; // this is to update the readout
        const int lightdiff = 2; //difference between light sensor values in order for the arm to move in a direction
        const int sonarThreshold = 12; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut

        public RobotThread(Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxti, Form1 f1i)
        {
            nxt = nxti;
            f1 = f1i;
            isActive = true;
            isRecording = false;
            commandQueue = new Queue<MoveCommand>();
        }

        public void start()
        {
            // First connect
            nxt.Connection.Open();

            // load sensors
            nxt.Sensor1 = new TouchSensor();
            nxt.Sensor2 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor3 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor4 = new Sonar();

            // load the RNG
            rng = new Random();

            nxt.PlaySoundFile("letmeshakehand.rso", false);

            // ----------- Main Loop ---------------
            // Pressing the K key kills everything if things go awry
            while (isActive)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                int light1 = nxt.Sensor2.ReadLightLevel();
                int light2 = nxt.Sensor3.ReadLightLevel();
                int sonar = nxt.Sensor4.ReadDistance();

                Console.WriteLine("["+light1+"]---["+sonar+" cm]---["+light2+"]");

                // if the right light sensor reading exceeds the left light sensor reading, move left
                if (light2 - light1 < lightdiff)
                {
                    nxt.MotorA.On(30);

                }

                // if the right light sensor reading exceeds the left light sensor reading, move left
                if(light2 - light1 > lightdiff)
                {
                    nxt.MotorA.On(-30);
                }

                
                // if the difference between sensor values is less than the threshold stop the motor
                if(Math.Abs(light2 - light1) <= lightdiff)
                {
                    nxt.MotorA.Off();
                }

                if(sonar < sonarThreshold)
                {
                    nxt.MotorC.On(-50);
                    nxt.PlaySoundFile("cannotescape.rso",false);
                    Thread.Sleep(2000);

                    int tortureDuration = rng.Next(15, 60);
                    RandomMovement(tortureDuration, 10, 40);
                }
                

                if (f1.isRecording)
                {
                    // Record stuff
                }

                // release the hand if the touch sensor is pressed
                if(nxt.Sensor1.Read() > 0)
                {
                    Defeat();
                }

                // keep the queue from overflowing
                if(commandQueue.Count > 100000)
                {
                    commandQueue.Clear();
                }

                // kill key
                if(Console.Read() == 'k')
                {
                    Console.WriteLine("Kill command issued.");
                    break;
                }
            }

            // --------- End Main Loop -------------
        }

        // This function moves the arm in random directions for random amounts of time after the arm is captured.
        public void RandomMovement(int totalDuration, int lowerBound, int upperBound)
        {
            int i = 0;
            while(i < totalDuration)
            {
                // generate a random amount of "ticks" that this command will execute for
                int n = lowerBound + rng.Next(upperBound - lowerBound);
                bool escape = false;
                int j = 0;
                while (j < n)
                {

                    // always provide the user with an option to stop at any time (the touch sensor)
                    if (nxt.Sensor1.Read() > 0)
                    {
                        Defeat();
                        escape = true; // break out of 2 while loops at once
                        break; 
                    }

                    sbyte speedA = (sbyte)rng.Next(-50, 50);
                    sbyte speedB = (sbyte)rng.Next(-50, 50);

                    nxt.MotorA.On(speedA);
                    nxt.MotorB.On(speedB);

                    Thread.Sleep(rng.Next(0, 2000));
                }

                if(escape)
                {
                    break;
                }

                nxt.MotorA.Off();
                nxt.MotorB.Off();
                Thread.Sleep(500);

                i += n;
            }
        }

        public void Defeat()
        {
            nxt.MotorC.On(50);
            nxt.PlaySoundFile("button.rso", false);
            Thread.Sleep(1000);
            nxt.MotorC.Off();
            nxt.MotorC.On(-50);
            Thread.Sleep(1000);
            nxt.MotorC.Off();
        }
    }
}
