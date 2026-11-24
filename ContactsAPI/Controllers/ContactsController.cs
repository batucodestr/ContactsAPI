using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsAPI.Models;
using ContactsAPI.Data;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Dependency Injection ile DbContext'i alıyoruz

        private readonly ContactsAPIDbContext _dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] AddContactContextRequest addContextRequest)
        {
            var contact = new Contact
            {
                FullName = addContextRequest.FullName,
                Email = addContextRequest.Email,
                PhoneNumber = addContextRequest.PhoneNumber,
                Address = addContextRequest.Address,
            };

            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactContextRequest updateContextRequest) //id'ye göre güncelleme
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {

                contact.Address = updateContextRequest.Address;
                contact.Email = updateContextRequest.Email;
                contact.FullName = updateContextRequest.FullName;
                contact.PhoneNumber = updateContextRequest.PhoneNumber;


                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact);
        }
    }
}
