using ProyectXamarin.Models;
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

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.PaginaHija;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;


        }
    }
}