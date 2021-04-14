using ArsAfiliados.Dtos;
using ArsAfiliados.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAfiliados.Controllers
{
    public class PlanesController : Controller
    {

        public async Task<IActionResult> Mostrar(bool Errorinactivar = false)
        {
            ViewBag.Errorinactivar = Errorinactivar;

            return View(await RepositoryPlanes.GetInstance().Mostrar());
        }


        [HttpPost]
        public async Task<IActionResult> Mostrar(string buscar) =>
            View(new List<MostrarPlanesDto> { await RepositoryPlanes.GetInstance().Buscar(buscar) });


        public async Task<IActionResult> Crear()
        {
            ViewBag.planes = await RepositoryPlanes.GetInstance().Mostrar();

            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Crear(CrearPlanesDto afiliadosDto)
        {
            if (await RepositoryPlanes.GetInstance().Crear(afiliadosDto))
                return RedirectToAction("Mostrar");

            return View(afiliadosDto);
        }


        public async Task<IActionResult> Actualizar(string id)
        {
            ViewBag.planes = await RepositoryPlanes.GetInstance().Mostrar();

            return View(await RepositoryPlanes.GetInstance().Buscar(id));
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Actualizar(ActualizarPlanesDto PlanesDto, int id)
        {
            PlanesDto.Id = id;

            if (await RepositoryPlanes.GetInstance().Actualizar(PlanesDto))
                return RedirectToAction("Mostrar");

            return View(PlanesDto);
        }



        public async Task<IActionResult> Inactivar(string id, int inactivar)
        {
            if (await RepositoryPlanes.GetInstance().Inactivar(id, inactivar))
                return RedirectToAction("Mostrar");

            return RedirectToAction("Mostrar", new { Errorinactivar = true });
        }

    }
}
