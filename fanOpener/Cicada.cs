using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanOpener
{
    public enum Config { twoWings=1, OneWing=2 }
    public enum AvailableGpioPin : int
    {
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 29
        /// </summary>
        GpioPin_5 = 5,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 31
        /// </summary>
        GpioPin_6 = 6,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 32
        /// </summary>
        GpioPin_12 = 12,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 33
        /// </summary>
        GpioPin_13 = 13,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 36
        /// </summary>
        GpioPin_16 = 16,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 12
        /// </summary>
        GpioPin_18 = 18,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 15
        /// </summary>
        GpioPin_22 = 22,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 16
        /// </summary>
        GpioPin_23 = 23,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 18
        /// </summary>
        GpioPin_24 = 24,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 22
        /// </summary>
        GpioPin_25 = 25,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 37
        /// </summary>
        GpioPin_26 = 26,
        /// <summary>
        /// Raspberry Pi 2 - Header Pin Number : 13
        /// </summary>
        GpioPin_27 = 27
    }
    public class Cicada
    {
        private const int AIN1 = 13;
        private const int AIN2 = 12;
        private const int BIN1 = 22;
        private const int BIN2 = 23;
        public bool Enabled { get; set; }
        public static Wing LeftWing;
        public static Wing RightWing;
        public BeatPattern beatPattern;
        /// <summary>
        /// Available Gpio Pins. Refer: https://ms-iot.github.io/content/en-US/win10/samples/PinMappingsRPi2.htm
        /// </summary>
        
        public Cicada(Config config)
        {
            beatPattern = new BeatPattern();
            makeObjects(config);
            MainPage.SetStatusMessage("Cicada created, Config=" + config.ToString("g"));
        }
        private void makeObjects(Config config)
        {
            var collapsed = Windows.UI.Xaml.Visibility.Collapsed;
            var shown = Windows.UI.Xaml.Visibility.Visible;

            switch (config)
            {
                case Config.OneWing:
                    LeftWing = new Wing("left", AvailableGpioPin.GpioPin_13, AvailableGpioPin.GpioPin_12);
                    MainPage.RightPattGrid.Visibility = collapsed;
                    MainPage.LeftPattGrid.Visibility = shown;
                    break;
                case Config.twoWings:
                    LeftWing = new Wing("left", AvailableGpioPin.GpioPin_13, AvailableGpioPin.GpioPin_12);
                    RightWing = new Wing("Right", AvailableGpioPin.GpioPin_22, AvailableGpioPin.GpioPin_23);
                    MainPage.RightPattGrid.Visibility = shown;
                    MainPage.LeftPattGrid.Visibility = shown;
                    break;
                default:
                    break;
            }
        }
    }
}
