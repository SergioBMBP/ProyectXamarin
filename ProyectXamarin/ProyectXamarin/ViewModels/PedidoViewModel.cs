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
    public class PedidoViewModel: ViewModelBase
    {
        IRepositoryPedidos repo;
        public PedidoViewModel()
        {
            this.repo = new RepositoryPedidos();

        }
        private ObservableCollection<VistaArticuloPedido> _ArticulosPedido;
        public ObservableCollection<VistaArticuloPedido> ArticulosPedido
        {
            get { return _ArticulosPedido; }
            set { this._ArticulosPedido = value; OnPropertyChanged("ArticulosPedido"); }
        }


        private Pedidos _Pedido;
        public Pedidos Pedido
        {
            get { return _Pedido; }
            set { this._Pedido = value; OnPropertyChanged("Pedido"); }
        }
        
    }
}
