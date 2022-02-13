using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.UnitOfWork.Interfaces;

namespace ReservationSystem.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContactTypesController> _logger;

        public ContactTypesController(IUnitOfWork unitOfWork,
            ILogger<ContactTypesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactType>>> GetContactTypes() =>
            await _unitOfWork.ContactTypeRepository.GetAllAsync();

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactType(int id)
        {
            var contactType = await _unitOfWork.ContactTypeRepository.GetbyIdAsync(id);

            if (contactType == null)
            {
                _logger.LogDebug($"Don't found the contact type with id: {id}.");
                return NotFound();
            }

            return contactType;
        }

        // PUT: api/ContactTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactType(Guid id, ContactType contactType)
        {
            if (id != contactType.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ContactTypeRepository.Update(contactType);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_unitOfWork.ContactTypeRepository.Exists(id))
                {
                    _logger.LogError($"Update function error: Contact type don't exist.");
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

        // POST: api/ContactTypes
        [HttpPost]
        public async Task<ActionResult<ContactType>> PostContact(ContactType contactType)
        {
            await _unitOfWork.ContactTypeRepository.AddAsync(contactType);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetContactType", new { id = contactType.Id }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contactType = await _unitOfWork.ContactTypeRepository.DeleteAsync(id);
            if (contactType == null)
            {
                _logger.LogDebug($"Don't found contact type with id {id}.");
                return NotFound();
            }
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
