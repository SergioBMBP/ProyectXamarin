using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectXamarin.ViewModels
{
    public class CestaViewModel: ViewModelBase
    {
        IRepositoryPedidos repo;
        
        public CestaViewModel()
        {
            List<Articulos> lista = App.Locator.SessionService.Cesta;
            this.Cesta = new ObservableCollection<Articulos>(lista);
            this.repo = new RepositoryPedidos();
        }

        private ObservableCollection<Articulos> _Cesta;
        public ObservableCollection<Articulos> Cesta
        {
            get { return this._Cesta; }
            set { this._Cesta = value; OnPropertyChanged("Cesta"); }
        }

        public Command RealizarPedido
        {
            get
            {
                return new Command(async () =>
                {

                    int idPedido = await this.repo.GetMaximoPedido();
                    
                    List<Articulos> lista = new List<Articulos>(Cesta);
                    await this.repo.RealizarPedido(lista, idPedido);

                });
            }
        }
    }
}
