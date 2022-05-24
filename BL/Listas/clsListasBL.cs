using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listas
{
    public class clsListasBL
    {
        clsListasPlantas dal = new clsListasPlantas();

        public List<clsPlanta> RecogerListadoCompletoPlantasBL()
        {
            return dal.RecogerListadoCompletoPlantas();
        }

    }
}
