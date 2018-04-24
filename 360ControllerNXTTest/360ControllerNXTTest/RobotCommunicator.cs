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
        Queue<MoveCommand> commandQueue;

        public RobotCommunicator(Brick<Sensor, Sensor, Sensor, Sensor> initBrick, XboxController initController)
        {
            brick = initBrick;
            controller = initController;
            commandQueue = new Queue<MoveCommand>();

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

        // Adds a MoveCommand to the command queue with the specified power, duration in ms and direction.
        public void AddCommand(MoveCommandType type, int power, int duration)
        {
            MoveCommand cmd = new MoveCommand(type, power, duration);
            commandQueue.Enqueue(cmd);
        }

        // Pops a command off the queue and executes it.
        public void ExecuteNextCommand()
        {
            MoveCommand next = commandQueue.Dequeue();
            CommandObject objToBot = next.Execute();
            SendCommandObject(objToBot);
        }

        // Sends CommandObject information to the robot.
        // This method is what actually sends a command to the robot
        private void SendCommandObject(CommandObject obj)
        {
            int powerToMotor = obj.power;
            int execDuration = obj.duration;
            switch (obj.motorNum)
            {
                case 'A':
                    brick.MotorA.On((sbyte)powerToMotor);
                    Thread.Sleep(execDuration);
                    brick.MotorA.Off();
                    break;
                case 'B':
                    brick.MotorB.On((sbyte)powerToMotor);
                    Thread.Sleep(execDuration);
                    brick.MotorB.Off();
                    break;
                case 'C':
                    brick.MotorC.On((sbyte)powerToMotor);
                    Thread.Sleep(execDuration);
                    brick.MotorC.Off();
                    break;
                default:
                    throw new Exception("motorNum of this object not recognized!");
            }
        }

    }
}
