using DTO;
using DTO.Request;
using DTO.Response;
using Entities;

namespace Services
{
    public interface IClienteService
    {
        Task<Cliente> add(ClienteDto cliente);
        Task delete(int clienteId);
        Task<Cliente> update(int idCliente , ClienteDto cliente);
        Task<ClienteDto> getById(int clienteId);
        Task<List<ClienteDto>> listAsync();
        Task<bool> validCliente(ClienteDto cliente);
    }

    
}