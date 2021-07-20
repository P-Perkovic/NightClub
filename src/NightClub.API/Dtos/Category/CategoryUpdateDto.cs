using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal MinBillValue { get; set; }

        [Required]
        public int MaxNumberOfGuests { get; set; }
    }
}
