using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Services
{
    public class SessionService
    {
        public SessionService()
        {            
            this.Cesta = new List<Articulos>();
        }

        public List<Articulos> Cesta { get; set; }
        public String busquedaMarca { get; set; }
       
    }
}
