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
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IUnitOfWork unitOfWork,
            ILogger<ContactsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact() =>
            await _unitOfWork.ContactRepository.GetAllAsync();

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact = await _unitOfWork.ContactRepository.GetbyIdAsync(id);

            if (contact == null)
            {
                _logger.LogDebug($"Don't found the contact with id: {id}.");
                return NotFound();
            }

            return contact;
        }

        // GET: api/Contacts/Name
        [HttpGet("{name}")]
        public async Task<ActionResult<Contact>> GetContactbyName(string name)
        {
            var contact = await _unitOfWork.ContactRepository.GetAsync(x => x.Name == name);

            if (contact == null)
            {
                _logger.LogDebug($"Don't found the contact with name: {name}.");
                return NotFound();
            }

            return contact.FirstOrDefault();
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Guid id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ContactRepository.Update(contact);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_unitOfWork.ContactRepository.Exists(id))
                {
                    _logger.LogError($"Update function error: Contact don't exist.");
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

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            await _unitOfWork.ContactRepository.AddAsync(contact);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await _unitOfWork.ContactRepository.DeleteAsync(id);
            if (contact == null)
            {
                _logger.LogDebug($"Don't found contact with id {id}.");
                return NotFound();
            }
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
