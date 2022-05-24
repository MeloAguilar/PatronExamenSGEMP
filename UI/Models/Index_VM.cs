using BL.Listas;
using DAL.Listas;
using Entities;

namespace UI.Models
{
    public class Index_VM
    {
        clsListasBL bl = new clsListasBL();  
        public List<clsPlantaConPrecioNuevo> Plantas { get; set; }

   


        public Index_VM()
        {
            List<clsPlanta> plantas  = bl.RecogerListadoCompletoPlantasBL();
            Plantas = new List<clsPlantaConPrecioNuevo>();
            foreach(var item in plantas)
            {
                clsPlantaConPrecioNuevo planta = new clsPlantaConPrecioNuevo();
                planta.IdCategoria = item.IdCategoria;
                planta.IdPlanta = item.IdPlanta;
                planta.NombrePlanta = item.NombrePlanta;
                planta.Precio = item.Precio;
                planta.PrecioNuevo = 0;
                Plantas.Add(planta);
            }
        }
    }
}
