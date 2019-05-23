using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public Command barrabusqueda {
            get {
                return new Command(async(x)=> {
                    String buscar = x.ToString();
                    if (buscar=="All") {
                        this.Articulos = new ObservableCollection<Articulos>(await repo.GetArticulos());
                    } else {
                        this.Articulos = new ObservableCollection<Articulos>(await repo.GetArticulos(buscar));
                    }
                   
                });
            }
        }

        public Command MostrarDetallesArticulo
        {
            get
            {
                return new Command(async (articulo) =>
                {
                    DetallesArticulosView view = new DetallesArticulosView();
                    ArticuloViewModel viewmodel = new ArticuloViewModel();

                    viewmodel.Articulo = articulo as Articulos;
                    view.BindingContext = viewmodel;

                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                 
                });
            }
        }
    }
}
