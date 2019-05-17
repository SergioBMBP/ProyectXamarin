using ProyectXamarin.Base;
using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.ViewModels
{
    public class UsuarioViewModel:ViewModelBase
    {

        private Usuarios _Usuario;
        public Usuarios Usuario
        {
            get { return _Usuario; }
            set { this._Usuario = value; OnPropertyChanged("Usuario"); }
        }
    }
}
