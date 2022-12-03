using BEAgenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ContactController(AplicationDbContext context)
        {
            _context = context; 
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
            {
                var listContacts = await _context.Contacts.ToListAsync();
                return Ok(listContacts);
            }
            catch (Exception ex)
            {  
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(id);
                
                if(contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            try
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();

                return Ok(contact);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            try
            {
                if (id != contact.id)
                {
                    return BadRequest();
                }

                _context.Update(contact);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Contacto actualizado con éxito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var contact = await _context.Contacts.FindAsync(id);

                if (contact == null)
                {
                    return NotFound();
                }

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Contacto eliminado con éxito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
} 
 