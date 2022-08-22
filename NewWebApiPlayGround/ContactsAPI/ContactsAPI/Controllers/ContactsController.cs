using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsAPIDbContext _dbContext;
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet] // Get data
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }

        [HttpPost] // Add data
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut] // Update data
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;
                contact.Address = updateContactRequest.Address;

                await _dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }
        [HttpGet] // Get data by Id:
        [Route("{id:guid}")]
        public async Task <IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task <IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if( contact != null)
            {
                _dbContext.Remove(contact);
               await _dbContext.SaveChangesAsync();
                return Ok(contact);

            }
            return NotFound();
        }
    }
}
