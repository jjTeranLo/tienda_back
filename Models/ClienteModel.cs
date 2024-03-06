using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class ClienteModel
    {
        [Key]
        public int Cliente { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nombres { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellidos { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }
    }
}