using System.ComponentModel.DataAnnotations;

namespace BEAgenda.Models
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
