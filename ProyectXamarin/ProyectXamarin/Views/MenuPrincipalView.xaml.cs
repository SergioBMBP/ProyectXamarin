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
        public List<MasterPageItem> menu { get; set; }
        public MenuPrincipal()
        {
            InitializeComponent();
            menu = new List<MasterPageItem>();
            var page1 = new MasterPageItem()
            {
                Titulo = "Home",
                PaginaHija = typeof(HomeView)
            };
            var page2 = new MasterPageItem()
            {
                Titulo = "Mostrar Articulos",
                PaginaHija = typeof(ListaArticulosView)
            };
            var page3 = new MasterPageItem()
            {
                Titulo = "Pedidos",
                PaginaHija = typeof(PedidosView)
            };
            menu.Add(page1);
            menu.Add(page2);
            menu.Add(page3);
            
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListaArticulosView)));
            IsPresented = false;

            this.lsvmenu.ItemsSource = menu;
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