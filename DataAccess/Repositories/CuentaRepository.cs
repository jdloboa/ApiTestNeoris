using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly ApiTestDbContext _context;
        public CuentaRepository(ApiTestDbContext context)
        {
            _context = context;
        }
        public async Task<Cuenta> add(Cuenta cuenta)
        {
            await _context.Set<Cuenta>().AddAsync(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }
        public async Task delete(int cuentaId)
        {
            var cuenta = await _context.Set<Cuenta>().SingleOrDefaultAsync(p => p.cuentaId == cuentaId);
            if (cuenta != null)
            {
                _context.Set<Cuenta>().Attach(cuenta);
                _context.Entry(cuenta).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Cuenta> getById(int cuentaId)
        {
            return  await _context.Cuenta.Where(x => x.cuentaId == cuentaId).Include(x=>x.cliente).FirstOrDefaultAsync();
        }
        public async Task<List<Cuenta>> listAsync()
        {
            return await _context.Set<Cuenta>().Include(x=>x.cliente).ToListAsync();
        }

        public async Task<Cuenta> update(Cuenta cuenta)
        {
            _context.Set<Cuenta>().Attach(cuenta);
            _context.Set<Cuenta>().Include(x => x.cliente);
            _context.Entry(cuenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cuenta;
        }
    }
}
