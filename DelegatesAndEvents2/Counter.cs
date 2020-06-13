using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents2
{
    // Class that publishes an event
    class Counter
    {
        private int _threshold;
        private int _total;

        public int Threshhold { get => _threshold; set => _threshold = value; }

        // Declare the event using EventHandler<T>
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        public Counter()
        {
                
        }
        public Counter(int passedThreshold)
        {
            _threshold = passedThreshold;
        }

        public void Add(int x)
        {
            _total += x;
            if (_total < _threshold) return;
            var args = new ThresholdReachedEventArgs(_threshold, DateTime.Now);
            // Raising an event. You can also raise an event
            // before you execute a block of code.
            OnThresholdReached(args);
        }


        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<ThresholdReachedEventArgs> thresholdReached = ThresholdReached;

            // Event will be null if there are no subscribers, cheching for null
            // Call to raise the event.
            thresholdReached?.Invoke(this, e);
        }
    }
}
