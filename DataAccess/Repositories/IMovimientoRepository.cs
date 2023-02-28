using Entities;

namespace DataAccess.Repositories
{
    public interface IMovimientoRepository
    {
        Task<Movimiento> add(Movimiento movimiento);
        Task delete(int movimientoId);
        Task<Movimiento> update(Movimiento movimiento);
        Task<Movimiento> getById(int movimientoId);
        Task<List<Movimiento>> listAsync();
        Task<List<Movimiento>> generarReportePorClienteYFecha(int clienteId, DateTime fechaInicial, DateTime fechaFinal);
    }
}