using DataAccess.Repositories;
using DTO.Request;
using DTO.Response;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> add(ClienteDto cliente)
        {
            return await _repository.add(new Cliente
            {
                personaId = cliente.identificacion,
                contrasena = cliente.contrasena,
                estado = cliente.estado,
                nombre = cliente.nombre,
                genero = cliente.genero,
                edad = cliente.edad,
                direccion = cliente.direccion,
                telefono = cliente.telefono
            });

        }


        public async Task delete(int id)
        {
            await _repository.delete(id);
        }

        public async Task<ClienteDto> getById(int id)
        {
            var cliente = await _repository.getById(id);
            if (cliente == null)
                return null;
            return new ClienteDto
            {
                clienteId = cliente.clienteId,
                identificacion = cliente.personaId,
                contrasena = cliente.contrasena,
                estado = cliente.estado,
                nombre = cliente.nombre,
                genero = cliente.genero,
                edad = cliente.edad,
                direccion = cliente.direccion,
                telefono = cliente.telefono
            };
        }

        public  async Task<List<ClienteDto>> listAsync()
        {
            var collection = await _repository.listAsync();

            return collection.Select(cliente => new ClienteDto
            {
                clienteId = cliente.clienteId,
                identificacion = cliente.personaId,
                contrasena = cliente.contrasena,
                estado = cliente.estado,
                nombre = cliente.nombre,
                genero = cliente.genero,
                edad = cliente.edad,
                direccion = cliente.direccion,
                telefono = cliente.telefono
            })
             .ToList();
        }

        public async Task<Cliente> update(int clienteId, ClienteDto cliente)
        {
            return await _repository.update(new Cliente
            {
                clienteId = cliente.clienteId,
                personaId = cliente.identificacion,
                contrasena = cliente.contrasena,
                estado = cliente.estado,
                nombre = cliente.nombre,
                genero = cliente.genero,
                edad = cliente.edad,
                direccion = cliente.direccion,
                telefono = cliente.telefono,
            });
        }
        public async Task<bool> validCliente(ClienteDto cliente)
        {
            var clientes = await _repository.listAsync();
            if(clientes.Any(x => x.personaId == cliente.identificacion))
            {
                return false;
            }
            return true;
        }
    }
}