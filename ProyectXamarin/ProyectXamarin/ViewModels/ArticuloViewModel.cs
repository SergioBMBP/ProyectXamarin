using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectXamarin.ViewModels
{
   public class ArticuloViewModel:ViewModelBase
    {
        IRepositoryArticulos repo;
        public ArticuloViewModel()
        {
            this.repo = new RepositoryArticulos();
            
        }

        private Articulos _Articulo;
        public Articulos Articulo
        {
            get { return _Articulo; }
            set { this._Articulo = value; this._ValorCantidad = this._Articulo.CantidadCesta; OnPropertyChanged("Articulo"); }
        }

        private int _ValorCantidad;
        public int ValorCantidad
        {
            get { return this._ValorCantidad; }
            set { this._ValorCantidad = value; OnPropertyChanged("ValorCantidad"); }
        }

       

        public Command AddToCesta
        {
            get {
                return new Command(() =>
                {
                    
                    if (App.Locator.SessionService.Cesta.Contains(this.Articulo))
                    {
                        int index = App.Locator.SessionService.Cesta.IndexOf(this.Articulo);
                        App.Locator.SessionService.Cesta[index].CantidadCesta = ValorCantidad;
                    } else
                    {
                        this.Articulo.CantidadCesta = ValorCantidad;
                        App.Locator.SessionService.Cesta.Add(this.Articulo);

                    }
                    MessagingCenter.Send<CestaViewModel>(App.Locator.CestaViewModel, "UPDATE");
                    App.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
