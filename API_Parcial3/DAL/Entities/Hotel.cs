using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Principal;

namespace API_Parcial3.DAL.Entities
{
    public class Hotel : AuditBase
    {

        [Display(Name = "Hotel")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo dirección es obligatorio!")]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo ciudad es obligatorio!")]
        public string City { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "¡El campo teléfono es obligatorio!")]
        [Range(0, int.MaxValue)]
        public int? Phone { get; set; }

        [Display(Name = "Estrellas")]
        [Required(ErrorMessage = "¡El campo estrellas es obligatorio!")]
        [Range(0, 5)]
        public int? Stars { get; set; }

        [Display(Name = "Habitaciones")]
        //Relacion con Room
        public ICollection<Room>? Rooms { get; set; }
    }
}
