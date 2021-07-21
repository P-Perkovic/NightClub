using System.ComponentModel.DataAnnotations;

namespace NightClub.API.Dtos.Admin
{
    public class AdminConfigUpdateDto
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
