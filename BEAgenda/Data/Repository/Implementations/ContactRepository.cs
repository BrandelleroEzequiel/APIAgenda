using BEAgenda.Data.Repository.Interfaces;
using BEAgenda.Entities;
using Microsoft.EntityFrameworkCore;

namespace BEAgenda.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AplicationDbContext _context;

        public ContactRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetListContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task UpdateContact(Contact contact)
        {
            var contactItem = await _context.Contacts.FirstOrDefaultAsync(x => x.id == contact.id);

            if (contactItem != null)
            {
                contactItem.Name = contact.Name;
                contactItem.Number = contact.Number;
                contactItem.Email = contact.Email;

                await _context.SaveChangesAsync();
            }
        }
    }
}
