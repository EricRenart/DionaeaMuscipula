using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using J2i.Net.XInputWrapper;
using MonoBrick.NXT;
using _360ControllerNXTTest;


namespace _360ControllerNXTTest
{
    class ControllerThread
    {

        Brick<Sensor,Sensor,Sensor,Sensor> brick;
        XboxController controller;
        bool isControllerEnabled;

        public ControllerThread(Brick<Sensor, Sensor, Sensor, Sensor> nxt, XboxController selectedController)
        {
            controller = selectedController;
            brick = nxt;
            isControllerEnabled = false;
            Console.WriteLine("Starting controller thread...");
        }

        public void StartControllerInput()
        {
            if (!isControllerEnabled)
            {
                brick.Connection.Open();
                XboxController.StartPolling();
                isControllerEnabled = true;
            }

            while (isControllerEnabled)
            {
                try
                {
                    // this loop runs while isControllerEnabled == true
                    bool clawToggle = false; // init to closed
                                             //const int CLAW_MOVE_INTERVAL = 750;
                    const int CLAW_SPEED = 10;
                    const int ARM_SPEED = 20;
                    while (controller.IsDPadRightPressed)
                    {
                        // move turntable right
                        brick.MotorA.On(-1 * ARM_SPEED);
                    }
                    while (controller.IsDPadLeftPressed)
                    {
                        brick.MotorA.On(ARM_SPEED);
                    }
                    while (controller.IsDPadUpPressed)
                    {
                        brick.MotorB.On(-1 * ARM_SPEED);
                    }
                    while (controller.IsDPadDownPressed)
                    {
                        brick.MotorB.On(ARM_SPEED);
                    }

                    while (controller.IsLeftShoulderPressed)
                    {
                        brick.MotorC.On(CLAW_SPEED);
                    }
                    while (controller.IsRightShoulderPressed)
                    {
                        brick.MotorC.On(-1 * CLAW_SPEED);
                    }

                    if (controller.IsBPressed)
                    {
                        isControllerEnabled = false;
                        StopControllerInput();
                        break;
                    }
                    if (brick.MotorA.IsRunning() || brick.MotorB.IsRunning() || brick.MotorC.IsRunning())
                    {
                        brick.MotorA.Off();
                        brick.MotorB.Off();
                        brick.MotorC.Off();
                    }
                }
                catch (MonoBrick.ConnectionException ce)
                {
                    // automatically disable controller
                    isControllerEnabled = false;
                }
            }
        }

        public void MotorACallback(sbyte speed)
        {
            brick.MotorA.On(speed);
        }

        public void MotorBCallback(sbyte speed)
        {
            brick.MotorB.On(speed);
        }

        public void MotorCCallback(sbyte speed)
        {
            brick.MotorC.On(speed);
        }

        public void StopControllerInput()
        {
            isControllerEnabled = false;
            brick.MotorA.Off();
            brick.MotorB.Off();
            System.Console.WriteLine("Control sequence aborted.");
            brick.Connection.Close();
            XboxController.StopPolling();
        }
    }
}
