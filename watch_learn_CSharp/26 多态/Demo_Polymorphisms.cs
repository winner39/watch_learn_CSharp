using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Polymorphisms
    {
        public void test()
        {
            Demo26_Vehicle vehicle = new Demo26_RaceCar();
            vehicle.Run();// Car is running
            (vehicle as Demo26_RaceCar).Run(); // RaceCar is running
            Console.WriteLine(vehicle.Speed); // 110
            
        }
    }
    class Demo26_Vehicle
    {
        private int _speed = 100;

        public virtual int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        public virtual void Run()
        {
            Console.WriteLine("Vehicle is running.");
        }
    }
    class Demo26_Car : Demo26_Vehicle
    {
        private int speed_bias = 10;

        public override void Run()
        {
            Console.WriteLine("Car is running.");
        }

        public override int Speed { get => base.Speed + speed_bias; set => base.Speed = value; }
    }

    class Demo26_RaceCar : Demo26_Car
    {
        public void Run()
        {
            Console.WriteLine("RaceCar is running.");
        }
    }
}
