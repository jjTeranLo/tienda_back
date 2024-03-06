using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly DataContext _context;

        public ArticuloService(DataContext context)
        {
            _context = context;
        }
        public async Task<ResultSet<ArticuloModel>> delete(int id)
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Articulo requerido!");

                ArticuloModel articulo = await _context.Articulo.FindAsync(id);

                if (articulo is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Articulo inexistente!";
                }
                else
                {
                    _context.Articulo.Remove(articulo);
                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulo eliminado exitosamente!";
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

        public async Task<ResultSet<ArticuloModel>> get(int articulo)
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                resultSet.Data = await _context.Articulo.ToListAsync();

                if (resultSet.Data.Count > 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulos obtenidos exitosamente!";
                }
                else if (resultSet.Data.Count == 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "No hay articulos registrados!";
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

        public async Task<ResultSet<ArticuloModel>> getId(int id)
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                if (id <= 0) throw new Exception("Articulo requerido!");

                resultSet.ObjData = await _context.Articulo.FindAsync(id);

                if (resultSet is null)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulo inexistente!";
                }
                else
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulo obtenido exitosamente!";
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

        public async Task<ResultSet<ArticuloModel>> post(ArticuloModel articulo)
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                if (string.IsNullOrEmpty(articulo.Codigo)) throw new Exception("Codigo requerido!");
                if (string.IsNullOrEmpty(articulo.Descripcion)) throw new Exception("Descripcion requerida!");
                if (string.IsNullOrEmpty(articulo.Precio)) throw new Exception("Precio requerido!");
                if (articulo.Stock <= 0) throw new Exception("Stock requerido!");
                if (articulo.Tienda <= 0) throw new Exception("Tienda requerida");

                _context.Articulo.Add(articulo);
                await _context.SaveChangesAsync();

                resultSet.CodigoEstatus = 200;
                resultSet.Estatus = "OK";
                resultSet.Notificaciones = "Articulo guardado exitosamente!";
            }
            catch (Exception ex)
            {
                resultSet.CodigoEstatus = 400;
                resultSet.Estatus = "ERR";
                resultSet.Notificaciones = ex.Message;
            }

            return resultSet;
        }

        public async Task<ResultSet<ArticuloModel>> put(ArticuloModel articulo)
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                if (articulo.Articulo <= 0) throw new Exception("Articulo requerido!");
                if (string.IsNullOrEmpty(articulo.Codigo)) throw new Exception("Codigo requerido!");
                if (string.IsNullOrEmpty(articulo.Descripcion)) throw new Exception("Descripcion requerida!");
                if (string.IsNullOrEmpty(articulo.Precio)) throw new Exception("Precio requerido!");
                if (articulo.Stock <= 0) throw new Exception("Stock requerido!");
                if (articulo.Tienda <= 0) throw new Exception("Tienda requerida");

                ArticuloModel articuloExistente = await _context.Articulo.FindAsync(articulo.Articulo);

                if (articulo is null)
                {
                    resultSet.CodigoEstatus = 400;
                    resultSet.Estatus = "ERR";
                    resultSet.Notificaciones = "Articulo inexistente!";
                }
                else
                {
                    articuloExistente.Codigo = articulo.Codigo;
                    articuloExistente.Descripcion = articulo.Descripcion;
                    articuloExistente.Precio = articulo.Precio;
                    articuloExistente.Imagen = articulo.Imagen;
                    articuloExistente.Stock = articulo.Stock;
                    articuloExistente.Tienda = articulo.Tienda;

                    await _context.SaveChangesAsync();

                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulo actualizado exitosamente!";
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

        public async Task<ResultSet<ArticuloModel>> getArticulos()
        {
            ResultSet<ArticuloModel> resultSet = new();

            try
            {
                resultSet.Data = await _context.Articulo.ToListAsync();

                if (resultSet.Data.Count > 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "Articulos obtenidos exitosamente!";
                }
                else if (resultSet.Data.Count == 0)
                {
                    resultSet.CodigoEstatus = 200;
                    resultSet.Estatus = "OK";
                    resultSet.Notificaciones = "No hay articulos registrados!";
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