using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Type_Transfer
    {
        public Demo_Type_Transfer()
        {
            Teacher teacher = new Teacher();
            Human h = teacher;
            Animal a = h;

            string str1 = "123";
            string str2 = "a456";
            int i1 = Convert.ToInt32(str1);
            int i2 = 0;
            Console.WriteLine(i1);
            if (int.TryParse(str2,out i2))
            {
                Console.WriteLine(i2);
            }

            Stone stone = new Stone();
            stone.Age = 1000;
            Monkey monkey = (Monkey)stone;
            Console.WriteLine(monkey.Age);

            int devided = 50;
            double devide = 24.0d;
            var result = devided / devide;
            Console.WriteLine(result.GetType().Name);
            Console.WriteLine(result);

            Human h2 = null;
            Console.WriteLine(h is Animal);//true
            Console.WriteLine(h2 is Animal);//false

            object o = null;
            Teacher t2 = o as Teacher;
            //Teacher t2 = (Teacher)o;
            if(t2 != null)
            {
                t2.Teach();
            }

            //double str3 = null; 非法
            Nullable<int> score = null;
            Console.WriteLine(score.HasValue);//false
            score = 100;
            Console.WriteLine(score.HasValue);//true

            int? score_1 = null;//等同于上述
            Console.WriteLine(score_1.HasValue);
            score_1 = score_1 ?? 5;//检查是否为空
            Console.WriteLine(score_1);

            int score_2 = 8;
            score_2 >>= 2;
            Console.WriteLine(score_2);//2
        }
    }

    class Animal
    {
        public void Eat() 
        {
            Console.WriteLine("I'm eating");
        }
    }
    class Human : Animal
    {
        public void Think()
        {
            Console.WriteLine("I can think");
        }
    }
    class Teacher : Human
    {
        public void Teach()
        {
            Console.WriteLine("I can teach");
        }
    }
    class Stone
    {
        public int Age;
        public static explicit operator Monkey(Stone stone)
        {
            Monkey monkey = new Monkey();
            monkey.Age = stone.Age / 10;
            return monkey;
        }
    }
    class Monkey
    {
        public int Age;
    }
}
