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
        StorageSession session;
        ApiConnect connect;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MenuPrincipal());
        }

        protected override async void OnStart()
        {
            this.session = new StorageSession();
            this.connect = new ApiConnect();
            String token = await session.GetStorageToken();
            if(token != null)
            {
                //CONTINUARÁ...
            }
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
