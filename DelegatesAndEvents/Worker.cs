using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegatesAndEvents
{
    public class Worker
    {
        public event EventHandler<WorkPerformedEvenArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public virtual void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                Thread.Sleep(100);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEvenArgs(hours, workType));
        }
        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
