using DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class Database
{
    private DbContextOptions<ApiTestDbContext> options;

    public Database()
    {
        options = GetDbContextOptions;
    }

    public ApiTestDbContext GetDbContext()
    {
        var context = new ApiTestDbContext(options);
        // Crea y abre el 'schema' en la base de datos
        context.Database.EnsureCreated();
        return context;
    }

    private DbContextOptions<ApiTestDbContext> GetDbContextOptions
    {
        get
        {
            // La BD in-memory solo existe cuando la conexión está abierta
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApiTestDbContext>()
                    .UseSqlite(connection)
                    .Options;

            return options;
        }
    }
}
