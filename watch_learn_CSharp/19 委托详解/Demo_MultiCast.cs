using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_MultiCast
    {
        public void test()
        {
            Demo19_Student student1 = new Demo19_Student() { ID = 1, PenColor = ConsoleColor.Red };
            Demo19_Student student2 = new Demo19_Student() { ID = 2, PenColor = ConsoleColor.Green };
            Demo19_Student student3 = new Demo19_Student() { ID = 3, PenColor = ConsoleColor.Blue };
            Action action1 = student1.DoHomeWork;
            Action action2 = student2.DoHomeWork;
            Action action3 = student3.DoHomeWork;

            //action1 += action2;
            //action1 += action3;
            //action1();//同步调用

            //action1.BeginInvoke(null, null);//隐式异步
            //action2.BeginInvoke(null, null);
            //action3.BeginInvoke(null, null);//因为争抢ForegroundColor导致资源冲突，未能使得颜色一定对应于学生的PenColor

            //Thread thread1 = new Thread(new ThreadStart(student1.DoHomeWork));//显式异步调用
            //Thread thread2 = new Thread(new ThreadStart(student2.DoHomeWork));
            //Thread thread3 = new Thread(new ThreadStart(student3.DoHomeWork));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //Task task1 = new Task(student1.DoHomeWork);//显式异步调用
            //Task task2 = new Task(student2.DoHomeWork);
            //Task task3 = new Task(student3.DoHomeWork);

            //task1.Start();
            //task2.Start();
            //task3.Start();

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread {0}",i);
                Thread.Sleep(500);
            }
        }
    }
    class Demo19_Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }
        public void DoHomeWork()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = PenColor;
                Console.WriteLine("Student {0} is doing homework for {1} hours", ID, i);
                Thread.Sleep(500);
            }
        }
    }
}
