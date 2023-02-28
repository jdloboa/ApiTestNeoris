using DTO.Request;
using DTO.Response;
using Entities;

namespace Services
{
    public interface IMovimientoService
    {
        Task<Movimiento> add(MovimientoDtoRequest movimiento);
        Task delete(int movimientoId);
        Task<Movimiento> update(int idMovimiento, MovimientoDtoRequest movimiento);
        Task<MovimientoDtoResponse> getById(int movimientoId);
        Task<List<MovimientoDtoResponse>> listAsync();
        Task<List<MovimientoDtoResponse>> generarReportePorClienteYFecha(int clienteId, DateTime fechaInicial, DateTime fechaFinal);

    }
}