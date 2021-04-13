using ArsAfiliados.Dtos;
using ArsAfiliados.Repository;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<IActionResult> Crear()
        {
            //pruevas
            var f = await RepositoryPlanes.GetInstance().Crear(new CrearPlanesDto
            {
                Plan = "MAX",
                MontoCobertura = 10000M,
                FechaRegistro = new System.DateTime(2021, 04, 12),
                Estatus = true
            });


            var j = await RepositoryAfiliados.GetInstance().Crear(new CrearAfiliadosDto
            {
                Nombre = "Luis Eduardo",
                Apellido = "Frias",
                Cedula = "38493829309",
                Fecha = new System.DateTime(1994, 11, 27),
                Nacimiento = "?",
                Sexo = 'M',
                NumeroSeguroSocial = "8482936325926",
                FechaRegistro = new System.DateTime(2021, 04, 12),
                MontoConsumido = 0.00M,
                EstatusId = 1,
                PlanId = 1
            });

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

        public async Task<IActionResult> Actualizar(CrearAfiliadosDto afiliadosDto)
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Actualizar(ActualizarAfiliadoDto afiliadosDto)
        {
            if (await RepositoryAfiliados.GetInstance().Actualizar(afiliadosDto))
                return RedirectToAction("Mostrar");

            return View(afiliadosDto);
        }


        public async Task<IActionResult> Inactivar(int id, int inactivar)
        {
            if (await RepositoryAfiliados.GetInstance().Inactivar(id,inactivar))
                return RedirectToAction("Mostrar");

            return RedirectToAction("Mostrar", new { NoDelete = true});
        }


    }
}
