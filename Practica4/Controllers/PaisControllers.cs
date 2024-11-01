using Microsoft.AspNetCore.Mvc;
using Practica4.Interfaces;


namespace Practica4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesControlador : ControllerBase
    {
        private readonly IPaises _servicio;

        public PaisesControlador(IPaises servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarPaises")]
        public IActionResult ListarPaises()
        {
            return Ok(_servicio.ListarPaises());
        }

        [HttpGet("PaisesPorContinente")]
        public IActionResult ListarPaisesPorContinente(string continente)
        {
            var resultado = _servicio.ListarPaisesPorContinente(continente);
            return Ok(resultado);
        }

        [HttpGet("PaisesMayorPoblacion/{cantidad}")]
        public IActionResult ListarPaisesMayorPoblacion(int cantidad)
        {
            var resultado = _servicio.ListarPaisesMayorPoblacion(cantidad);
            return Ok(resultado);
        }


        [HttpGet("PrimerNombreApellido")]
        public IActionResult ObtenerPrimerNombreApellido(string nombreCompleto)
        {
            var resultado = _servicio.ObtenerPrimerNombreApellido(nombreCompleto);
            return Ok(resultado);
        }

    }
}
