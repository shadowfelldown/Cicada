using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanOpener
{
    public class Cicada
    {
        private const int AIN1 = 13;
        private const int AIN2 = 12;
        private const int BIN1 = 22;
        private const int BIN2 = 23;
        public enum Config { twoWings, OneWing };
        public string Name { get; set; }
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
                    this.LeftWing = new Wing("left", AIN1, AIN2);
                    break;
                case Config.twoWings:
                    this.LeftWing = new Wing("left", AIN1, AIN2);
                    this.RightWing = new Wing("Right", BIN1, BIN2);
                    break;
                default:
                    break;
            }
        }
    }
}
