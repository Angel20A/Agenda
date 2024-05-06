using System.ComponentModel.DataAnnotations;

namespace Agenda.Modelos
{
    public class Contacto
    {
        [Key]
        public int id {  get; set; }

        [Required (ErrorMessage = "El nombre de contacto es obligatorio")]
        [StringLength (15, ErrorMessage = "{0} El nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El E-Mail del contacto es obligatorio")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage ="Solo se admiten números")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de creación")]
        public DateTime? FechaCreacion { get; set; }


        [Required] //Crear relación del contacto con el ID de Categoría
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
