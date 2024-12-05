public interface IStorage
{
    List<Contact> GetContacts();
    Contact Add(Contact contact);
    bool Remove(int id);
    bool Update(ContactDto contactDto, int id);
    Contact FindContactById(int id);
}
