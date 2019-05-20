using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectXamarin.ViewModels
{
    public class UsuarioViewModel: ViewModelBase
    {
        StorageSession session;
        ApiConnect connect;
        RepositoryUsuarios repo;
        public UsuarioViewModel()
        {
            this.Usuario = new Usuarios();
            this.repo = new RepositoryUsuarios();
            this.session = new StorageSession();
            this.connect = new ApiConnect();
             
        }

        private Usuarios _Usuario;
        public Usuarios Usuario
        {
            get { return _Usuario; }
            set { this._Usuario = value; OnPropertyChanged("Usuario"); }
        }

        public Command Login
        {
            get
            {
                return new Command(async () =>
                {
                    var token = await this.connect.GetToken(this.Usuario.Nombre, this.Usuario.Password);

                    if(token != null)
                    {
                        Usuarios user = await this.repo.GetUsuario(this.Usuario.Nombre, this.Usuario.Password);

                        await this.session.StorageUser(user, token);

                        Usuarios userStoraged = await this.session.GetStorageUser();
                        String t = await this.session.GetStorageToken();
                        var flag0 = 0;
                    }

                });
            }
        }
            
    }
}
