using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public interface IArticulos
    {
        int Id_Articulos { get; set; }
        String Nombre { get; set; }
        int Cantidad { get; set; }
        int Precio { get; set; }
        String Tipo { get; set; }
        String Imagen { get; set; }
        String Marca { get; set; }
    }
}
