using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanOpener
{
    public enum Config { twoWings=1, OneWing=2 }
    public class Cicada
    {
        private const int AIN1 = 13;
        private const int AIN2 = 12;
        private const int BIN1 = 22;
        private const int BIN2 = 23;
        public bool Enabled { get; set; }
        public Wing LeftWing;
        public Wing RightWing;
       public Cicada(Config config)
        {
            makeObjects(config);
        }
        private void makeObjects(Config config)
        {
            switch (config)
            {
                case Config.OneWing:
                    LeftWing = new Wing("left", AIN1, AIN2);
                    break;
                case Config.twoWings:
                    LeftWing = new Wing("left", AIN1, AIN2);
                    RightWing = new Wing("Right", BIN1, BIN2);
                    break;
                default:
                    break;
            }
        }
    }
}
