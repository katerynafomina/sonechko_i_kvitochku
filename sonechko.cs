using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonechko_i_kvitochku
{
    public class Sun
    {
        private bool Shining;
        private uint day = 0;
        public delegate void SunStateHander(bool shining);
        public event SunStateHander StateHander;
        public Sun()
        {
            this.Shining = false;
        }
        public bool isDay()
        {
            return Shining;
        }
        public uint Day { get { return day; } }

        public void Rise()
        {
            Shining = true;
            StateHander?.Invoke(Shining);
            Console.WriteLine("Сонце сходить");
            day++;
        }

        public void Set()
        {
            Shining = false;
            StateHander?.Invoke(Shining);
            Console.WriteLine("Сонце заходить");
        }


    }
}
