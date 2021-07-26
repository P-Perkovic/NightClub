using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Reservation;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using static NightClub.Domain.Constants;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IUserService userService, IMapper mapper)
        {
            _reservationService = reservationService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{date:DateTime}")]
        public async Task<IActionResult> GetAllForDate(DateTime date)
        {
            date = date.AddMonths(-1);
            if (date == null) return BadRequest();

            var reservations = await _reservationService.GetAllForDate(date);

            if (reservations == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<ReservationResultDto>>(reservations));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForCurrentUser()
        {
            var userId = GetUserId();

            if (userId == null) return BadRequest();

            var reservations = await _reservationService.GetAllForCurrentUser(userId);

            if (reservations == null) return BadRequest();

            return Ok(_mapper.Map<ReservationResultDto>(reservations));
        }

        [HttpGet("dates")]
        public async Task<IActionResult> GetReservedDatesForUser()
        {
            var userId = GetUserId();

            if (userId == null) return BadRequest();

            var dates = await _reservationService.GetReservedDatesForUser(userId);

            if (dates == null) return BadRequest();

            return Ok(dates);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReservationAddDto reservationDto)
        {
            reservationDto.DateOfReservation = reservationDto.DateOfReservation.ToLocalTime().AddMonths(-1);

            if (!ModelState.IsValid) return BadRequest();

            var userId = GetUserId();

            if (userId == null) return BadRequest();

            var user = await _userService.GetById(userId);

            if (user == null) return BadRequest();

            var res = _mapper.Map<Reservation>(reservationDto);

            res.UserStringId = user.StringId;

            var reservation = await _reservationService.Add(res);

            if (reservation == null) return BadRequest();

            return Ok();
        }

        [HttpPut("cancel/{reservationId:int}")]
        public async Task<IActionResult> Cancel(int reservationId)
        {
            if (reservationId < 1) return BadRequest();

            var canceledResId = await _reservationService.Cancel(reservationId);

            if (canceledResId < 1) return BadRequest();

            return Ok();
        }

        [Authorize(Policy = ADMIN_POLICY)]
        [HttpPut("cancel-for-date")]
        public async Task<IActionResult> CancelForDate([FromBody] DateTime date)
        {
            if (date < DateTime.Now.Date) return BadRequest();

            var isCanceled = await _reservationService.CancelForDate(date);

            if (!isCanceled) return BadRequest();

            return Ok();
        }

        private string GetUserId()
        {
            if (!User.Identity.IsAuthenticated) return null;

            return User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
