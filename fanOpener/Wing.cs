// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using Windows.Devices.Gpio;
using System;
using System.Threading;


namespace fanOpener
{
    /// <summary>
    /// 
    /// </summary>
    public class Wing : MotorObject
    {
        private string location;
        private int status;
        private const int openDur = 500;

        public enum Duration
        {
            shortF = (openDur / 3),
            mediumF = (openDur / 2),
            longF = openDur
        }

        public Wing(string location, int pinCW, int pinCCW) : base(pinCW, pinCCW)
        {
            this.Location = location;
            this.Name = location + " Wing";
        }

        public string Location { get => location; set => location = value; }
        public int Status { get => status; set => status = value; }

        public void flap(Duration duration)
            //TODO: Override the class in motorobject
        {
            switch (duration)
            {
                case Duration.shortF:
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.shortF);
                    //TODO: replace this sleep with
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.shortF);
                    break;
                case Duration.mediumF:
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.mediumF);
                    //TODO: replace this sleep with
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.mediumF);
                    break;
                case Duration.longF:
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.longF);
                    //TODO: replace this sleep with
                    PinCW.Write(GpioPinValue.High);
                    PinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep((int)Duration.longF);
                    break;
                default:
                    break;
            }
        }
    }
}
