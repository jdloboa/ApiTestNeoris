using AutoMapper;
using DTO.Request;
using DTO.Response;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        private readonly ICuentaService _cuentaService;

        public MovimientoController(IMovimientoService movimientoService, ICuentaService cuentaService)
        {
            _movimientoService = movimientoService;
            _cuentaService = cuentaService;

        }
        // GET: api/<MovimientoController>
        [HttpGet]
        [Route("getById")]

        public async Task<ActionResult<Movimiento>> get(int movimientoId)
        {
            try
            {
                var movimiento = await _movimientoService.getById(movimientoId);
                if (movimiento == null)
                {
                    return NotFound("Movimiento no existente");
                }
                return Ok(movimiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getAll")]

        public async Task<ActionResult<List<MovimientoDtoResponse>>> listaMovimientos()
        {
            try
            {
                var movimientos = await _movimientoService.listAsync();
                if (movimientos == null)
                {
                    return NotFound("No existen movimientos");
                }
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("post")]

        public async Task<ActionResult<Movimiento>> post(MovimientoDtoRequest movimiento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _movimientoService.add(movimiento);
                await _cuentaService.setSaldo(movimiento.cuentaID, movimiento.valor);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("put")]

        public async Task<IActionResult> Put(int movimientoId, MovimientoDtoRequest movimiento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updateMovimiento = await _movimientoService.update(movimientoId, movimiento);
                var updateCuenta = await _cuentaService.setSaldo(movimiento.cuentaID, movimiento.valor);
                return Accepted(new
                {
                    id = updateMovimiento
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete(int movimientoId)
        {
            try
            {
                if (_movimientoService.getById(movimientoId) == null)
                {
                    throw new Exception("El movimiento no existe");
                }
                await _movimientoService.delete(movimientoId);
                return Accepted(new
                {
                    id = movimientoId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
