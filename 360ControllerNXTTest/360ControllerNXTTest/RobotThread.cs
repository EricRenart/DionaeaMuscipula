using MonoBrick.NXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        const int lightdiff = 5; //difference between light sensor values in order for the arm to move in a direction
        const int sonarThreshold = 25; // minimum distance in centimenters the hand must be from the claw in order for it to start opening

        public RobotThread(Brick<Sensor, NXTLightSensor, NXTLightSensor, Sonar> nxti, Form1 f1i)
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
            nxt.Sensor2 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor3 = new NXTLightSensor(LightMode.Off);
            nxt.Sensor4 = new Sonar();

            // ----------- Main Loop ---------------
            while (isActive)
            {
                // Update readouts in the Form
                f1.UpdateReadouts(nxt.Sensor2.ReadLightLevel(), nxt.Sensor3.ReadLightLevel(), nxt.Sensor4.ReadDistance());

                if (isRecording)
                {
                    // Record stuff
                }
            }

            // --------- End Main Loop -------------
        }
}
}
