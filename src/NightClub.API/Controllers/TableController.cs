using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Table;
using NightClub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITableService _tableService;

        public TableController(IMapper mapper, ITableService tableService)
        {
            _mapper = mapper;
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await _tableService.GetAll();

            return Ok(_mapper.Map<IEnumerable<TableResultDto>>(tables));
        }
    }
}
