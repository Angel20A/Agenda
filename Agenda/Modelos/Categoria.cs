using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre de categoría es obligatorio")]
        [StringLength(15, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} ", MinimumLength = 4)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Fecha de creación")]
        public DateTime? FechaCreacion { get; set; }
    }
}
