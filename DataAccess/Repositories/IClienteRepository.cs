using DTO.Request;
using Entities;

namespace DataAccess.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> add(Cliente cliente);
        Task delete(int clienteId);
        Task<Cliente> update(Cliente cliente);
        Task<Cliente> getById(int clienteId);
        Task<List<Cliente>> listAsync();
    }
}