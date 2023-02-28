using AutoMapper;
using DTO.Response;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private readonly IMovimientoService _service;
        public ReporteController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<MovimientoDtoResponse>>> Get(int idCliente, DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                if(fechaInicial>fechaFinal)
                {
                    return BadRequest("Fecha inicial no puede ser mayor a fecha final");
                }
                var movimientos = await _service.generarReportePorClienteYFecha(idCliente, fechaInicial, fechaFinal);
                if (movimientos == null)
                {
                    return NotFound("No existen movimientos en esas fechas");
                }
                return Ok(movimientos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}
