using Microsoft.AspNetCore.Mvc;
using SiFac.BLL.Interfaces;
using SiFac.DAL.Entidades;

namespace SiFac.API.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClientesController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteServicio.ObtenerTodosAsync();
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _clienteServicio.CrearAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
