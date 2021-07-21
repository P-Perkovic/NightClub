using NightClub.API.Dtos.Category;

namespace NightClub.API.Dtos.Table
{
    public class TableResultDto
    {
        public int Id { get; set; }

        public int OrdinalNumber { get; set; }

        public CategoryResultDto Category { get; set; }
    }
}
