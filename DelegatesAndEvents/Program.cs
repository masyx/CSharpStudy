using System;
using System.Runtime.CompilerServices;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GenerateReports
    }

    //public Func<int, int, int> BizRulesDelegate;
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEvenArgs>(Worker_WorkPerformed1);
            worker.WorkPerformed += Worker_WorkPerformed2; // Delegate inference
            worker.WorkCompleted += (s,e) => Console.WriteLine("!!!Work Completed!!!".ToUpper()); ;
            worker.DoWork(5, WorkType.GenerateReports);
            

            BizRulesDelegate AddDel = new BizRulesDelegate((x, y) => x + y );
            BizRulesDelegate Multiply = (x, y) => x * y;
            var data = new ProcessData();
            data.Process(2, 3, AddDel);


            Action<int, int> AddAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> MultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, MultiplyAction);


            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(4, 11, funcMultiplyDel);


        }

        //private static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("!!!Work Completed!!!".ToUpper());
        //}

        public static void Worker_WorkPerformed1(object sender, WorkPerformedEvenArgs e)
        {
            Console.WriteLine($"Worker_WorkPerformed1 performed.");
        }

        public static void Worker_WorkPerformed2(object sender, WorkPerformedEvenArgs e)
        {
            Console.WriteLine($"Worker_WorkPerformed2 performed. Hours: {e.Hours.ToString()} WorkType: {e.WorkType}");
        }
    }
}
