using AutoMapper;
using BEAgenda.Models.DTO;

namespace BEAgenda.Models.Profiles
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();
        }
    }
}
