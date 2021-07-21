using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Category;
using NightClub.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoryResultDto>>(categories));
        }
    }
}
