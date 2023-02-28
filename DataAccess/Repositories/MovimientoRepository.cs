using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly ApiTestDbContext _context;
        public MovimientoRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task<Movimiento> add(Movimiento movimiento)
        {
            await _context.Set<Movimiento>().AddAsync(movimiento);
            await _context.SaveChangesAsync();
            return movimiento;
        }
        public async Task delete(int movimientoId)
        {
            var entity = await _context.Set<Movimiento>().SingleOrDefaultAsync(p => p.movimientoId == movimientoId);
            if (entity != null)
            {
                _context.Set<Movimiento>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movimiento> getById(int movimientoId)
        {
            return await _context.Set<Movimiento>().Where(x => x.movimientoId == movimientoId).Include(x => x.cuenta).ThenInclude(x=>x.cliente).SingleOrDefaultAsync();
        }

        public async Task<List<Movimiento>> listAsync()
        {
            return await _context.Set<Movimiento>().Include(x=>x.cuenta).ThenInclude(x=>x.cliente).ToListAsync();
        }


        public async Task<Movimiento> update(Movimiento movimiento)
        {
            _context.Set<Movimiento>().Attach(movimiento);
            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movimiento;
        }
        
        public async Task<List<Movimiento>> generarReportePorClienteYFecha(int clienteId , DateTime fechaInicial , DateTime fechaFinal)
        {
           
          return await _context.Movimiento.Where(x => x.cuenta.clienteId == clienteId && x.fecha.Date >= fechaInicial.Date && x.fecha.Date <= fechaFinal.Date).Include(x => x.cuenta).ThenInclude(x => x.cliente).ToListAsync();
        }
    }
}
