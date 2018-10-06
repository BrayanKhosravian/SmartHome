using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SmartHome.Interfaces;
using Xamarin.Forms;

namespace SmartHome.ViewModels
{
    class LightPageViewModel : BaseViewModel
    {
         private readonly IBluetoothController _bluetoothController = DependencyService.Get<IBluetoothController>();

        public ICommand Command_Execute { get; private set; }

        public LightPageViewModel(IPageService pageService) : base(pageService)
        {
            Command_Execute = new Command<string>( 
                execute: (string param) =>
                {
                    _bluetoothController.SendData(param);
                    // ((App) Application.Current).BluetoothController.SendData(param);
                    _bluetoothController.SendData(param);
                    ((Command)Command_Execute).ChangeCanExecute();
                });
            
        }

        private bool sliderIsEnabled = false;
        public bool SliderIsEnabled
        {
            get => sliderIsEnabled;
            set
            {
                if (sliderIsEnabled != value)
                {
                    sliderIsEnabled = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private bool switchIsToggled = false;
        public bool SwitchIsToggled
        {
            get => switchIsToggled;
            set
            {
                if (switchIsToggled != value)
                {
                    switchIsToggled = value;
                    base.OnPropertyChanged();

                    SliderIsEnabled = value;
                }
            }
        }

        private double sliderValue = 0;
        public double SliderValue
        {
            get => sliderValue;
            set
            {
                if (sliderValue != value)
                {
                    sliderValue = value;
                    base.OnPropertyChanged();
                    
                    if(sliderValue > 0 && sliderValue < 5){ _bluetoothController.SendData("LightSlider0");}
                    else if(sliderValue > 5 && sliderValue < 25) _bluetoothController.SendData("LightSlider25");
                    else if(sliderValue > 25 && sliderValue < 50) _bluetoothController.SendData("LightSlider50");
                    else if(sliderValue > 50 && sliderValue < 75) _bluetoothController.SendData("LightSlider75");
                    else if(sliderValue > 75 && sliderValue <= 100) _bluetoothController.SendData("LightSlider100");
                    
                }
            }
        }


    }
}
