using AutoMapper;
using BEAgenda.Data.Repository.Interfaces;
using BEAgenda.Entities;
using BEAgenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listUsers = await _userRepository.GetListUsers();

                var listUsersDto = _mapper.Map<IEnumerable<UserDTO>>(listUsers);

                return Ok(listUsersDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetOne(int Id)
        {
            try
            {

                var user = await _userRepository.GetUserById(Id);
                if (user == null)
                {
                    return NotFound();
                }

                var userDTO = _mapper.Map<UserDTO>(user);

                return Ok(userDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUser(user);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                user = await _userRepository.AddUser(user);

                var userItemDto = _mapper.Map<UserDTO>(user);


                return CreatedAtAction("GetOne", new { id = user.Id }, user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                if (id != user.Id)
                {
                    return BadRequest();
                }

                var userItem = await _userRepository.GetUserById(id);

                if (userItem == null)
                {
                    return NotFound();
                }

                await _userRepository.UpdateUser(user);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
