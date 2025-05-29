using Examen1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen1.UI.Controllers
{
    public class ApartamentoController : Controller
    {

        private readonly BL.IAdministradorDeApartamentos ElAdministrador;


        public ApartamentoController(BL.IAdministradorDeApartamentos administrador)
        {
            ElAdministrador = administrador;
        }


        // GET: ApartamentoController
        public ActionResult Index(string nombre)
        {
            List<Model.Apartamento> lista;


            lista = ElAdministrador.ObtenerListaDeApartamentos();

            if (nombre is null)
                return View(lista);
            else
            {
                List<Model.Apartamento> listaFiltrada;
                listaFiltrada = lista.Where(x => x.Nombre.Contains(nombre)).ToList();
                return View(listaFiltrada);
            }
        }

        // GET: ApartamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.Apartamento apartamento)
        {
            try
            {
                ElAdministrador.AgregueUnApartamento(apartamento);
                ViewData["Message"] = "Apartamento agregado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Message"] = "Error al agregar el apartamento. Verifique los datos ingresados.";
                return View();
            }
        }

        // GET: ApartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Model.Apartamento apartamento;
            apartamento = ElAdministrador.ObtenerApartamentoPorId(id);
            return View(apartamento);
        }

        // POST: ApartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.Apartamento apartamento)
        {
            try
            {
                ElAdministrador.EditeElApartamento(apartamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApartamentoController/Delete/5
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
    }
}
