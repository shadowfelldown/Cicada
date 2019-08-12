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
        
private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                pinCW = null;
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
        private int[,] Generate_Pattern(int[,] pattern)
        {
            Random randNum = new Random();
            Array.Clear(pattern, 0, pattern.Length);
            for(int i = 0; i<=3; i++)
            {
                pattern[i, 0] = randNum.Next(1, patOptions);
                pattern[i, 1] = randNum.Next(1, 2);
            }
            //PrintArray(pattern);
            return pattern;
        }
       public class MotorObject
        {

            private bool enabled;
            private string name;
            private GpioPin pinCW;
            private GpioPin pinCCW;
            public void InitGPIO(int AIN1, int AIN2)
            {

                pinCW = gpio.OpenPin(AIN1);
                pinCCW = gpio.OpenPin(AIN2);
            }
            public bool Enabled { get => enabled; set => enabled = value; }
            public string Name { get => name; set => name = value; }
        }
        public class Wing:MotorObject
        {
            private string location;
            private int status;
            private int openDur;
            public Wing(string location)
            {
                this.Location = location;
            }

            public string Location { get => location; set => location = value; }
            public int Status { get => status; set => status = value; }
            public int OpenDur { get => openDur; set => openDur = value; }
        }
        private void PlayPattern(int[,] pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i, 1] == 1)
                {
                    switch (pattern[i, 0])
                    {
                        case 1:
                            WingFlap(shortFlap, left);
                                break;
                        case 2:
                            WingFlap(medFlap, left);
                                break;
                        case 3:
                            WingFlap(longFlap, left);
                                break;
                        default:
                            break;
                    }

                }
                if (pattern[i, 1] == 2)
                {
                    switch (pattern[i, 0])
                    {
                        case 1:
                            WingFlap(shortFlap, right);
                            break;
                        case 2:
                            WingFlap(medFlap, right);
                            break;
                        case 3:
                            WingFlap(longFlap, right);
                            break;
                        default:
                            break;
                    }
                }
                if (pattern[i, 1] == 3)
                {
                    switch (pattern[i, 0])
                    {
                        case 1:
                            WingFlap(shortFlap, both);
                            break;
                        case 2:
                            WingFlap(medFlap, both);
                            break;
                        case 3:
                            WingFlap(longFlap, both);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }
            }

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
