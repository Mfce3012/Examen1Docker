using Examen1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen1.UI.Controllers
{
    public class DisponiblesController : Controller
    {
        private readonly BL.IAdministradorDeApartamentos ElAdministrador;

        public DisponiblesController(BL.IAdministradorDeApartamentos administradorDeApartamentos)
        {
            ElAdministrador = administradorDeApartamentos;
        }

        

        // GET: DisponiblesController
        public ActionResult Index(string nombre)
        {
            List<Model.Apartamento> lista;


            lista = ElAdministrador.ObtenerListaDeApartamentosDisponibles();

            if (nombre is null)
                return View(lista);
            else
            {
                List<Model.Apartamento> listaFiltrada;
                listaFiltrada = lista.Where(x => x.Nombre.Contains(nombre)).ToList();
                return View(listaFiltrada);
            }
        }

        // GET: DisponiblesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisponiblesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisponiblesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponiblesController/Edit/5
        public ActionResult Edit(int id)
        {
            var apartamento = ElAdministrador.ObtenerApartamentoPorId(id);
            if (apartamento == null)
                return NotFound();

            return View(apartamento);
        }

        // POST: DisponiblesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Examen1.Model.Apartamento apartamento)
        {

            var fechaFinal = apartamento.FechaFinalAlquiler;
            try
            {
                ElAdministrador.Alquile(
                    id,
                    apartamento.IdentificacionInquilino,
                    apartamento.NombreInquilino,
                    apartamento.FechaInicioAlquiler,
                    apartamento.CantidadDeMesesAlquiler
                );
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(apartamento);
            }
        }

        // GET: DisponiblesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisponiblesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        


    }//fin clase
}
