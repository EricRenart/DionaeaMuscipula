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
        bool clawLock;
        int lockElapsed = 0;
        int begTimerElapsed = 0;
        Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxt;
        const int LIGHT_DIFF = 2; //difference between light sensor values in order for the arm to move in a direction
        const int SONAR_THRESHOLD = 24; // minimum distance in centimenters the hand (or other object) must be from the claw in order for it to snap shut
        const int CLAW_LOCK_INTERVAL = 5000; // lock the claw for ~5 sec after hand is freed via touch sensor
        const int BEG_INTERVAL = 30000; // beg for human contact every 30s by playing an rso
        const int ARM_WRESTLE_INTERVAL = 30000;

        public RobotThread(Brick<TouchSensor, NXTLightSensor, NXTLightSensor, Sonar> nxti, Form1 f1i)
        {
            nxt = nxti;
            isActive = true;
            clawLock = false;
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
                // read sensor data
                int light1 = nxt.Sensor2.ReadLightLevel();
                int light2 = nxt.Sensor3.ReadLightLevel();
                int sonar = nxt.Sensor4.ReadDistance();

                // for debugging purposes
                Console.WriteLine("["+light1+"]---["+sonar+" cm]---["+light2+"]");

                // if the left light sensor reading exceeds the right light sensor reading, move right
                if (light1 - light2 >= LIGHT_DIFF)
                {
                    nxt.MotorA.On(-30);
                }

                // if the right light sensor reading exceeds the left light sensor reading, move left
                if(light2 - light1 >= LIGHT_DIFF)
                {
                    nxt.MotorA.On(30);
                }

                
                // if the difference between sensor values is less than the threshold stop the motor
                if(Math.Abs(light2 - light1) <= LIGHT_DIFF)
                {
                    nxt.MotorA.Off();
                }

                // Capture the hand if it is within the capture interval and the claw is not locked.
                if(sonar < SONAR_THRESHOLD && !clawLock)
                {
                    nxt.MotorC.On(-50);
                    nxt.PlaySoundFile("cannotescape.rso",false);
                    ArmWrestle(ARM_WRESTLE_INTERVAL);
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
                    clawLock = true;
                }

                // kill key
                if(Console.Read() == 'k')
                {
                    Console.WriteLine("Kill command issued.");
                    isActive = false;
                    break;
                }

                // 5 second grace period after the touch sensor is pressed (assuming this loop takes ~1ms to step)
                if(clawLock)
                {
                    lockElapsed++;
                    if(lockElapsed >= CLAW_LOCK_INTERVAL)
                    {
                        clawLock = false;
                        lockElapsed = 0;
                    }
                }

                // beg for human contact every 30s or so
                begTimerElapsed++;
                if(begTimerElapsed >= BEG_INTERVAL)
                {
                    nxt.PlaySoundFile("isanybodyaround.rso", false);
                    begTimerElapsed = 0;
                }
            }

            // --------- End Main Loop -------------
        }

        public void ArmWrestle(int duration)
        {
            // moves in different directions once the arm is captured
            nxt.PlaySoundFile("chicken.rso",false);
            nxt.PlaySoundFile("bonecrack.rso", true);

        }
}
}
