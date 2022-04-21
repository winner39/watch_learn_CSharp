using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpLib;


namespace watch_learn_CSharp
{
    class Demo_Class
    {
        public void test()
        {
            HelpCalculator a = new HelpCalculator();

            Car car = new Car();
            Type t = typeof(Car);
            Console.WriteLine(t.Name);
            while (t.BaseType != null)
            {
                t = t.BaseType;
                Console.WriteLine(t.Name);
            }

            Vehicle vehicle = new Car();
            
        }
    }

    class Vehicle
    {
        protected string name;
        
    }

    class Car : Vehicle
    {
        public void Outputter()
        {
            Console.WriteLine(base.name);
        }
    }
}
