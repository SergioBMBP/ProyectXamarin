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
        

        public CestaViewModel(IRepositoryPedidos repo)
        {
            List<Articulos> lista = App.Locator.SessionService.Cesta;
            this.Cesta = new ObservableCollection<Articulos>(lista);
            this.repo = repo;
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
                    this.repo.
                });
            }
        }
    }
}
