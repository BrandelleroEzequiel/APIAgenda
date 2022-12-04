namespace BEAgenda.Models.Repository
{
    public interface IContactRepository
    {
       Task<List<Contact>> GetListContacts();
        Task<Contact> GetContact(int id);
        Task DeleteContact(Contact contact);
        Task<Contact> AddContact(Contact contact);
        Task UpdateContact(Contact contact);
    }
}
