using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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
                Pedidos = new ObservableCollection<Pedidos>(await repoP.GetPedidosUsuario(user.Id));
            }

            
        }

        private ObservableCollection<Pedidos> _Pedidos;
        public ObservableCollection<Pedidos> Pedidos
        {
            get { return _Pedidos; }
            set { this._Pedidos = value; OnPropertyChanged("Pedidos"); }
        }
    }
}
