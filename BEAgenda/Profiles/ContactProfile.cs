using AutoMapper;
using BEAgenda.Entities;

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
