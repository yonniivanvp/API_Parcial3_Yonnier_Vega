using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Principal;

namespace API_Parcial3.DAL.Entities
{
    public class Hotel : AuditBase
    {

        [Display(Name = "Hotel")]
        [MaxLength(50, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [MaxLength(50, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string City { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        [Range(0, int.MaxValue)]
        public int? Phone { get; set; }

        [Display(Name = "Stars")]
        [Required(ErrorMessage = "¡The stars field is mandatory!")]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Display(Name = "Rooms")]
        //Relacion con Room
        public ICollection<Room>? Rooms { get; set; }
    }
}
