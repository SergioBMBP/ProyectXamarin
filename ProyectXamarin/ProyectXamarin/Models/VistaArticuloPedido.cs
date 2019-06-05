using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public class VistaArticuloPedido
    {

     
        
     
        public int Id_Articulos { get; set; }
     
        public String Tipo { get; set; }
      
        public String Imagen { get; set; }
       
        public String Nombre { get; set; }
   
        public int Cantidad { get; set; }
     
        public int Precio { get; set; }
  
        public String Marca { get; set; }

        public String Descripcion { get; set; }

        public int Id_pedido { get; set; }


    }
}
