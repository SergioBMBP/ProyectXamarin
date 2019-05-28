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
            set { this._Articulo = value; OnPropertyChanged("Articulo"); }
        }

        private int _CantidadCesta = 1;

        public int CantidadCesta
        {
            get { return this._CantidadCesta; }
            set { this._CantidadCesta = value; OnPropertyChanged("CantidadCesta"); }
        }

        public Command AddToCesta
        {
            get {
                return new Command(() =>
                {
                    
                    if (App.Locator.SessionService.Cesta.Contains(this.Articulo))
                    {
                        int index = App.Locator.SessionService.Cesta.IndexOf(this.Articulo);
                        App.Locator.SessionService.Cesta[index].CantidadCesta = CantidadCesta;
                    } else
                    {
                        this.Articulo.CantidadCesta = CantidadCesta;
                        App.Locator.SessionService.Cesta.Add(this.Articulo);
                    }
                    
                });
            }
        }
    }
}
