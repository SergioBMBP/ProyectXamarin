using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.ViewModels
{
    public class PedidoViewModel: ViewModelBase
    {
        IRepositoryPedidos repo;

        public PedidoViewModel()
        {
            this.repo = new RepositoryPedidos();
        }
        

        private Pedidos _Pedido;
        public Pedidos Pedido
        {
            get { return _Pedido; }
            set { this._Pedido = value; OnPropertyChanged("Pedido"); }
        }


    }
}
