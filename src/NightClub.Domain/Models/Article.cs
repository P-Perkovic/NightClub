using System;

namespace NightClub.Domain.Models
{
    public class Article : Entity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishingDate { get; set; }

        public DateTime EventDate { get; set; }

        public string PhotoFilePath { get; set; }
    }
}
