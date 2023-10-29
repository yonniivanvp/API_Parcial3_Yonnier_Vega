using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace API_Parcial3.DAL.Entities
{
    public class Room : AuditBase
    {
        [Display(Name = "Room number")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        [Display(Name = "Max Guests")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        [Range(101, int.MaxValue)]
        public int MaxGuests { get; set; }

        [Display(Name = "Availability")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public bool Availability { get; set; }

        [Display(Name = "Hotel")]
        //Relacion con Hotel
        public Hotel? Hotel { get; set; } //Este representa un objeto de hotel

        [Display(Name = "Id Hotel")]
        public Guid HotelId { get; set; }//FK
    }
}
