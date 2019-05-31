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
            //lo cargamos aqui los ultimos
            LastArticulos= new ObservableCollection<Articulos>(await repo.GetLastArticulos());
            //aqui por la marca canon
            ArticulosCanon = new ObservableCollection<Articulos>(await repo.GetArticulos("Canon"));
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
                    Articulos art = articulo as Articulos;

                    if (App.Locator.SessionService.Cesta.Contains(art))
                    {
                        int index = App.Locator.SessionService.Cesta.IndexOf(art);
                        viewmodel.Articulo = App.Locator.SessionService.Cesta[index];
                        viewmodel.ValorCantidad = App.Locator.SessionService.Cesta[index].CantidadCesta;
                    }
                    else
                    {
                        viewmodel.Articulo = articulo as Articulos;
                    }
                    
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                 
                });
            }
        }

        //ultimos Articulos añadidos
        private ObservableCollection<Articulos> _LastArticulos;
        public ObservableCollection<Articulos> LastArticulos
        {
            get { return _LastArticulos; }
            set { this._LastArticulos = value; OnPropertyChanged("LastArticulos"); }
        }
        private ObservableCollection<Articulos> _ArticulosCanon;
        public ObservableCollection<Articulos> ArticulosCanon
        {
            get { return _ArticulosCanon; }
            set { this._ArticulosCanon = value; OnPropertyChanged("ArticulosCanon"); }
        }
    }
}
