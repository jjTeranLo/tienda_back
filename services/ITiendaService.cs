using BackEnd.Models;

namespace BackEnd.Services
{
    public interface ITiendaService
    {
        Task<ResultSet<TiendaModel>> get();
        Task<ResultSet<TiendaModel>> getId(int id);
        Task<ResultSet<TiendaModel>> post(TiendaModel tienda);
        Task<ResultSet<TiendaModel>> put(TiendaModel tienda);
        Task<ResultSet<TiendaModel>> delete(int id);
    }
}