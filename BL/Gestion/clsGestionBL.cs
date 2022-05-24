using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gestion
{
    public class clsGestionBL
    {
        clsGestionPlantas dal = new clsGestionPlantas();

        public int EditarPrecioPlantaBL(clsPlanta p)
        {
            return dal.EditarPrecioPlanta(p);
        }
    }
}
