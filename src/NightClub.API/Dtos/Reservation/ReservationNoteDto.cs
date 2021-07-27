using System.ComponentModel.DataAnnotations;

namespace NightClub.API.Dtos.Reservation
{
    public class ReservationNoteDto
    {
        [Required]
        public string Note { get; set; }
    }
}
