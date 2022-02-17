using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.UnitOfWork.Interfaces;

namespace ReservationSystem.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(IUnitOfWork unitOfWork, 
            ILogger<ReservationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservation() => 
            await _unitOfWork.ReservationRepository.GetAsync(includeProperties: "Contact");

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(Guid id)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetAsync(res => res.Id == id, 
                                                                         includeProperties: "Contact");

            if (reservation == null)
            {
                _logger.LogDebug($"Don't found the reservation with id: {id}.");
                return NotFound();
            }

            return reservation.FirstOrDefault();
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(Guid id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ReservationRepository.Update(reservation);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_unitOfWork.ReservationRepository.Exists(id))
                {
                    _logger.LogError($"Update function error: Reservation don't exist.");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Update function error: {ex.Message}");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _unitOfWork.ReservationRepository.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var reservation = await _unitOfWork.ReservationRepository.DeleteAsync(id);
            if (reservation == null)
            {
                _logger.LogDebug($"Don't found reservation with id {id}.");
                return NotFound();
            }
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
