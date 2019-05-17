using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public interface IRepositoryArticulos
    {
        Task<List<Articulos>> GetArticulos();
        Task<Articulos> GetArticulo(int id);
    }
}
