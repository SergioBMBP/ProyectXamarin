using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.ViewModels
{
    public class PedidosViewModel:ViewModelBase
    {
        IRepositoryPedidos repo;
        public PedidosViewModel()
        {
            this.repo = new RepositoryPedidos();
            Task.Run(async () => {
                await CargarArticulos();
            });
        }

        private async Task CargarArticulos()
        {
            Articulos = new ObservableCollection<Pedidos>(await repo.GetPedidos());
        }

        private ObservableCollection<Pedidos> _Articulos;
        public ObservableCollection<Pedidos> Articulos
        {
            get { return _Articulos; }
            set { this._Articulos = value; OnPropertyChanged("Pedidos"); }
        }
    }
}
