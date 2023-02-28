using AutoMapper;
using Azure.Core;
using DTO.Request;
using DTO.Response;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("getById")]
        public async Task<ActionResult<ClienteDto>> get(int clienteId)
        {
            try
            {
                var cliente = await _service.getById(clienteId);
                if (cliente == null)
                {
                    return NotFound("Cliente no existente");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<ActionResult<List<Cliente>>> listaClientes()
        {
            try
            {
                var clientes = await _service.listAsync();
                if (clientes == null)
                {
                    return NotFound("No existen clientes");
                }
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("post")]

        public async Task<ActionResult<ClienteDto>> post(ClienteDto cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var validCliente =  _service.validCliente(cliente);
                if (!await validCliente)
                {
                    return BadRequest("El cliente ya existe");
                }
                var response = await _service.add(cliente);
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

        [HttpPut]
        [Route("put")]

        public async Task<IActionResult> put(int clienteId, ClienteDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }                
                var response = await _service.update(clienteId, request);
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
        [HttpDelete]
        [Route("deleteById")]

        public async Task<IActionResult> delete(int clienteId)
        {
            try
            {
                if (_service.getById(clienteId) == null)
                {
                    throw new Exception("el cliente no existe");
                }
                await _service.delete(clienteId);
                return Accepted(new
                {
                    id = clienteId
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
