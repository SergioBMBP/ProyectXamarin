using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using ProyectXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Repositories.IRepositoryArticulos r;

        public HomeView ()
		{
			InitializeComponent ();
             r = new Repositories.RepositoryArticulos();
            Task.Run(async()=> {
                await FillScrollMarca();
            });
            
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

        private async Task FillScrollMarca() {
           
            List<String> marcas =await r.GetMarcas();
            if (marcas != null)
            {
                foreach (String marca in marcas)
                {
                    Button button = new Button
                    {
                        Text = marca,
                        BackgroundColor = Color.FromHex("aacfd0"),
                        
                    };
                    button.Clicked += Button_Clicked;

                    ScrollMarca.Children.Add(button);

                }

            }
            


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            App.Locator.SessionService.busquedaMarca =  b.Text;

            ListaArticulosView view = new ListaArticulosView();
            MessagingCenter.Send<AticulosViewmodel>(App.Locator.ArticulosViewModel, "BUSCAR");

            await Application.Current.MainPage.Navigation.PushModalAsync(view);

        }
    }
}