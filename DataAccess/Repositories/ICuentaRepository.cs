using Entities;

namespace DataAccess.Repositories
{
    public interface ICuentaRepository
    {
        Task<Cuenta> add(Cuenta cuenta);
        Task delete(int cuentaId);
        Task<Cuenta> update(Cuenta cuenta);
        Task<Cuenta> getById(int cuentaId);
        Task<List<Cuenta>> listAsync();

    }
}