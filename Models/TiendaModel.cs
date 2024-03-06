using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class TiendaModel
    {
        [Key]
        public int Tienda { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Sucursal { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Direccion { get; set; }
    }
}