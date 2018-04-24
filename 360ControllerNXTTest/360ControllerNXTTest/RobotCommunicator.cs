using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using J2i.Net.XInputWrapper;
using MonoBrick.NXT;

namespace _360ControllerNXTTest
{
    class RobotCommunicator
    {
        Brick<Sensor, Sensor, Sensor, Sensor> brick;
        XboxController controller;
        Queue<Command> commandQueue;

        public RobotCommunicator(Brick<Sensor, Sensor, Sensor, Sensor> initBrick, XboxController initController)
        {
            brick = initBrick;
            controller = initController;
            commandQueue = new Queue<Command>();

        }

        // Open a communication channel with the robot.
        public void Start()
        {
            brick.Connection.Open();
            MainLoop();
        }

        // Main loop method. Listen for controller inputs and move the corresponding motor.
        public void MainLoop()
        {

        }

        // Stop all movements and close the communication channel.
        public void Stop()
        {
            brick.MotorA.Off();
            brick.MotorB.Off();
            brick.MotorC.Off();
            brick.Connection.Close();
        }

        public void Up(int duration)
        {
            brick.MotorB.On(20);
            Thread.Sleep(duration);
            brick.MotorB.Off();
        }

        public void Down(int duration)
        {
            brick.MotorB.On(-20);
            Thread.Sleep(duration);
            brick.MotorB.Off();
        }

        public void Left(int duration)
        {
            brick.MotorA.On(-20);
            Thread.Sleep(duration);
            brick.MotorA.Off();
        }

        public void Right(int duration)
        {
            brick.MotorB.On(20);
            Thread.Sleep(duration);
            brick.MotorB.Off();
        }

        public void OpenClaw(int duration)
        {
            brick.MotorC.On(10);
            Thread.Sleep(duration);
            brick.MotorC.Off();
        }

        public void CloseClaw(int duration)
        {
            brick.MotorB.On(-10);
            Thread.Sleep(duration);
            brick.MotorB.Off();
        }
    }
}
