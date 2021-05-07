using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Photo
{
    public class PhotoResultDto
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public int ArticleId { get; set; }
    }
}
