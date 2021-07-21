﻿using System.ComponentModel.DataAnnotations;

namespace NightClub.API.Dtos.Article
{
    public class ArticleEditDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(255, ErrorMessage = "The field max length is 255 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string PhotoFilePath { get; set; }

        public string PhotoURL { get; set; }
    }
}
