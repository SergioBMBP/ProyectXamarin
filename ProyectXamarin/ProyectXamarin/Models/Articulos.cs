using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public class Articulos
    {
        public int Id_Articulos { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }
        public string Marca { get; set; }
        public int CantidadCesta { get; set; }
    }
}
