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
        public static Duration shortF = new Duration(openDur / 3, "shortF");
        public static Duration mediumF = new Duration(openDur / 2, "mediumF");
        public static Duration longF= new Duration(openDur, "longF");

        public Wing(string location, AvailableGpioPin availableCCW, AvailableGpioPin availabeCW) : base(availableCCW, availabeCW)
        {
            this.Location = location;
            this.Name = location + " Wing";
        }

        public string Location { get => location; set => location = value; }
        public int Status { get => status; set => status = value; }
        public override void Rotate(Duration duration)
        {
            {
                if (duration == shortF)
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.shortF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.shortF.Value);
                }
                if (duration == mediumF)
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.mediumF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.mediumF.Value);
                }
                if (duration == longF)
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.longF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(Duration.longF.Value);
                }
                else
                {
                    return;
                }
            }
        }
        public void flap(Duration duration)
        {
            Rotate(duration);
        }
    }
}
