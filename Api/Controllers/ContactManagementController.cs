using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
  private ContactsStorage storage;

  public ContactManagementController(ContactsStorage storage)
  {
    this.storage = storage;
  }

  [HttpPost("contacts")]
  public IActionResult Add([FromBody] Contact contact)
  {
    if (storage.Add(contact))
    {
      return Created();
    }

    return Conflict("Контакт с указанным Id существует.");
  }

  [HttpGet("contacts")]
  public ActionResult<List<Contact>> GetContacts()
  {
    return Ok(storage.GetAll());
  }

  [HttpGet("contacts/{id}")]
  public ActionResult<Contact> GetContactById(string id)
  {
    int result;
    int.TryParse(id, out result);

    if (result == 0)
    {
      return BadRequest("Неверный формат ID или не соответствие ожидаемым критериям (например, не числовое значение или некорректные символы).");
    }

    var contact = storage.FindContact(result);

    if (contact == null)
    {
      return NotFound("Контакт с заданным ID не найден.");
    }

    return Ok(contact);
  }

  [HttpDelete("contacts/{id}")]
  public IActionResult DeleteContactById(int id)
  {
    if (storage.Remove(id))
    {
      return NoContent();
    }
    return BadRequest("Контакт с таким Id не найден");
  }

  [HttpPut("contacts/{id}")]
  public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
  {
    if (storage.Update(contactDto, id))
    {
      return Ok(contactDto);
    }
    return BadRequest("Контакт с таким Id не найден");
  }
}
