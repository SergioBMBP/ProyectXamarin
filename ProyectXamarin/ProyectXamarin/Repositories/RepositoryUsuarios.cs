using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public class RepositoryUsuarios: IRepositoryUsuarios
    {
        private ApiConnect connect;
        public RepositoryUsuarios()
        {
            this.connect = new ApiConnect();
        }

        public async Task<Usuarios> GetUsuario(String nombre, String password)
        {
            Usuarios usuario = await this.connect.CallApi<Usuarios>("api/GetUsuario/" + nombre + "/" + password, null);
            return usuario;
        }

    }
}
