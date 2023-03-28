using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonechko_i_kvitochku
{
    public class Bee
    {
        public delegate void NectarEventHandler();
        public event NectarEventHandler NectarCollected;
        private string name;
        public Bee(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } }
        public void CollectNectar ( Flower flower )
        {
            if (flower.IsAlive && flower.IsOpen)
            {
                Console.WriteLine("{0} зібрав нектару з квітки {1}.", name, flower.Name);
                if (NectarCollected != null)
                {
                    NectarCollected();
                }
            }
            if (flower.IsAlive && !flower.IsOpen)
            {
                Console.WriteLine("{0} продетіла над квіткою {1}, але вона була закрита.", name, flower.Name);
                if (NectarCollected != null)
                {
                    NectarCollected();
                }
            }
        }
        
    }
    //public class NectarCollectedEventArgs : EventArgs
    //{
    //    public string BeeName { get; set; }
    //    public Flower Flower { get; set; }

    //    public NectarCollectedEventArgs(string beeName, Flower flower)
    //    {
    //        BeeName = beeName;
    //        Flower = flower;
    //    }
    //}
    public class NightButterfly
    {
        private string name;
        public NightButterfly(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } }
        public delegate void NectarEventHandler();
        public event NectarEventHandler NectarDrink;
        public void DrinkNectar(Flower flower)
        {
            if (flower.IsAlive && flower.IsOpen)
            {
                Console.WriteLine("{0} випив нектару з квітки {1}.", name, flower.Name);
                if (NectarDrink != null)
                {
                    NectarDrink();
                }
            }
            if (flower.IsAlive && !flower.IsOpen)
            {
                Console.WriteLine("{0} продетів над квіткою {1}, але вона була закрита.", name, flower.Name);
                if (NectarDrink != null)
                {
                    NectarDrink();
                }
            }
        }
    }
}
