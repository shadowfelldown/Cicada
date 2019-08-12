using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
    public sealed partial class MainPage : Page
    {
        private const int AIN1 = 13;
        private const int AIN2 = 12;
        private const int PB_PIN = 5;
        private const int patOptions = 3;
        private GpioPin pinCW;
        private GpioPin pinCCW;
        private GpioPin pushButton;
        private DispatcherTimer timer;
        private GpioPinValue pushButtonValue;
        public enum GPIO_State {initializing, noGpio, complete}

        public int[,] Pattern { get; set; } = new int[8, 2] { { 1, 2 }, { 2, 1 }, { 1, 2 }, { 2, 2 }, { 1, 2 }, { 1, 1 }, { 2, 2 }, { 1, 2 } };

        public MainPage()
        {
            InitializeComponent();
            //NewTimer(500);

            Unloaded += MainPage_Unloaded;

            InitGPIO();
            Generate_Pattern(Pattern);
            PrintArray(Pattern);

        }
        private void NewTimer(int duration)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(duration);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
private void GpioStat(string option)
        {
            GPIO_State _State
            {
                

                default:

 break;
            }
            GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
            pushButton = gpio.OpenPin(PB_PIN);
            pinCW = gpio.OpenPin(AIN1);
            pinCCW = gpio.OpenPin(AIN2);

            pushButton.SetDriveMode(GpioPinDriveMode.Input);
            pinCW.Write(GpioPinValue.Low);
            pinCW.SetDriveMode(GpioPinDriveMode.Output);
            pinCCW.Write(GpioPinValue.Low);
            pinCCW.SetDriveMode(GpioPinDriveMode.Output);
            GpioStatus.Text = "GPIO pin initialized correctly.";
        }

        private void MainPage_Unloaded(object sender, object args)
        {
            pinCW.Dispose();
            pinCCW.Dispose();
            pushButton.Dispose();
        }
        public void PrintArray(int[,] array)
        {
            StringBuilder Sb = new StringBuilder();

            // Body
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Sb.AppendLine();
                Sb.Append("something ");

                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Sb.Append(' ');
                    Sb.Append(array[j, i].ToString());
                }
            }

            PatternStatus.Text = Sb.ToString();
        }
        
        

        private void FlipLED()
        {
            pushButtonValue = pushButton.Read();
            if (pushButtonValue == GpioPinValue.High)
            {
                pinCW.Write(GpioPinValue.High);
            }
            else if (pushButtonValue == GpioPinValue.Low)
            {
                pinCW.Write(GpioPinValue.Low);
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            FlipLED();
        }

    }
}
