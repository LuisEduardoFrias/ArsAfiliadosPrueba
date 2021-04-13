using ArsAfiliados.Dtos;
using ArsAfiliados.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAfiliados.Controllers
{
    public class AfiliadosController : Controller
    {

        public async Task<IActionResult> Mostrar(bool NoDelete = false)
        {
            ViewBag.NoDelete = NoDelete;

            return View(await RepositoryAfiliados.GetInstance().Mostrar());
        }


        [HttpPost]
        public async Task<IActionResult> Mostrar(string buscar) =>
            View(new List<MostrarAfiliadosDto> { await RepositoryAfiliados.GetInstance().Buscar(buscar) });
            


        public async Task<IActionResult> Crear()
        {
            ViewBag.planes = await RepositoryPlanes.GetInstance().Mostrar();

            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Crear(CrearAfiliadosDto afiliadosDto)
        {
            if (await RepositoryAfiliados.GetInstance().Crear(afiliadosDto))
                return RedirectToAction("Mostrar");

           return View(afiliadosDto);
        }


        public async Task<IActionResult> Actualizar(string cedula)
        {
            ViewBag.planes = await RepositoryPlanes.GetInstance().Mostrar();

            return View(await RepositoryAfiliados.GetInstance().Buscar(cedula));
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Actualizar(ActualizarAfiliadoDto afiliadosDto)
        {
            if (await RepositoryAfiliados.GetInstance().Actualizar(afiliadosDto))
                return RedirectToAction("Mostrar");

            return View(afiliadosDto);
        }

        
        public async Task<IActionResult> MontoConsumido()
        {
            ViewBag.cedulas = await OctenerListadoCedulaAfiliado();

            return View(new ActualizarMontoAfiliadoDto());
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> MontoConsumidoBuscar(string cedula) 
        {
            ViewBag.cedulas = await OctenerListadoCedulaAfiliado();

            var afiliado = await RepositoryAfiliados.GetInstance().Buscar(cedula);

            return View("MontoConsumido", new ActualizarMontoAfiliadoDto { Cedula = afiliado.Cedula, MontoConsumido = afiliado.MontoConsumido });
        }

        private async Task<List<string>> OctenerListadoCedulaAfiliado()
        {
            List<string> cedulas = new List<string>();

            cedulas.AddRange((await RepositoryAfiliados.GetInstance().Mostrar()).Select(x => x.Cedula).ToList());

            return cedulas;
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> MontoConsumido(ActualizarMontoAfiliadoDto afiliadosDto)
        {
           if (await RepositoryAfiliados.GetInstance().Actualizar( await ActualizandoMontoAfiliado(afiliadosDto) ))
               return RedirectToAction("Mostrar");

            return View(afiliadosDto);
        }

        private async Task<ActualizarAfiliadoDto> ActualizandoMontoAfiliado(ActualizarMontoAfiliadoDto afiliadosDto)
        {
            var afiliado = await RepositoryAfiliados.GetInstance().Buscar(afiliadosDto.Cedula);

            afiliado.MontoConsumido += afiliadosDto.NuevoMonto;

            return afiliado;
        }

        public async Task<IActionResult> Inactivar(string cedula, int inactivar)
        {
            if (await RepositoryAfiliados.GetInstance().Inactivar(cedula, inactivar))
                return RedirectToAction("Mostrar");

            return RedirectToAction("Mostrar", new { NoDelete = true});
        }

    }
}
