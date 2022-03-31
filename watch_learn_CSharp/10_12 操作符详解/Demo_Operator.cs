using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Demo_Operator
    {
        public void test()
        {
            Dictionary<int, Student_Score> dict = new Dictionary<int, Student_Score>();
            for(int i = 0; i < 100; i++)
            {
                string name = "s_" + i;
                int score = 100 - i;
                dict.Add(i, new Student_Score(name, score));
            }
            Level level = default(Level);
            Console.WriteLine(level);

            Form form = new Form() { Text = "HELLO" };
            form.ShowDialog();

            Annoynomous_Variable();

            Student_Score student_Score = new Student_Score("clever", 100);
            Student_Score.SayHello();
            CsStudent_Score.SayHello();

            Check_OverFlow();

            /*unsafe
            {
                int x = sizeof(Student_Score);
                Console.WriteLine(x);
            }*/

            unsafe
            {
                int a = 100;
                int* b = &a;
            }

            int x = int.MinValue;
            Console.WriteLine(Convert.ToString(x,2).PadLeft(32,'0'));
            Console.WriteLine(x);
            int y = -x;
            Console.WriteLine(y);
        }
        public void Annoynomous_Variable()
        {
            var Person = new { Name = "Mr.OK", Age = 34, sex = "male" };
            Console.WriteLine(Person.Name + "," + Person.Age);
            Console.WriteLine(Person.GetType().Name);
            //输出为  <> f__AnonymousType0`3  0是编号(根据成员数量和类型排序来编号)，2代表成员数，前缀是约定俗成的
            var Person1 = new { Name = "Mr.OK", Age = 34 };
            Console.WriteLine(Person1.Name + "," + Person1.Age);
            Console.WriteLine(Person1.GetType().Name);
            //输出为  <> f__AnonymousType1`2
            var Person2 = new { Name = "Mrs.OK", Age = 35, sex = "female" };
            Console.WriteLine(Person2.Name + "," + Person2.Age);
            Console.WriteLine(Person2.GetType().Name);
            //输出为  <> f__AnonymousType0`3
        }
        public void Check_OverFlow()
        {
            uint a = uint.MaxValue;
            try
            {
                a = checked(a+1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);//System.OverflowException: 算术运算导致溢出
            }
            Console.WriteLine(a);
        }
    }
    class Student_Score
    {
        public string name;
        public int score;
        public Student_Score(string name = "stupid",int score = 0)//ctor 双击tab
        {
            this.name = name;
            this.score = score;
        }
        public static void SayHello()
        {
            Console.WriteLine("Hello,World");
        } 
    }
    class CsStudent_Score : Student_Score
    {
        new public static void SayHello()//new做修饰词
        {
            Console.WriteLine("10001");
        }
    }
    enum Level
    {
        Low = 0,
        Mid,
        High
    }
}
