using Bogus;
using Microsoft.Data.Sqlite;

public class FakerInitializer : IInitializer
{
    private readonly string connectionString;

    public FakerInitializer(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Initialize()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS contacts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                email TEXT NOT NULL
            );
        ";
        command.ExecuteNonQuery();

        command.CommandText = @"SELECT COUNT(*) FROM contacts;";

        long count = (long)command.ExecuteScalar();

        if (count == 0)
        {
            var faker = new Faker<Contact>("ru")
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email());

            var data = faker.Generate(20);

            foreach (var item in data)
            {
                command.CommandText = @"
                    INSERT INTO contacts (name, email) VALUES
                    (@name, @email);
                ";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@email", item.Email);
                command.ExecuteNonQuery();
            }
        }
    }
}