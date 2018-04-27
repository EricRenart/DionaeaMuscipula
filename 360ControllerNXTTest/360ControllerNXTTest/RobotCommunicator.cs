﻿using System;
using System.Timers;
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
        MoveCommand newCmd;
        int currentElapsedTime;
        bool isRecording;

        public RobotCommunicator(Brick<Sensor, Sensor, Sensor, Sensor> initBrick, XboxController initController)
        {
            brick = initBrick;
            controller = initController;
            commandQueue = new Queue<MoveCommand>();
            isRecording = false;
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
            newCmd = new MoveCommand(MoveCommandType.BLANK, 0, 20); // create a new blank command to increment
            
            // arm/claw movement buttons
            while(controller.IsDPadLeftPressed)
            {
                newCmd.SetCommandType(MoveCommandType.MOVE_LEFT);
                LogDuration(newCmd);
            }

            while (controller.IsDPadRightPressed)
            {
                newCmd.SetCommandType(MoveCommandType.MOVE_RIGHT);
                LogDuration(newCmd);
            }

            while (controller.IsDPadUpPressed)
            {
                newCmd.SetCommandType(MoveCommandType.MOVE_UP);
                LogDuration(newCmd);
            }

            while (controller.IsDPadDownPressed)
            {
                newCmd.SetCommandType(MoveCommandType.MOVE_DOWN);
                LogDuration(newCmd);
            }

            while (controller.IsLeftShoulderPressed)
            {
                newCmd.SetCommandType(MoveCommandType.OPEN_CLAW);
                LogDuration(newCmd);
            }

            while (controller.IsRightShoulderPressed)
            {
                newCmd.SetCommandType(MoveCommandType.CLOSE_CLAW);
                LogDuration(newCmd);
            }

            // (X) - record button
            while(controller.IsXPressed)
            {
                // toggle recording on and off
                if (!isRecording)
                {
                    isRecording = true;
                    // wait a bit so we don't bounce
                    Thread.Sleep(50);
                    break;
                }
                else
                {
                    isRecording = false;
                    Thread.Sleep(50);
                    break;
                }
            }

            // (B) - stop button
            if(controller.IsBPressed)
            {
                Stop();
            }

            // record commands if enabled
            if(isRecording)
            {
                AddCommand(newCmd);
            }
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
