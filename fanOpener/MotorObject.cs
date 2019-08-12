using Windows.Devices.Gpio;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class MotorObject
        {
        GpioController controller;
            private bool enabled;
            private string name;
        private int CWpin;
        private int CCWpin;
            private GpioPin pinCW;
            private GpioPin pinCCW;
        public MotorObject(int CWpin, int CCWpin)
        {
            this.CCWpin = CCWpin;
            this.CWpin = CWpin;
            initialize();
        }
        private void initialize()
        {
            controller = GpioController.GetDefault();

            initializeLimitSwitches();
            initializeMotors();
        }
        private void initializeGpio(object gpio)
        {
            controller = GpioController.GetDefault();
            if (controller == null)
            {
                gpio = "There is no GPIO controller on this device.";
                return;
            }
        }
        private void initializeMotors()
        {
            /* Initialize motor pins */

            pinCCW = controller.OpenPin(CCWpin);
            pinCW = controller.OpenPin(CWpin);

            pinCCW.Write(GpioPinValue.Low);
            pinCW.Write(GpioPinValue.Low);

            pinCCW.SetDriveMode(GpioPinDriveMode.Output);
            pinCW.SetDriveMode(GpioPinDriveMode.Output);
        }
            public bool Enabled { get => enabled; set => enabled = value; }
            public string Name { get => name; set => name = value; }
        }
}
