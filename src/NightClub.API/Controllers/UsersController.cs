using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.User;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : MainController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserAddDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<User>(userDto);

            var userResult = await _userService.Add(user);

            if (userResult == null) return BadRequest();

            return Ok(_mapper.Map<UserResultDto>(user));
        }
    }
}
