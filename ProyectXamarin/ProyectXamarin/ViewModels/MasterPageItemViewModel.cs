using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using ProyectXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectXamarin.ViewModels
{
    public class MasterPageItemViewModel: ViewModelBase
    {
        StorageSession session;
        public MasterPageItemViewModel()
        {
            this.MasterPageItems = new ObservableCollection<MasterPageItem>();
            this.session = new StorageSession();
            
            Task.Run(async () =>
            {
                await this.CargarMenu();
            });

            MessagingCenter.Subscribe<MasterPageItemViewModel>(this, "LOGIN", async (sender) => {
                await this.CargarMenu();
            });

        }

        private ObservableCollection<MasterPageItem> _MasterPageItems;
        public ObservableCollection<MasterPageItem> MasterPageItems
        {
            get { return this._MasterPageItems; }
            set
            {
                this._MasterPageItems = value;
                OnPropertyChanged("MasterPageItems");
            }
        }

        private String _Username;
        public String Username
        {
            get { return this._Username; }
            set { this._Username = value;  OnPropertyChanged("Username"); }

        }

        public async Task CargarMenu()
        {
            this.MasterPageItems.Clear();

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

            MasterPageItems.Add(page1);
            MasterPageItems.Add(page2);
            MasterPageItems.Add(page3);

            Usuarios usuario = await this.session.GetStorageUser();

            if (usuario != null)
            {
                this.Username = usuario.Nombre;
                var page4 = new MasterPageItem()
                {
                    Titulo = "Cerrar sesión",
                    PaginaHija = typeof(HomeView)
                };
                MasterPageItems.Add(page4);
            }

            else
            {
                this.Username = "";
                var page4 = new MasterPageItem()
                {
                    Titulo = "Iniciar sesión",
                    PaginaHija = typeof(LoginView)
                };
                MasterPageItems.Add(page4);

            }
            


        }

    }
}
