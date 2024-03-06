using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class ArticuloModel
    {
        [Key]
        public int Articulo { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Codigo { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Precio { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Imagen { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Stock { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Tienda { get; set; }
    }
}