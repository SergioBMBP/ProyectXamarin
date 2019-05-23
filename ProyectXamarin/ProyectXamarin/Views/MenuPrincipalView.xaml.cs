using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using ProyectXamarin.ViewModels;
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
    public partial class MenuPrincipal : MasterDetailPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListaArticulosView)));
            IsPresented = false;

            this.lsvmenu.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.PaginaHija;
            if (item.PaginaHija == typeof(LoginView))
            {
                LoginView view = new LoginView();
                await Application.Current.MainPage.Navigation.PushModalAsync(view);
            }
            else if (item.Titulo == "Cerrar sesión" && item.PaginaHija == typeof(HomeView)) {
                StorageSession session = new StorageSession();
                session.RemoveAllStorage();
                MessagingCenter.Send<MasterPageItemViewModel>(App.Locator.MasterPageItemViewModel, "LOGIN");

                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
            


        }
    }
}