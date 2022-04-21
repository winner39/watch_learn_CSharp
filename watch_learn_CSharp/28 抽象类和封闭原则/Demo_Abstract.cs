using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp {
    class Demo_Abstract
    {
        public void test()
        {
            IDemo28_Vehecle_Base demo28_Vehecle = new Demo28_Car();
            demo28_Vehecle.Run();
        }

    }

    abstract class Demo28_Vehecle : IDemo28_Vehecle_Base//如果这里不加abstract，则该类必须实现所有的抽象方法，若加了abstract，则可以选择性重写那些抽象方法，剩余的留着给子类解决
    {
        public override void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public override void Fill()
        {
            Console.WriteLine("Pay and fill");
        }
    }

    class Demo28_Car : Demo28_Vehecle//作为非抽象类，因为Demo_Vehecle已经挡下了Stop()和Fill()，所以该类只需要实现剩下的那个Run()，当然，Stop() Fill()是否需要重写看你需求
    {
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }
    class Demo28_Truck : Demo28_Vehecle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    class RaceCar : Demo28_Vehecle
    {
        public override void Run()
        {
            Console.WriteLine("RaceCar is running");
        }
        public override void Stop()
        {
            Console.WriteLine("kakakakakakakaka!");
        }
    }


    abstract class IDemo28_Vehecle_Base
    {
        public abstract void Stop();
        public abstract void Run();
        public abstract void Fill();
    }
}
