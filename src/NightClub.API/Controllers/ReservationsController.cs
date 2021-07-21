using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Reservation;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using static NightClub.Domain.Constants;
using System;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [Authorize(Policy = ADMIN_POLICY)]
        [HttpGet("for-date")]
        public async Task<IActionResult> GetAllForDate([FromBody] DateTime date)
        {
            if (date == null) return BadRequest();

            var reservations = await _reservationService.GetAllForDate(date);

            if (reservations == null) return BadRequest();

            return Ok(_mapper.Map<ReservationResultDto>(reservations));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetForCurrentUser(string userId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId)) return BadRequest();

            var reservations = await _reservationService.GetAllForCurrentUser(userId);

            if (reservations == null) return BadRequest();

            return Ok(_mapper.Map<ReservationResultDto>(reservations));
        }

        [HttpGet("dates/{userId}")]
        public async Task<IActionResult> GetReservedDatesForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId)) return BadRequest();

            var dates = await _reservationService.GetReservedDatesForUser(userId);

            if (dates == null) return BadRequest();

            return Ok(dates);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReservationAddDto reservationDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var reservation = await _reservationService.Add(_mapper.Map<Reservation>(reservationDto));

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
    }
}
