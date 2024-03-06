using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=tienda;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<TiendaModel> Tienda { get; set; }
        public DbSet<ArticuloModel> Articulo { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
    }
}