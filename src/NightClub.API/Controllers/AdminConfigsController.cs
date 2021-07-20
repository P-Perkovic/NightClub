using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NightClub.API.Dtos.Admin;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    [Route("api/[controller]")]
    public class AdminConfigsController : MainController
    {
        private readonly IAdminConfigService _adminConfigService;
        private readonly IMapper _mapper;

        public AdminConfigsController(IAdminConfigService adminConfigService, IMapper mapper)
        {
            _adminConfigService = adminConfigService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adminConfigs = await _adminConfigService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AdminConfigResultDto>>(adminConfigs));
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            var adminConfig = await _adminConfigService.GetByKey(key);

            if (adminConfig == null) return NotFound();

            return Ok(_mapper.Map<AdminConfigResultDto>(adminConfig));
        }

        [HttpPut("{key}")]
        public async Task<IActionResult> Update(string key,[FromBody] AdminConfigUpdateDto adminConfigUpdateDto)
        {
            if (key != adminConfigUpdateDto.Key) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var adminConfig = _mapper.Map<AdminConfig>(adminConfigUpdateDto);

            var adminConfigResult = await _adminConfigService.Update(adminConfig);

            if (adminConfigResult == null) return BadRequest();

            return Ok(_mapper.Map<AdminConfigResultDto>(adminConfigResult));
        }
    }
}
