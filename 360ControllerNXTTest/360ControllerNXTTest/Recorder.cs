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
        static double[] motorABuffer;
        static double[] motorBBuffer;
        static double[] motorCBuffer;

        public void Record()
        {
            int step = 0;
            motorABuffer = new double[2 * Recorder.GetDuration()];
            motorBBuffer = new double[2 * Recorder.GetDuration()];
            motorCBuffer = new double[2 * Recorder.GetDuration()];
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
        }



        public double[] getABuffer()
        {
            return motorABuffer;
        }
        public double[] getBBuffer()
        {
            return motorBBuffer;
        }
        public double[] getCBuffer()
        {
            return motorCBuffer;
        }
    }

    class Recorder
    {
        static Brick<Sensor,Sensor,Sensor,Sensor> nxt;
        static double[] motorAHistory;
        static double[] motorBHistory;
        static double[] motorCHistory;
        static int duration;

        public Recorder(Brick<Sensor,Sensor,Sensor,Sensor> brick, int seconds)
        {
            nxt = brick;
            duration = seconds;
            motorAHistory = new double[2*seconds];
            motorBHistory = new double[2*seconds];
            motorCHistory = new double[2*seconds];
        }

        public static void StartRecording()
        {
            Console.WriteLine("Starting recorder thread...");
            RecorderThread rt = new RecorderThread();
            Thread recorderThread = new Thread(new ThreadStart(rt.Record));
            recorderThread.Start();
        }

        public static void PlaybackRecording()
        {
            
        }

        public static void ClearStoredCommands()
        {

        }

        public static void CopyThreadRecordingData(RecorderThread rt)
        {
            motorAHistory = rt.getABuffer();
            motorBHistory = rt.getBBuffer();
            motorCHistory = rt.getCBuffer();
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
    }
}
