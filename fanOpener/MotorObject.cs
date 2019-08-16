using System;
using Windows.Devices.Gpio;
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class MotorObject: Cicada
        {
        GpioController controller;
        MainPage main;
        //timer = 
            //TODO: add timer into this class.
        
            private bool enabled;
            private string name;
        private int CWpin;
        private int CCWpin;
        private GpioPin pinCW;
        private GpioPin pinCCW;
        public MotorObject(int CWpin, int CCWpin)
        {
            this.main = MainPage
            this.CCWpin = CCWpin;
            this.CWpin = CWpin;
            initialize();
            main.GpioDone = false;
        }
        private void initialize()
        {
            controller = GpioController.GetDefault();
            initializeGpio();
            //initializeLimitSwitches();
            initializeMotors();
        }
        private void initializeGpio()
        {
            controller = GpioController.GetDefault();
            if (controller == null)
            {
                main.SetGpioState(MainPage.GPIO_State.noGpio);
                return;
            }
            else if (main.GpioDone == true)
            {
                main.SetGpioState(MainPage.GPIO_State.complete);

                }
            else
            {
                    main.SetGpioState(MainPage.GPIO_State.initializing);
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
            public bool MotorEnabled { get => enabled; set => enabled = value; }
            public string Name { get => name; set => name = value; }
        public GpioPin PinCW { get => pinCW; set => pinCW = value; }
        public GpioPin PinCCW { get => pinCCW; set => pinCCW = value; }

        public virtual void Rotate(int duration)
        {
            //will be overridden in child classes. duration to rotate clockwise and counterclockwise for motorObject.
        }
        private static void AddNewTimer(object scroll, int milliseconds, Action method)
        {
           //add new timer each time object is initiated with a duration for timing that duration
        }
    }
}
