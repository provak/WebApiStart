public class InMemoryStorage : IStorage
{
  private List<Contact> Contacts { get; set; }

  public InMemoryStorage()
  {
    Contacts = new List<Contact>();

    for (int i = 1; i <= 5; i++)
    {
      Contacts.Add(new Contact
      {
        Id = i,
        Name = $"Полное имя {i}",
        Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{i}@mail.com"
      });
    }
  }

  public List<Contact> GetContacts()
  {
    return Contacts;
  }

  public Contact Add(Contact contact)
  {
    if (FindContactById(contact.Id) == null)
    {
      Contacts.Add(contact);
      return contact;
    }
    return null;
  }

  public bool Remove(int id)
  {
    var contact = FindContactById(id);
    if (contact != null)
    {
      Contacts.Remove(contact);
      return true;
    }
    return false;
  }

  public bool Update(ContactDto contactDto, int id)
  {
    var contact = FindContactById(id);
    if (contact != null)
    {
      if (!String.IsNullOrEmpty(contact.Name))
      {
        contact.Name = contactDto.Name;
      }
      if (!String.IsNullOrEmpty(contact.Email))
      {
        contact.Email = contactDto.Email;
      }
      return true;
    }
    return false;
  }

  public Contact FindContactById(int id)
  {
    return Contacts.FirstOrDefault(c => c.Id == id);
  }
}
