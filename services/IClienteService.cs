using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IClienteService
    {
        Task<ResultSet<ClienteModel>> get ();
        Task<ResultSet<ClienteModel>> getId (int id);
        Task<ResultSet<ClienteModel>> post (ClienteModel cliente);
        Task<ResultSet<ClienteModel>> put (ClienteModel cliente);
        Task<ResultSet<ClienteModel>> delete (int id);
    }
}