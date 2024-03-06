using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
        }
    
        public async Task<ResultSet<ClienteModel>> delete(int id)
        {
           ResultSet<ClienteModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Cliente requerido!");

                ClienteModel cliente = await _context.Cliente.FindAsync(id);

                if (cliente is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Cliente inexistente!";
                }
                else
                {
                    _context.Cliente.Remove(cliente);
                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Cliente eliminado exitosamente!";
                }
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<ClienteModel>> get()
        {
            ResultSet<ClienteModel> resultSet = new();

            try
            {
                resultSet.Data = await _context.Cliente.ToListAsync();

                if (resultSet.Data.Count > 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Cliente obtenidos exitosamente!";
                }
                else if (resultSet.Data.Count == 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "No hay clientes registrados!";
                }
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<ClienteModel>> getId(int id)
        {
            ResultSet<ClienteModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Cliente requerido!");

                resultSet.ObjData = await _context.Cliente.FindAsync(id);

                if (resultSet is null)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Cliente inexistente!";
                }
                else
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Cliente obtenido exitosamente!";
                }
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<ClienteModel>> post(ClienteModel cliente)
        {
            ResultSet<ClienteModel> resultSet = new();

            try
            {
                if (string.IsNullOrEmpty(cliente.Nombres)) throw new Exception("Nombre requerido!");
                if (string.IsNullOrEmpty(cliente.Apellidos)) throw new Exception("Apellidos requeridos!");
                if (string.IsNullOrEmpty(cliente.Direccion)) throw new Exception("Dirección requeridos!");


                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                resultSet.CodigoEstatus = 200;
                resultSet.Estatus = "OK";
                resultSet.Notificaciones = "Cliente guardado exitosamente!";
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<ClienteModel>> put(ClienteModel cliente)
        {
            ResultSet<ClienteModel> resultSet = new();

            try
            {
                if (cliente.Cliente <= 0) throw new Exception("Cliente requerido!");
                if (string.IsNullOrEmpty(cliente.Nombres)) throw new Exception("Nombre requerido!");
                if (string.IsNullOrEmpty(cliente.Apellidos)) throw new Exception("Apellidos requeridos!");
                if (string.IsNullOrEmpty(cliente.Direccion)) throw new Exception("Dirección requeridos!");

                ClienteModel clienteExistente = await _context.Cliente.FindAsync(cliente.Cliente);

                if (clienteExistente is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Cliente inexistente!";
                }
                else
                {
                    clienteExistente.Nombres = cliente.Nombres;
                    clienteExistente.Apellidos = cliente.Apellidos;
                    clienteExistente.Direccion = cliente.Direccion;

                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Cliente actualizado exitosamente!";
                }
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }
    }
}