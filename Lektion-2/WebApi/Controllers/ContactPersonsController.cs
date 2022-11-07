using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entitites;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactPersonsController(DataContext context)
        {
            _context = context;
        }





        // GET: api/ContactPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPersonEntity>>> GetContactPersons()
        {
            return await _context.ContactPersons.ToListAsync();
        }







        // GET: api/ContactPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPersonEntity>> GetContactPersonEntity(int id)
        {
            var contactPersonEntity = await _context.ContactPersons.FindAsync(id);

            if (contactPersonEntity == null)
            {
                return NotFound();
            }

            return contactPersonEntity;
        }








        // PUT: api/ContactPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPersonEntity(int id, ContactPersonEntity contactPersonEntity)
        {
            if (id != contactPersonEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactPersonEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPersonEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }








        // POST: api/ContactPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactPersonEntity>> PostContactPersonEntity(ContactPerson contactPerson)
        {
            var contactPersonEntity = new ContactPersonEntity
            {
                FirstName = contactPerson.FirstName,
                LastName = contactPerson.LastName,
                Email = contactPerson.Email,
                Phone = contactPerson.Phone,
                Mobile = contactPerson.Mobile,
                AddressId = contactPerson.AddressId
            };

            _context.ContactPersons.Add(contactPersonEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactPersonEntity", new { id = contactPersonEntity.Id }, contactPersonEntity);
        }








        // DELETE: api/ContactPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactPersonEntity(int id)
        {
            var contactPersonEntity = await _context.ContactPersons.FindAsync(id);
            if (contactPersonEntity == null)
            {
                return NotFound();
            }

            _context.ContactPersons.Remove(contactPersonEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }









        private bool ContactPersonEntityExists(int id)
        {
            return _context.ContactPersons.Any(e => e.Id == id);
        }
    }
}
