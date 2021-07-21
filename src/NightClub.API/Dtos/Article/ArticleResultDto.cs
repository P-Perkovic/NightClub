using System;

namespace NightClub.API.Dtos.Article
{
    public class ArticleResultDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishingDate { get; set; }

        public string PhotoFilePath { get; set; }
    }
}
