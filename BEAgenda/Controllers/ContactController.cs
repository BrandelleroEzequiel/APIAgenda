using AutoMapper;
using BEAgenda.Models;
using BEAgenda.Models.DTO;
using BEAgenda.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactController(IMapper mapper,IContactRepository contactRepository) 
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
            {
                var listContacts = await _contactRepository.GetListContacts();

                var listContactsDto = _mapper.Map<IEnumerable<ContactDTO>>(listContacts);

                return Ok(listContactsDto);
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
                var contact = await _contactRepository.GetContact(id);
                
                if(contact == null)
                {
                    return NotFound();
                }

                var contactDto = _mapper.Map<ContactDTO>(contact);

                return Ok(contactDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactDTO contactDto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(contactDto);

                contact = await _contactRepository.AddContact(contact);

                var contactItemDto = _mapper.Map<ContactDTO>(contact);

                return Ok(contactItemDto);

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ContactDTO contactDto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(contactDto);

                if (id != contact.id)
                {
                    return BadRequest();
                }

                var contactItem = await _contactRepository.GetContact(id);

                if (contactItem == null)
                {
                    return NotFound();
                }

                await _contactRepository.UpdateContact(contact);  

                return NoContent();

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

                var contact = await _contactRepository.GetContact(id);

                if (contact == null)
                {
                    return NotFound();
                }

                await _contactRepository.DeleteContact(contact);

                return Ok(new { message = "Contacto eliminado con éxito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
} 
 