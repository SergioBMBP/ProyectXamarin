using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
