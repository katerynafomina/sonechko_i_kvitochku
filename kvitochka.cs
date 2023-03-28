using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonechko_i_kvitochku
{
    public class Flower
    {
        private string name;
        private bool isAlive;
        private bool isOpen;
        private bool isDay;
        private uint dayOfLiving = 0;
        private uint dayAlive;
        public delegate void FlowerDelegate(Flower flower);
        public event FlowerDelegate OnBloom;
        public event FlowerDelegate OnClose;
        public event FlowerDelegate OnDeath;

        public string Name { get { return name; } }
        public uint DayOfLiving { get { return dayOfLiving; } }
        public Flower(string name, string day, uint dayAlive)
        {
            this.name = name;
            if (day == "day")
            {
                this.isDay = true;
            }
            else
            {
                this.isDay = false;
            }
            this.isOpen = false;
            this.isAlive = true;
            this.dayAlive = dayAlive;
        }
        public bool IsOpen { get { return this.isOpen; } }
        public bool IsAlive { get { return this.isAlive; } }
        public bool IsDay { get { return this.isDay; } }
        public void Update(bool isDay)
        {
            if (!this.isAlive)
            {
                return;
            }

            if (this.isDay && !isDay)
            {
                // Nighttime, close flower
                this.isOpen = false;
                Console.WriteLine("денна квітка {0} закривається.", this.name);
                if (OnClose != null)
                {
                    OnClose(this);
                }
            }
            else if (!this.isDay && isDay)
            {
                // Nighttime, close flower
                this.isOpen = false;
                Console.WriteLine("нічна квітка {0} закривається.", this.name);
                if (OnClose != null)
                {
                    OnClose(this);
                }
            }
            else if (this.isDay && isDay)
            {
                // Daytime, open flower
                this.isOpen = true;
                Console.WriteLine("денна квітка {0} відкривається.", this.name);
                if (OnBloom != null)
                {
                    OnBloom(this);
                }
            }
            else if (!this.isDay && !isDay)
            {
                // Daytime, open flower
                this.isOpen = true;
                Console.WriteLine("нічна квітка {0} відкривається.", this.name);
                if (OnBloom != null)
                {
                    OnBloom(this);
                }
            }
        }
        public void dayPass()
        {
            dayOfLiving += 1;
            if (dayOfLiving == dayAlive)
            {
                this.Die();
            }
        }
        public virtual void Die()
        {
            this.isAlive = false;
            this.isOpen = false;
            Console.WriteLine("{0} відмирає.", this.name);
            if (OnDeath != null)
            {
                OnDeath(this);
            }
        }
        
    }
}
