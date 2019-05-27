using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{

		public HomeView ()
		{
			InitializeComponent ();

            btnmore.Clicked += Btnmore_Clicked;
            
        }

        private async void Btnmore_Clicked(object sender, EventArgs e)
        {
            MenuPrincipal view = new MenuPrincipal();
            view.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListaArticulosView)));
            view.IsPresented = false;
            await App.Current.MainPage.Navigation.PushAsync(view);
            //new NavigationPage((Page)Activator.CreateInstance(typeof(ListaArticulosView)));

        }
    }
}