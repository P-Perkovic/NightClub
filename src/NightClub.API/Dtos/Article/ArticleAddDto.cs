using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Article
{
    public class ArticleAddDto
    {
        [Required(ErrorMessage ="The field is required")]
        [StringLength(255, ErrorMessage ="The field max length is 255 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string PhotoURL { get; set; }
    }
}
