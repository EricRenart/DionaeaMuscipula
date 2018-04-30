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
        Form1 f1; // this is to update the readout
        const int lightdiff = 2; //difference between light sensor values in order for the arm to move in a direction
        const int sonarThreshold = 12; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut

        public RobotThread(Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxti, Form1 f1i)
        {
            nxt = nxti;
            f1 = f1i;
            isActive = true;
            isRecording = false;
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

                // if the left light sensor reading exceeds the right light sensor reading, move right
                if (light1 - light2 >= lightdiff)
                {
                    nxt.MotorA.On(-30);

                }

                // if the right light sensor reading exceeds the left light sensor reading, move left
                if(light2 - light1 >= lightdiff)
                {
                    nxt.MotorA.On(30);
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
                }

                // release the hand if the touch sensor is pressed
                if(nxt.Sensor1.Read() > 0)
                {
                    nxt.MotorC.On(50);
                    nxt.PlaySoundFile("button.rso", false);
                    Thread.Sleep(1000);
                    nxt.MotorC.Off();
                    nxt.MotorC.On(-50);
                    Thread.Sleep(1000);
                    nxt.MotorC.Off();
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
}
}
