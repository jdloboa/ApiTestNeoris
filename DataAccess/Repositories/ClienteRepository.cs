using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiTestDbContext _context;
        public ClienteRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> add(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task delete(int clienteId)
        {
            var cliente = await _context.Set<Cliente>().SingleOrDefaultAsync(p => p.clienteId == clienteId);
            if (cliente != null)
            {
                _context.Set<Cliente>().Attach(cliente);
                _context.Entry(cliente).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente> getById(int clienteId)
        {
            return await _context.Set<Cliente>().Where(x => x.clienteId == clienteId).SingleOrDefaultAsync();
        }

        public async Task<List<Cliente>> listAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }
        

        public async Task<Cliente>  update(Cliente cliente)
        {
            _context.Set<Cliente>().Attach(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        
    }
}
