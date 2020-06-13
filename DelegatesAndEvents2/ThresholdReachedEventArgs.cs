using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents2
{
    // Class which holds custom event info
    class ThresholdReachedEventArgs : EventArgs
    {
        public ThresholdReachedEventArgs(int threshold, DateTime timeReached)
        {
            Threshold = threshold;
            TimeReached = timeReached;
        }

        public ThresholdReachedEventArgs()
        {
                
        }
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
