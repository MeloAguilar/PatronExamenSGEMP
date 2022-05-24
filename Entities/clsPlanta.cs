using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class clsPlanta
    {

        public int IdPlanta { get; set; }

        public string NombrePlanta { get; set; }

        public string Descripcion { get; set; }

        public int IdCategoria { get; set; }

        public double Precio { get; set; }


        public clsPlanta() { }




        public clsPlanta(int idPlanta, string nombreP, string descripcion, int idcategoria, double precio) 
        {
            this.Descripcion = descripcion; 
            this.IdPlanta = idPlanta;   
            this.Precio = precio;
            this.IdCategoria = idcategoria;
            this.NombrePlanta = nombreP;
        }

        public clsPlanta(int idPlanta, string nombreP, string descripcion, int idcategoria)
        {
            this.Descripcion = descripcion;
            this.IdPlanta = idPlanta;
            this.IdCategoria = idcategoria;
            this.NombrePlanta = nombreP;
        }
    }
}
