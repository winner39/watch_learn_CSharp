using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace watch_learn_CSharp
{
    class Demo_Event_1
    {
        public void test()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            Boy boy = new Boy();
            Girl girl = new Girl();
            Unknown unknown = new Unknown();
            timer.Elapsed += boy.Action;
            timer.Elapsed += girl.Action;
            timer.Elapsed += unknown.timerAction;
            timer.Start();
            Console.ReadLine();
            

        }

    }

    class Boy
    {
        public void TackAction()
        {
            Console.WriteLine("roar");
        }

        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("roar");
            
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("sing");
        }
    }
    class Unknown
    {
        internal void timerAction(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("?");
        }
    }
}
