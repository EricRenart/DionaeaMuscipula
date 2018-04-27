using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WiimoteLib;
using MonoBrick.NXT;

namespace _360ControllerNXTTest
{
    class RobotCommunicator
    {
        Brick<Sensor, Sensor, Sensor, Sensor> brick;
        Wiimote wiimote;
        Queue<MoveCommand> commandQueue;
        MoveCommand newCmd;
        bool isRecording;
        bool isSensorEnabled;
        bool isActive;

        public RobotCommunicator(Brick<Sensor, Sensor, Sensor, Sensor> initBrick)
        {
            brick = initBrick;
            wiimote = new Wiimote();
            commandQueue = new Queue<MoveCommand>();
            isRecording = false;
            isSensorEnabled = false;
        }

        // Open a communication channel with the robot, and runs the main communication loop.
        public void Start()
        {
            brick.Connection.Open();
            wiimote.Connect();
            wiimote.SetReportType(InputReport.IRAccel, true);
            wiimote.SetLEDs(true, true, true, true);
            brick.Beep(300);
            isActive = true;

            while (isActive) {

                

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
