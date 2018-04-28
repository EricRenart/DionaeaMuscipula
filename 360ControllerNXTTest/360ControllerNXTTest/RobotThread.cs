using MonoBrick.NXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _360ControllerNXTTest
{
    class RobotThread
    {
        bool isActive;
        bool isRecording;
        Brick<Sensor, NXTLightSensor, NXTLightSensor, Sonar> nxt;
        Queue<MoveCommand> commandQueue;
        Form1 f1; // this is to update the readout
        const int lightdiff = 4; //difference between light sensor values in order for the arm to move in a direction
        const int sonarThreshold = 25; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to start opening
        const int clawDamp = 4;

        public RobotThread(Brick<Sensor, NXTLightSensor, NXTLightSensor, Sonar> nxti, Form1 f1i)
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
            nxt.Sensor2 = new NXTLightSensor();
            nxt.Sensor3 = new NXTLightSensor();
            nxt.Sensor4 = new Sonar();

            // ----------- Main Loop ---------------
            while (isActive)
            {
                int light1 = nxt.Sensor2.ReadLightLevel();
                int light2 = nxt.Sensor3.ReadLightLevel();
                int sonar = nxt.Sensor4.ReadDistance();

                Console.WriteLine("["+light1+"]---["+sonar+" cm]---["+light2+"]");


                if (light2 - light1 < lightdiff)
                {
                    nxt.MotorA.On(30);

                }

                if(light2 - light1 > lightdiff)
                {
                    nxt.MotorA.On(-30);
                }

                

                if(Math.Abs(light2 - light1) <= lightdiff)
                {
                    nxt.MotorA.Off();
                }

                int clawSpeed = calculateClawSpeed(sonar, sonarThreshold, clawDamp);
                nxt.MotorC.On((sbyte)clawSpeed);
                

                if (f1.isRecording)
                {
                    // Record stuff
                }

                // keep the queue from overflowing
                if(commandQueue.Count > 100000)
                {
                    commandQueue.Clear();
                }

            }

            // --------- End Main Loop -------------
        }

        public int calculateClawSpeed(int sonar, int threshold, int dampingFactor)
        {
            int speed = 0;

            // calculate speed
            if(sonar > sonarThreshold) {}
            else
            {
                speed = sonar - sonarThreshold;
            }
            return speed;
        }
}
}
