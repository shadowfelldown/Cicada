﻿using System;
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
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
    public enum GPIO_State { initializing, noGpio, complete };
    public sealed partial class MainPage : Page
    {
        private const int AIN1 = 13;
        private const int AIN2 = 12;
        private const int BIN1 = 13;
        private const int BIN2 = 13;
        private const int PB_PIN = 5;
        private const int patOptions = 3;
        private static bool gpioDone;
        public static TextBlock GpioStatBlock { get; set; }
        public static bool GpioDone { get => gpioDone; set => gpioDone = value; }



        public MainPage()
        {
            this.InitializeComponent();
            GpioStatBlock = this.GpioStatus;
            //NewTimer(500);
            Unloaded += MainPage_Unloaded;
            var cicada = new Cicada(Config.OneWing);
            //InitGPIO();
            //Generate_Pattern(Pattern);
            //PrintArray(Pattern);

        }

        public static void SetGpioState(GPIO_State selector)
        {
            switch (selector)
            {
                case GPIO_State.initializing:
                    GpioStatBlock.Text = "initializing GPIO";
                    break;
                case GPIO_State.noGpio:
                    GpioStatBlock.Text = "There is no GPIO controller on this device.";
                    break;
                case GPIO_State.complete:
                    GpioStatBlock.Text = "GPIO pin initialized correctly.";
                    break;
                default:
                    break;
            }
        }

        private void MainPage_Unloaded(object sender, object args)
        {

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
    }
}
