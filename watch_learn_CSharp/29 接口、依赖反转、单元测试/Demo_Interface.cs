using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Interface
    {
        public void test()
        {
            Demo29_Engine demo29_Engine = new Demo29_Engine();
            Demo29_Car demo29_Car = new Demo29_Car(demo29_Engine);
            demo29_Car.Run(1000);
            Console.WriteLine(demo29_Car.Speed);

            NokiaPhone nokiaPhone = new NokiaPhone();
            EricssonPhone ericssonPhone = new EricssonPhone();
            PhoneUser phoneUser = new PhoneUser(nokiaPhone);
            phoneUser.UsePhone();
            phoneUser.Phone = ericssonPhone;
            phoneUser.UsePhone();

            PowerSupply powerSupply = new PowerSupply();
            var fan = new DeskFan(powerSupply);
            Console.WriteLine(fan.Work()); 
        }
    }
    class Demo29_Engine
    {
        private int _RPM;

        public int RPM
        {
            get { return _RPM; }
            private set { _RPM = value; }
        }

        public void Work(int gas)
        {
            this.RPM = 1000 * gas;
        }
    }
    class Demo29_Car {
        private Demo29_Engine _engine;
        public Demo29_Car(Demo29_Engine demo29_Engine)
        {
            _engine = demo29_Engine;
        }

        public int Speed { get; set; }

        public void Run(int gas)
        {
            _engine.Work(gas);
            Speed += _engine.RPM / 100;
        }
    }

    interface IPhone
    {
        void Dail();
        void PickUp();
        void Send();
        void Recieve();
    }

    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokia calling");
        }

        public void PickUp()
        {
            Console.WriteLine("Hello!This is Tim!");
        }

        public void Recieve()
        {
            Console.WriteLine("Nokia message ring!");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }

    class EricssonPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Ericsson is calling ...");
        }

        public void PickUp()
        {
            Console.WriteLine("Hi!This is Tim!");
        }

        public void Recieve()
        {
            Console.WriteLine("Ericsson ring ...");
        }

        public void Send()
        {
            Console.WriteLine("Good evening!") ;
        }
    }

    class PhoneUser
    {
        private IPhone _phone;
        public IPhone Phone
        {
            private get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        public PhoneUser(IPhone phone)
        {
            _phone = phone;
        }
        public void UsePhone()
        {
            _phone.Dail();
            _phone.PickUp();
            _phone.Recieve();
            _phone.Send();
        }

    }

    public interface IPowerSupply
    {
        int GetPower();
    }


    public class PowerSupply:IPowerSupply {
        private int _power = 100;

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public int GetPower()
        {
            return Power;
        }
    }

    public class DeskFan
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }
        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power <= 0)
            {
                return "Won't work";
            }
            else if(power < 100)
            {
                return "Slow";
            }
            else if (power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning";
            }
        }
    }
}
