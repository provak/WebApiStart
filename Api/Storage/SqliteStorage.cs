using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage
{

    private readonly string connectionString;

    public SqliteStorage(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Contact Add(Contact contact)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO contacts(name, email) VALUES (@name, @email);
            SELECT LAST_INSERT_ROWID();";
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);
        contact.Id = Convert.ToInt32(command.ExecuteScalar());
        return contact;
    }

    public Contact FindContactById(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts WHERE id = @id";
        command.Parameters.AddWithValue("@id", id);
        using var reader = command.ExecuteReader();
        Contact contact = new Contact();
        while (reader.Read())
        {
            contact = new Contact
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            };
        }

        return contact;
    }

    public List<Contact> GetContacts()
    {
        var contacts = new List<Contact>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            contacts.Add(new Contact
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return contacts;
    }

    public bool Remove(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        var sql = $"DELETE FROM contacts WHERE id = @id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);

        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        var sql = "UPDATE contacts SET name=@name, email=@email WHERE id=@id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", contactDto.Name);
        command.Parameters.AddWithValue("@email", contactDto.Email);

        return command.ExecuteNonQuery() > 0;
    }
}