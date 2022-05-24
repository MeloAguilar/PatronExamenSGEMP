using Entities;

namespace UI.Models
{
    public class clsPlantaConPrecioNuevo : clsPlanta
    {
        public double PrecioNuevo { get; set; }

        public clsPlantaConPrecioNuevo()
        {

        }
        public clsPlantaConPrecioNuevo(int idPlanta, string nombreP, string descripcion, int idcategoria)
        {
            this.Descripcion = descripcion;
            this.IdPlanta = idPlanta;
            this.IdCategoria = idcategoria;
            this.NombrePlanta = nombreP;
        }
        public clsPlantaConPrecioNuevo(int idPlanta, string nombreP, string descripcion, int idcategoria, double precio, double precioNuevo)
        {
            this.Descripcion = descripcion;
            this.IdPlanta = idPlanta;
            this.IdCategoria = idcategoria;
            this.NombrePlanta = nombreP;
        }
    }
}
