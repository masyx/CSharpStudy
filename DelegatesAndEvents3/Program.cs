using System;

namespace DelegatesAndEvents3
{
    using System;

    namespace DotNetEvents
    {
        class Program
        {
            static void Main()
            {
                var pub = new Publisher();
                var sub1 = new Subscriber("sub1", pub);
                var sub2 = new Subscriber("sub2", pub);

                // Call the method that raises the event.
                pub.DoSomething();
            }
        }
    }
}
