using BL.Gestion;
using BL.Listas;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly clsGestionBL gestionBL = new clsGestionBL();
        private readonly clsListasBL listasBL = new clsListasBL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Index_VM vm = null;
            var result = View();
            try
            {
                vm = new Index_VM();
                result = View(vm);
            }
            catch (Exception e)
            {
                ViewBag.TipoError = "Problemas al acceder a la base de datos";
                result = View("Error");
            }
            
            return result;
        }

        [HttpPost]  
        public IActionResult Index(Index_VM vm)
        {
            var result = View(vm);
            var filasAfectadas = 0;
            try { 
            foreach(var item in vm.Plantas)
            {
                if(!(item.Precio == item.PrecioNuevo) && !(item.PrecioNuevo == 0))
                {
                    clsPlanta p = new clsPlanta();
                    p.Precio = item.PrecioNuevo;
                    p.IdPlanta = item.IdPlanta;
                    filasAfectadas += gestionBL.EditarPrecioPlantaBL(p);
                }
            }
            }
            catch (Exception e)
            {
                ViewBag.TipoError = "Problemas Accediendo a la Base de Datos";
                ViewBag.InfoError = "La base de datos no es accesible en este momento, por favor intentelo de nuevo más tarde" ;
                result = View("Error");
            }
            finally
            {
                if(filasAfectadas == 0)
                {
                    ViewBag.TipoError = "Problemas Estableciendo el precio de tus plantas";
                    ViewBag.InfoError = "El precio de la planta es el mismo que antes o igual a 0";
                    result = View("Error");
                }
                else
                {
                    ViewBag.Info = $"Se establecio el precio con éxito para { filasAfectadas } Plantas";
                    result = View(new Index_VM());

                }
            }

            return result;
        }


    }
}