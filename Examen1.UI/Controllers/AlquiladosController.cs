using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen1.UI.Controllers
{
    public class AlquiladosController : Controller
    {

        private readonly BL.IAdministradorDeApartamentos ElAdministrador;


        public AlquiladosController(BL.IAdministradorDeApartamentos administrador)
        {
            ElAdministrador = administrador;
        }



        // GET: AlquiladosController
        public ActionResult Index(string NombreInquilino)
        {
            List<Model.Apartamento> lista;


            lista = ElAdministrador.ObtenerListaApartamentosAlquilados();

            if (NombreInquilino is null)
                return View(lista);
            else
            {
                List<Model.Apartamento> listaFiltrada;
                listaFiltrada = lista.Where(x => x.Nombre.Contains(NombreInquilino)).ToList();
                return View(listaFiltrada);
            }
        }

        // GET: AlquiladosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlquiladosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlquiladosController/Create
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

        // GET: AlquiladosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlquiladosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AlquiladosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlquiladosController/Delete/5
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
