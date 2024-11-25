public class ContactsStorage
{
  private List<Contact> Contacts { get; set; }

  public ContactsStorage()
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

  public List<Contact> GetAll()
  {
    return Contacts;
  }

  public bool Add(Contact contact)
  {
    if (FindContact(contact.Id) == null)
    {
      Contacts.Add(contact);
      return true;
    }
    return false;
  }

  public bool Remove(int id)
  {
    var contact = FindContact(id);
    if (contact != null)
    {
      Contacts.Remove(contact);
      return true;
    }
    return false;
  }

  public bool Update(ContactDto contactDto, int id)
  {
    var contact = FindContact(id);
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

  public Contact FindContact(int id)
  {
    return Contacts.FirstOrDefault(c => c.Id == id);
  }
}
