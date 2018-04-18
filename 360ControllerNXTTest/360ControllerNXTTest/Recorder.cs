using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MonoBrick.NXT;

namespace _360ControllerNXTTest
{ 
    class RecorderThread
    {
        static int[] motorABuffer;
        static int[] motorBBuffer;
        static int[] motorCBuffer;

        public void Record()
        {
            int step = 0;
            motorABuffer = new int[2 * Recorder.GetDuration()];
            motorBBuffer = new int[2 * Recorder.GetDuration()];
            motorCBuffer = new int[2 * Recorder.GetDuration()];
            Recorder.ResetTachos();
            while(step < 2* Recorder.GetDuration())
            {
                // add positions of motors to motorBuffers every 1/2 sec
                Console.WriteLine("-----------------------------------");
                motorABuffer[step - 1] = Recorder.GetBrick().MotorA.GetTachoCount();
                Console.WriteLine("A: " + motorABuffer[step - 1]);
                motorBBuffer[step - 1] = Recorder.GetBrick().MotorB.GetTachoCount();
                Console.WriteLine("B: " + motorABuffer[step - 1]);
                motorCBuffer[step - 1] = Recorder.GetBrick().MotorC.GetTachoCount();
                Console.WriteLine("C: " + motorABuffer[step - 1]);
                Thread.Sleep(500);
                step++;
            }

            // dump data to Recorder class once done
            Recorder.CopyThreadRecordingData(this);
            Console.WriteLine("Recorder thread finished.");
            Recorder.Unlock();
        }



        public int[] getABuffer()
        {
            return motorABuffer;
        }
        public int[] getBBuffer()
        {
            return motorBBuffer;
        }
        public int[] getCBuffer()
        {
            return motorCBuffer;
        }
    }

    class Recorder
    {
        static Brick<Sensor,Sensor,Sensor,Sensor> nxt;
        static int[] motorAHistory;
        static int[] motorBHistory;
        static int[] motorCHistory;
        static bool full;
        static bool locked;
        static int duration;

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

        public static void StartRecording()
        {
            if(!full) {
                Console.WriteLine("Starting recorder thread...");
                Lock();
                RecorderThread rt = new RecorderThread();
                Thread recorderThread = new Thread(new ThreadStart(rt.Record));
                recorderThread.Start();
            }
        }

        public static void PlaybackRecording()
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
                int step = 0;
                int aPos = 0;
                int bPos = 0;
                int cPos = 0;
                while(step < 2*duration)
                {
                    aPos = motorAHistory[step - 1];
                    bPos = motorBHistory[step - 1];
                    cPos = motorCHistory[step - 1];
                    nxt.MotorA.MoveTo(10, aPos, false);
                    nxt.MotorB.MoveTo(10, bPos, false);
                    nxt.MotorC.MoveTo(10, cPos, false);
                    Thread.Sleep(500);
                    step++;
                }
                Console.WriteLine("Sequence playback finished.");
                ClearStoredCommands();
            }
        }

        public static void ClearStoredCommands()
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

        public static void CopyThreadRecordingData(RecorderThread rt)
        {
            motorAHistory = rt.getABuffer();
            motorBHistory = rt.getBBuffer();
            motorCHistory = rt.getCBuffer();
            full = true;
        }

        public static Brick<Sensor,Sensor,Sensor,Sensor> GetBrick()
        {
            return nxt;
        }

        public static int GetDuration()
        {
            return duration;
        }

        public static void ResetTachos()
        {
            nxt.MotorA.ResetTacho();
            nxt.MotorB.ResetTacho();
            nxt.MotorC.ResetTacho();
        }

        public static void Lock()
        {
            locked = true;
        }

        public static void Unlock()
        {
            locked = false;
        }
    }
}
