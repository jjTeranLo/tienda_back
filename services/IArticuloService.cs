using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IArticuloService
    {
        Task<ResultSet<ArticuloModel>> getArticulos();
        Task<ResultSet<ArticuloModel>> get(int articulo);
        Task<ResultSet<ArticuloModel>> getId(int id);
        Task<ResultSet<ArticuloModel>> post(ArticuloModel articulo);
        Task<ResultSet<ArticuloModel>> put(ArticuloModel articulo);
        Task<ResultSet<ArticuloModel>> delete(int id);
    }
}