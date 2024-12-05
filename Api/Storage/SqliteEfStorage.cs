
public class SqliteEfStorage : IStorage
{
    private readonly SqliteDbContext context;

    public SqliteEfStorage(SqliteDbContext context)
    {
        this.context = context;
    }

    public Contact Add(Contact contact)
    {
        context.Add(contact);
        context.SaveChanges();
        return contact;
    }

    public Contact FindContactById(int id)
    {
        return context.Contacts.Find(id);
    }

    public List<Contact> GetContacts()
    {
        return context.Contacts.ToList();
    }

    public bool Remove(int id)
    {
        var contact = context.Contacts.Find(id);
        if (contact == null)
        {
            return false;
        }

        context.Contacts.Remove(contact);
        context.SaveChanges();
        return true;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        var contact = context.Contacts.Find(id);
        if (contact == null)
        {
            return false;
        }
        contact.Name = contactDto.Name;
        contact.Email = contactDto.Email;
        context.SaveChanges();
        return true;
    }
}