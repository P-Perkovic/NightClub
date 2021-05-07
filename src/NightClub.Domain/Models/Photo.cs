using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class Photo : Entity
    {
        public string FilePath { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
