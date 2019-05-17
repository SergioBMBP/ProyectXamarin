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
    public class AticulosViewmodel:ViewModelBase
    {
        IRepositoryArticulos repo;
        public AticulosViewmodel() {
            this.repo = new RepositoryArticulos();
            Task.Run(async () => {
                await CargarArticulos();
            });
        }
        private async Task CargarArticulos()
        {
            Articulos = new ObservableCollection<Articulos>(await repo.GetArticulos());
        }
        private void cargarArticulos()
        {
            this.repo.GetArticulos();
        }
        private ObservableCollection<Articulos> _Articulos;
        public ObservableCollection<Articulos> Articulos
        {
            get { return _Articulos; }
            set { this._Articulos = value; OnPropertyChanged("Articulos"); }
        }

    }
}
