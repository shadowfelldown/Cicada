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
        private const int openDur = 400;
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
                if (duration.Name == "shortF")
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(shortF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.Low);
                    pinCCW.Write(GpioPinValue.High);
                    Thread.Sleep(shortF.Value);
                    ResetWing();
                    //DEBUG//
                    //MainPage.SetStatusMessage("GPIO PIN CW=" + pinCW.Read() + "\nPinCCW=" + pinCCW.Read());
                }
                if (duration.Name == "mediumF")
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(mediumF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.Low);
                    pinCCW.Write(GpioPinValue.High);
                    Thread.Sleep(mediumF.Value);
                    ResetWing();
                }
                if (duration.Name == "longF")
                {
                    pinCW.Write(GpioPinValue.High);
                    pinCCW.Write(GpioPinValue.Low);
                    Thread.Sleep(longF.Value);
                    //TODO: replace this sleep with
                    pinCW.Write(GpioPinValue.Low);
                    pinCCW.Write(GpioPinValue.High);
                    Thread.Sleep(longF.Value);
                    ResetWing();
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
        private void ResetWing()
        {
            if (pinCCW.Read() == GpioPinValue.High)
            {
                pinCCW.Write(GpioPinValue.Low);
            }
            if (pinCW.Read() == GpioPinValue.High)
            {
                pinCW.Write(GpioPinValue.Low);
            }
        }
    }
}
