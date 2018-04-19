using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using _360ControllerNXTTest;
using MonoBrick.NXT;

namespace _360ControllerNXTTest
{ 
    class Recorder
    {
        Brick<Sensor,Sensor,Sensor,Sensor> nxt;
        Thread actualRecorderThread;
        int[] motorAHistory;
        int[] motorBHistory;
        int[] motorCHistory;
        bool full;
        bool locked;
        int duration;

        public Recorder(Brick<Sensor,Sensor,Sensor,Sensor> brick, int seconds)
        {
            nxt = brick;
            duration = seconds;
            motorAHistory = new int[2*seconds];
            motorBHistory = new int[2*seconds];
            motorCHistory = new int[2*seconds];
            full = false;
            locked = false;
        }

        public void StartRecording()
        {
            if(!full) {
                Console.WriteLine("Starting recorder thread...");
                Lock();
                RecorderThread rt = new RecorderThread(nxt,this);
                actualRecorderThread = new Thread(new ThreadStart(rt.Record));
                actualRecorderThread.Start();
            }
        }

        public void StopRecording()
        {
            actualRecorderThread.Abort();
            Unlock();
        }

        public void PlaybackRecording()
        {
            if(!full) {
                Console.WriteLine("There is no motor data to play back.");
            }
            else if(locked)
            {
                Console.WriteLine("Cannot play back while recording a sequence");
            }
            else {
                Console.WriteLine("Playing back motion sequence...");
                nxt.Connection.Open();
                int step = 0;
                int aPos = 0;
                int bPos = 0;
                int cPos = 0;
                while(step < 2*duration)
                {
                    aPos = motorAHistory[step];
                    bPos = motorBHistory[step];
                    cPos = motorCHistory[step];
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Step # " + step);

                    if (step + 1 > (2 * duration)-1) { break; }
                    else
                    {

                        if (aPos < 0) { 
                            if (aPos != 0) {
                                nxt.MotorA.On(-20, (uint)Math.Abs(aPos));
                            }
                        }
                        else {
                            if (aPos != 0) {
                                    nxt.MotorA.On(20, (uint)aPos);
                                }
                            }
                        Console.WriteLine("dA: " + aPos);

                        if (bPos < 0) {
                            if (bPos != 0) {
                                nxt.MotorB.On(-20, (uint)Math.Abs(bPos));
                            }
                        }
                        else {
                            if (bPos != 0) {
                                nxt.MotorB.On(20, (uint)bPos);
                            }
                        }
                        Console.WriteLine("dB: " + bPos);

                        if (cPos < 0) {
                            if (cPos != 0)
                            {
                                nxt.MotorC.On(-10, (uint)Math.Abs(cPos));
                            }
                        }
                        else {
                            if (cPos != 0)
                            {
                                nxt.MotorC.On(10, (uint)cPos);
                            }
                        }
                        Console.WriteLine("dC: " + cPos);
                        Thread.Sleep(500);
                        
                        step++;
                    }
                }
                Console.WriteLine("Sequence playback finished.");
                nxt.Connection.Close();
                ClearStoredCommands();
            }
        }

        public void ClearStoredCommands()
        {
            if (locked)
            {
                Console.WriteLine("Cannot clear buffers, recording in progress");
            }
            else
            {
                motorAHistory = new int[2 * duration];
                motorBHistory = new int[2 * duration];
                motorCHistory = new int[2 * duration];
                full = false;
            }
        }

        public void CopyThreadRecordingData(RecorderThread rt)
        {
            motorAHistory = rt.getABuffer();
            motorBHistory = rt.getBBuffer();
            motorCHistory = rt.getCBuffer();
            full = true;
        }

        public Brick<Sensor,Sensor,Sensor,Sensor> GetBrick()
        {
            return nxt;
        }

        public int GetDuration()
        {
            return duration;
        }



        public void ResetTachos()
        {
            nxt.MotorA.ResetTacho();
            nxt.MotorB.ResetTacho();
            nxt.MotorC.ResetTacho();
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {
            locked = false;
        }

        public bool IsLocked()
        {
            return locked;
        }
    }
}
