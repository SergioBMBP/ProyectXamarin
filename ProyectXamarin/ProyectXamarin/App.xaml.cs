using ProyectXamarin.Configuration;
using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using ProyectXamarin.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProyectXamarin
{
    public partial class App : Application
    {
        StorageSession storage;
        private static IoCConfiguration _Locator;
        //UNA PROPIEDAD QUE NOS DEVUELVA UN new IoCConfiguration 
        // O QUE RECUPERE EL QUE YA TENGAMOS CREADO
        public static IoCConfiguration Locator
        {
            get
            {
                return _Locator = _Locator ?? new IoCConfiguration();
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MenuPrincipal());
            
        }

        protected override async void OnStart()
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
