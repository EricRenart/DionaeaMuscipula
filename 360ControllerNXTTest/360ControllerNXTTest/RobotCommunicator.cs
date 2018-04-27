using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MonoBrick.NXT;

namespace _360ControllerNXTTest
{
    class RobotCommunicator
    {
        Brick<Sensor, Sensor, Sensor, Sensor> brick;
        Queue<MoveCommand> commandQueue;
        MoveCommand newCmd;
        bool isRecording;
        bool isSensorEnabled;
        bool isActive;

        public RobotCommunicator(Brick<Sensor, Sensor, Sensor, Sensor> initBrick)
        {
            brick = initBrick;
            commandQueue = new Queue<MoveCommand>();
            isRecording = false;
            isSensorEnabled = false;
        }

        // Open a communication channel with the robot, and runs the main communication loop.
        public void Start()
        {
            brick.Connection.Open();
            brick.Beep(300);
            isActive = true;

            while (isActive) {

                // arm/claw movement buttons
                while ()
                {
                    newCmd.SetCommandType(MoveCommandType.MOVE_LEFT);
                    LogDuration(newCmd);
                }

                while ()
                {

                    newCmd.SetCommandType(MoveCommandType.MOVE_RIGHT);
                    LogDuration(newCmd);
                }

                while ()
                {
                    newCmd.SetCommandType(MoveCommandType.MOVE_UP);
                    LogDuration(newCmd);
                }

                while ()
                {
                    newCmd.SetCommandType(MoveCommandType.MOVE_DOWN);
                    LogDuration(newCmd);
                }

                while ()
                {
                    newCmd.SetCommandType(MoveCommandType.OPEN_CLAW);
                    LogDuration(newCmd);
                }

                while ()
                {
                    newCmd.SetCommandType(MoveCommandType.CLOSE_CLAW);
                    LogDuration(newCmd);
                }

                while ()
                {
                    // toggle recording on and off
                    if (!isRecording)
                    {
                        isRecording = true;
                        // wait a bit so we don't bounce
                        Thread.Sleep(10);
                        Console.WriteLine("Now recording motion sequence. Press X again to terminate recording.");
                        break;
                    }
                    else
                    {
                        isRecording = false;
                        Thread.Sleep(10);
                        Console.WriteLine("Recording terminated.");
                        break;
                    }
                }

                // 
                if ()
                {
                    brick.MotorA.Off();
                    brick.MotorB.Off();
                    brick.MotorC.Off();
                    brick.Connection.Close();
                    isActive = false;
                }

                // record commands if enabled
                if (isRecording)
                {
                    AddCommand(newCmd);
                }


            }
        }

        // Adds a MoveCommand to the command queue with the specified power, duration in ms and direction.
        public void AddCommand(MoveCommandType type, int power, int duration)
        {
            MoveCommand cmd = new MoveCommand(type, power, duration);

            // if the command is blank don't add it to the queue
            if (cmd.GetCommandType() != MoveCommandType.BLANK)
            {
                commandQueue.Enqueue(cmd);
            }
        }

        public void AddCommand(MoveCommand cmd)
        {
            commandQueue.Enqueue(cmd);
        }

        // Pops a command off the queue and executes it.
        public void ExecuteNextCommand()
        {
            if (commandQueue.Any<MoveCommand>())
            {
                MoveCommand next = commandQueue.Dequeue();
                CommandObject objToBot = next.Execute();
                SendCommandObject(objToBot);
            }
            else
            {
                Console.WriteLine("Cannot execute: There are no MoveCommands in the queue");
            }
            
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

        // Executes the sequence of recorded commands in the commandQueue.
        public void ExecuteQueue()
        {
            Console.WriteLine("Playing back stored commands...");
            for(int i = 0; i < commandQueue.Count; i++)
            {
                ExecuteNextCommand();
            }
        }

        // This gets called whenever a button on the controller is released.
        private void LogDuration( MoveCommand cmd)
        {
            cmd.duration += 1;
        }

    }
}
