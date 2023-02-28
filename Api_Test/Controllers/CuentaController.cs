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
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _service;
        public CuentaController(ICuentaService service)
        {
            _service = service;
        }
        // GET: api/<CuentaController>
        [HttpGet]
        [Route("getById")]

        public async Task<ActionResult<CuentaDtoResponse>> get(int cuentaId)
        {
            try
            {
                var cuenta = await _service.getById(cuentaId);
                if (cuenta == null)
                {
                    return NotFound("Cuenta no existente");
                }
                return Ok(cuenta);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);            
            }   
        }
        [HttpGet]
        [Route("getAll")]

        public async Task<ActionResult<List<CuentaDtoResponse>>> listaCuentas()
        {
            try
            {
                var cuentas = await _service.listAsync();
                if (cuentas == null)
                {
                    return NotFound("No existen cuentas");
                }
                return Ok(cuentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("post")]

        public async Task<ActionResult<CuentaDtoResponse>> post(CuentaDtoRequest cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var cuentas = await _service.listAsync();
                if(cuentas.Any(x=>x.numeroCuenta == cuenta.numeroCuenta))
                {
                    return NotFound("La cuenta ya existe");
                }
                var response = await _service.add(cuenta);
                return Created($"/{response}", new
                {
                    id = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut]
        [Route("put")]

        public async Task<IActionResult> Put(int cuentaId, CuentaDtoRequest cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _service.update(cuentaId, cuenta);
                return Accepted(new
                {
                    id = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<CuentaController>/5
        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete(int cuentaId)
        {
            try
            {  
                if (_service.getById(cuentaId) == null)
                {
                    throw new Exception("la cuenta no existe");
                }
                await _service.delete(cuentaId);
                return Accepted(new
                {
                    id = cuentaId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
