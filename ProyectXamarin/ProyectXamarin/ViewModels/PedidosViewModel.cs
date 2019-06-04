using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
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
    public class PedidosViewModel:ViewModelBase
    {
        IRepositoryPedidos repoP;
        IRepositoryUsuarios repoU;
        StorageSession session;
        public PedidosViewModel()
        {
            this.repoP = new RepositoryPedidos();
            this.session = new StorageSession();
            this.repoU = new RepositoryUsuarios();

            Task.Run(async()=> {
                await CargarPedidos();
            });

        }
        


        private async Task CargarPedidos()
        {
            Usuarios user =await session.GetStorageUser();

            if (user!=null)
            {
                Usuarios userStoraged = await this.session.GetStorageUser();
                String token=await session.GetStorageToken();
                Pedidos = new ObservableCollection<Pedidos>(await repoP.GetPedidosUsuario(user.Id,token));
            }

            
        }
       
        private ObservableCollection<Pedidos> _Pedidos;
        public ObservableCollection<Pedidos> Pedidos
        {
            get { return _Pedidos; }
            set { this._Pedidos = value; OnPropertyChanged("Pedidos"); }
        }
        public Command DetallesPedidosView
        {
            get
            {
                return new Command(async (pedido) =>
                {
                    DetallesPedidosView view = new DetallesPedidosView();
                    PedidoViewModel viewmodel = new PedidoViewModel();

                    viewmodel.Pedido = pedido as Pedidos;
                    view.BindingContext = viewmodel;

                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);

                });
            }
        }
    }
}
