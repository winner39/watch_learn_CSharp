using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            try
            {
                //demo_17_Students[0].Age = 100; 报错
                demo_17_Students[0].age = 100;

                demo_17_Students[0].PropertyA = 150;
                demo_17_Students[0].Height = 50;


                GCHandle hander = GCHandle.Alloc(demo_17_Students[0]);
                var pin = GCHandle.ToIntPtr(hander);
                Console.WriteLine(string.Format("Device :{0}", pin));

                change(demo_17_Students[0]);

                Console.WriteLine(demo_17_Students[0].Height.GetType().Name); 
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Brush brush = new Brush();
            Console.WriteLine(Brush.color.Blue);
        }

        public void change(Demo_17_Student demo_17_Student)
        {
            GCHandle hander = GCHandle.Alloc(demo_17_Student);
            var pin = GCHandle.ToIntPtr(hander);
            Console.WriteLine(string.Format("Device :{0}", pin));

            demo_17_Student = new Demo_17_Student(50, 50);
            Console.WriteLine(demo_17_Student.Age);
        }

    }
    class Demo_17_Student
    {
        public const string GHS = "http://www.byethost.org";

        public readonly int ID;
        public int age;

        private int score;
        public static int Amount = 0;
        public static int AverageScore = 0;
        public static int AverageAge = 0;
        public static int TotalAge = 0;
        public static int TotalScore = 0;
        public Demo_17_Student(int age,int score)
        {
            ID = Amount + 1;
            this.age = age;
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
        public int Age //Property
        {
            set
            {
                if (value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Age value has error!");
                }
            }
            get
            {
                return this.age;
            }
        }

        public int PropertyA
        {
            set;
            get;
        }
        public int Height { get; set; }
        public int Score { get => score; set => score = value; }

        private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();
        public int? this[string index]
        {
            get { return scoreDictionary[index]; }
            set { scoreDictionary[index] = value.Value; }
        }



    }

    class Color
    {
        public int Red;
        public int Green;
        public int Blue;
    }

    class Brush
    {
        public static readonly Color color;
        static Brush()
        {
            color = new Color() { Red = 255, Green = 0, Blue = 0 };
        }
    }
}
