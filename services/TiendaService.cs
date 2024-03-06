using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly DataContext _context;

        public TiendaService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResultSet<TiendaModel>> delete(int id)
        {
            ResultSet<TiendaModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Tienda requerida!");

                TiendaModel tienda = await _context.Tienda.FindAsync(id);

                if (tienda is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Tienda inexistente!";
                }
                else
                {
                    _context.Tienda.Remove(tienda);
                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Tienda eliminada exitosamente!";
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

        public async Task<ResultSet<TiendaModel>> get()
        {
            ResultSet<TiendaModel> resultSet = new();

            try
            {
                resultSet.Data = await _context.Tienda.ToListAsync();

                if (resultSet.Data.Count > 0)
                {
                    resultSet.Notificaciones = "Tiendas obtenidas exitosamente!";
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                }
                else if (resultSet.Data.Count == 0)
                {
                    resultSet.Notificaciones = "No hay tiendas registradas!";
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
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

        public async Task<ResultSet<TiendaModel>> getId(int id)
        {
            ResultSet<TiendaModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Id requerido!");

                resultSet.ObjData = await _context.Tienda.FindAsync(id);

                if (resultSet.ObjData is null)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Tienda inexistente!";
                }
                else
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Tienda obtenida exitosamente!";
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

        public async Task<ResultSet<TiendaModel>> post(TiendaModel tienda)
        {
            ResultSet<TiendaModel> resultSet = new();

            try
            {
                if (string.IsNullOrEmpty(tienda.Sucursal)) throw new Exception("Sucursal requerdia!");
                if (string.IsNullOrEmpty(tienda.Direccion)) throw new Exception("Direccion requerida!");

                _context.Tienda.Add(tienda);
                await _context.SaveChangesAsync();

                resultSet.CodigoEstatus = 200;
                resultSet.Estatus = "OK";
                resultSet.Notificaciones = "Tienda guardada exitosamente!";
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<TiendaModel>> put(TiendaModel tienda)
        {
            ResultSet<TiendaModel> resultSet = new();

            try
            {
                if (tienda.Tienda <= 0) throw new Exception("Tienda requerida!");
                if (string.IsNullOrEmpty(tienda.Sucursal)) throw new Exception("Sucursal requerida!");
                if (string.IsNullOrEmpty(tienda.Direccion)) throw new Exception("Direccion requerida!");

                TiendaModel tiendaExistente = await _context.Tienda.FindAsync(tienda.Tienda);

                if (tiendaExistente is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Tienda inexistente!";
                }
                else
                {
                    tienda.Sucursal = tienda.Sucursal;
                    tienda.Direccion = tienda.Direccion;

                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Tienda actualizada exitosamente!";
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