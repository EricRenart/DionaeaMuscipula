using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _360ControllerNXTTest
{
    class RecorderThread
    {
        static int[] motorABuffer;
        static int[] motorBBuffer;
        static int[] motorCBuffer;
        Recorder recorder;

        public RecorderThread(Recorder recr)
        {
            recorder = recr;
        }

        public void Record()
        {
            int step = 0;
            motorABuffer = new int[2 * recorder.GetDuration()];
            motorBBuffer = new int[2 * recorder.GetDuration()];
            motorCBuffer = new int[2 * recorder.GetDuration()];
            recorder.ResetTachos();
            while (step < 2 * recorder.GetDuration())
            {
                // add positions of motors to motorBuffers every 1/2 sec
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Step # " + step);
                motorABuffer[step] = recorder.GetBrick().MotorA.GetTachoCount();
                Console.WriteLine("A: " + motorABuffer[step]);
                motorBBuffer[step] = recorder.GetBrick().MotorB.GetTachoCount();
                Console.WriteLine("B: " + motorBBuffer[step]);
                motorCBuffer[step] = recorder.GetBrick().MotorC.GetTachoCount();
                Console.WriteLine("C: " + motorCBuffer[step]);
                Thread.Sleep(500);
                step++;
            }

            // dump data to recorder class once done
            recorder.CopyThreadRecordingData(this);
            Console.WriteLine("recorder thread finished.");
            recorder.Unlock();
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
}
