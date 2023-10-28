using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace API_Parcial3.DAL.Entities
{
    public class Room : AuditBase
    {
        [Display(Name = "Número de Habitacion")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        [Display(Name = "Máx. huéspedes")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        [Range(1, int.MaxValue)]
        public int MaxGuests { get; set; }

        [Display(Name = "Disponibilidad")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public bool Availability { get; set; }

        [Display(Name = "Hotel")]
        //Relacion con Hotel
        public Hotel? Hotel { get; set; } //Este representa un objeto de hotel

        [Display(Name = "Id Hotel")]
        public Guid HotelId { get; set; }//FK
    }
}
