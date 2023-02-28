using DTO.Request;
using DTO.Response;
using Entities;

namespace Services
{
    public interface ICuentaService 
    {
        Task<Cuenta> add(CuentaDtoRequest cuenta);
        Task delete(int cuentaId);
        Task<Cuenta> update(int idCuenta, CuentaDtoRequest cuenta);
        Task<CuentaDtoResponse> getById(int cuentaId);
        Task<List<CuentaDtoResponse>> listAsync();
        Task<Cuenta> setSaldo(int cuentaId, double valor);
    }
}