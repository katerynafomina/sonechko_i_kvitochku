using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonechko_i_kvitochku
{
    public class Girl
    {
        private string name;
        private uint dayOfLiving = 1;
        public Girl(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } }
        public delegate void GirlEventDelegate();
        public event GirlEventDelegate SmellFlover;
        public event GirlEventDelegate TakeSelfie;
        public void smellFlower(Flower flover)
        {
            if ((dayOfLiving == 6 || dayOfLiving  == 7) && flover.IsAlive)
            {
                if (flover.IsDay && flover.IsOpen)
                {
                    Console.WriteLine("{0} понюхала квітку {1}", name, flover.Name);
                    if (SmellFlover != null)
                    {
                        SmellFlover();
                    }
                }
            }
            else 
            {
                if (flover.IsAlive)
                {
                    if (!flover.IsDay && flover.IsOpen)
                    {
                        Console.WriteLine("{0} понюхала квітку {1}", name, flover.Name);
                        if (SmellFlover != null)
                        {
                            SmellFlover();
                        }
                    }
                }
            }
            
        }
        public void takeSelfie(Flower flover)
        {
            if ((dayOfLiving % 6 == 0 || dayOfLiving % 7 == 0) && flover.IsAlive)
            {
                if (flover.IsDay && flover.IsOpen)
                {
                    Console.WriteLine("{0} зробила селфі з квіткою {1}", name, flover.Name);
                    if (TakeSelfie != null)
                    {
                        TakeSelfie();
                    }
                }
                
            }
            else 
            {
                if (flover.IsAlive)
                {
                    if (!flover.IsDay && flover.IsOpen)
                    {
                        Console.WriteLine("{0} зробила селфі з квіткою {1}", name, flover.Name);
                        if (TakeSelfie != null)
                        {
                            TakeSelfie();
                        }
                    }
                   
                }
            }
        }
        public void update()
        {
            if (dayOfLiving % 6 == 0 || dayOfLiving%7 == 0)
            {
                Console.WriteLine("{0} сьогодні мала вихідний, і могла насолоджуватись денними квітами", name);
            }
            else
            {
                Console.WriteLine("{0} сьогодні весь день була на роботі, тому вона буде насолоджуватись вечірніми квітами", name);
            }
        }
        public void passDay()
        {
            dayOfLiving+=1;
            Console.WriteLine(dayOfLiving);
        }

    }

}
