// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class Wing:MotorObject
        {
            private string location;
            private int status;
            private int openDur;
        public Wing(string location, int pinCW, int pinCCW) : base(pinCW, pinCCW)
            {
            this.Location = location;
            Name = location + " Wing";
            }

            public string Location { get => location; set => location = value; }
            public int Status { get => status; set => status = value; }
            public int OpenDur { get => openDur; set => openDur = value; }
        }
}
