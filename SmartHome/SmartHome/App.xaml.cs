using System;
using SmartHome.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartHome
{
    public partial class App : Application
    {
         public readonly IBluetoothController BluetoothController = DependencyService.Get<IBluetoothController>();

        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage(new StartPage() );
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
