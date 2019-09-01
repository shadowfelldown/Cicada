using System;
using Windows.Devices.Gpio;
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class MotorObject
        {
        // gets the default GpioController and makes it controller.
        static GpioController controller;
        //timer = 
        //TODO: add timer into this class.

        private bool enabled;
            private string name;
        //initialize two GPIO pins
        public GpioPin pinCW { get; set; }
        public GpioPin pinCCW { get; set; }
        public State _CurrentState { get; set; }
        private const int rotateDur = 500;
        /// <summary>
        /// Available driving states
        /// </summary>
        public enum State : byte
        {
            MovingForward,
            MovingReverse,
            Stopped
        }

        public MotorObject(AvailableGpioPin availableCCW, AvailableGpioPin availabeCW)
        {
            initialize(availableCCW, availabeCW);
            Duration.shortF = new Duration(rotateDur / 3, "shortF");
            Duration.mediumF = new Duration(rotateDur / 2, "mediumF");
            Duration.longF = new Duration(rotateDur / 2, "longF");
        }
        private void initialize(AvailableGpioPin availableCCW, AvailableGpioPin availabeCW)
        {
            try
            {
                initializeGpio();
                //initializeLimitSwitches();
            }
            catch (ArgumentException)
            {
            }
            finally
            {
                if (controller != null)
                {
                    initializeMotors(availableCCW, availabeCW);
                    MainPage.GpioDone = true;
                    MainPage.SetStatusMessage(GPIO_State.complete);
                }

            }

        }
        private void initializeGpio()
        {
            controller = GpioController.GetDefault();
            if (controller == null)
            {
                MainPage.SetStatusMessage(GPIO_State.noGpio);
                throw new ArgumentException("GPIO not found");
            }
            else if (MainPage.GpioDone == true)
            {
                MainPage.SetStatusMessage(GPIO_State.complete);

                }
            else
            {
                MainPage.SetStatusMessage(GPIO_State.initializing);
                }
        }
        private void initializeMotors(AvailableGpioPin Pin_Motor_CCW, AvailableGpioPin Pin_Motor_CW)
        {
            // If GpioPins are not null then make them first null to release old pins.
            // Check only one pin against null and if it is not then null all.
            if (pinCCW != null)
            {
                pinCCW = null;
                pinCW = null;
            }
            /* Initialize motor pins */

            pinCCW = controller.OpenPin((int)Pin_Motor_CCW);
            pinCW = controller.OpenPin((int)Pin_Motor_CW);
            //Make sure they are off.
            pinCCW.Write(GpioPinValue.Low);
            pinCW.Write(GpioPinValue.Low);
            
            //Set Drive Mode
            pinCCW.SetDriveMode(GpioPinDriveMode.Output);
            pinCW.SetDriveMode(GpioPinDriveMode.Output);

            //Set current state
            _CurrentState = State.Stopped;
        }
            public bool MotorEnabled { get => enabled; set => enabled = value; }
            public string Name { get => name; set => name = value; }

        public virtual void Rotate(int duration)
        {
            //will be overridden in child classes. duration to rotate clockwise and counterclockwise for motorObject.
        }
        public virtual void Rotate(Duration duration)
        {
                    if (duration == Duration.shortF)
                    {
                        _CurrentState = State.MovingForward;

                        pinCW.Write(GpioPinValue.High);
                        pinCCW.Write(GpioPinValue.Low);
                        Thread.Sleep(Duration.shortF.Value);

                        _CurrentState = State.MovingReverse;

                        pinCW.Write(GpioPinValue.Low);
                        pinCCW.Write(GpioPinValue.Low);
                    }
                    if (duration == Duration.mediumF)
                    {
                        _CurrentState = State.MovingForward;

                        pinCW.Write(GpioPinValue.High);
                        pinCCW.Write(GpioPinValue.Low);
                        Thread.Sleep(Duration.mediumF.Value);
                        //TODO: replace this sleep with
                        _CurrentState = State.MovingReverse;

                        pinCW.Write(GpioPinValue.Low);
                        pinCCW.Write(GpioPinValue.Low);
                    }
                    if (duration == Duration.longF)
                    {
                        _CurrentState = State.MovingForward;

                        pinCW.Write(GpioPinValue.High);
                        pinCCW.Write(GpioPinValue.Low);
                        Thread.Sleep(Duration.longF.Value);
                        //TODO: replace this sleep with
                        _CurrentState = State.MovingReverse;

                        pinCW.Write(GpioPinValue.Low);
                        pinCCW.Write(GpioPinValue.Low);
                    }
                    else
                    {
                        return;
                    }
        }
        private static void AddNewTimer(object scroll, int milliseconds, Action method)
        {
           //add new timer each time object is initiated with a duration for timing that duration
        }
    }
}
