using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Debug
    {
        public static double GetCircleArea(double r)
        {
            return r * r * 3.14;
        }
        public static double GetCylinderVolume(double r,double h)
        {
            return GetCircleArea(r) * h;
        }
        public static double GetConeVolume(double r,double h)
        {
            return GetCylinderVolume(r, h) * 1 / 3;
        }
    }
    class student
    {
        public int age;
        public string name;
        public student(int initage,string initname)
        {
            age = initage;
            name = initname;
        }
    }
}
