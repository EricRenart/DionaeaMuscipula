using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360ControllerNXTTest
{ 
    class Recorder
    {
        double[] motorAHistory;
        double[] motorBHistory;
        double[] motorCHistory;

        public Recorder(int seconds)
        {
            motorAHistory = new double[2*seconds];
            motorBHistory = new double[2*seconds];
            motorCHistory = new double[2*seconds];
        }

        public void StartRecording()
        {

        }

        public void PlaybackRecording()
        {

        }

        public void ClearStoredCommands()
        {

        }
    }
}
