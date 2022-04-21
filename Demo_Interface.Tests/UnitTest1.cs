using System;
using Xunit;

namespace watch_learn_CSharp.Tests
{
    public class Demo_InterfaceTest
    {
        [Fact]
        public void PowerLowerThanZero_OK()
        {
            
            PowerSupplyLowerThanZero powerSupplyLowerZero = new PowerSupplyLowerThanZero();
            var fan = new DeskFan(powerSupplyLowerZero);
            var actual = fan.Work();
            var expected = "Won't work";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void PowerHigherThan200_Warning()
        {
            PowerSupplyHignerThan200 powerSupplyHignerThan200 = new PowerSupplyHignerThan200();
            var fan = new DeskFan(powerSupplyHignerThan200);
            var actual = fan.Work();
            var expected = "Warning";
            Assert.Equal(actual, expected);
        } 
    }

    class PowerSupplyLowerThanZero : IPowerSupply
    {
        private int _power = 0;
         
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

    class PowerSupplyHignerThan200 : IPowerSupply
    {
        private int _power = 300;

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
}
