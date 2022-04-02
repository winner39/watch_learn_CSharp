using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_17
    {
        public void test()
        {
            List<Demo_17_Student> demo_17_Students = new List<Demo_17_Student>();
            for (int i = 0; i < 50; i++)
            {
                demo_17_Students.Add(new Demo_17_Student(i,100-i));
            }
            Console.WriteLine(Demo_17_Student.AverageAge);
        }
    }
    class Demo_17_Student
    {
        public readonly int ID;
        public int Age;
        public int Score;
        public static int Amount = 0;
        public static int AverageScore = 0;
        public static int AverageAge = 0;
        public static int TotalAge = 0;
        public static int TotalScore = 0;
        public Demo_17_Student(int age,int score)
        {
            ID = Amount + 1;
            Age = age;
            Score = score;
            Amount++;
            TotalAge += age;
            TotalScore += score;
            AverageAge = TotalAge / Amount;
            AverageScore = TotalScore / Amount;
        }
        static Demo_17_Student()
        {
            Amount = 0;
            AverageScore = 0;
        }
    }
}
