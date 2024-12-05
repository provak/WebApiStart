using Microsoft.EntityFrameworkCore;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services,
        ConfigurationManager config)
    {

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        var stringConnection = config.GetConnectionString("SqliteStringConnection");
        services.AddDbContext<SqliteDbContext>(options => options.UseSqlite(stringConnection));
        services.AddScoped<IStorage, SqliteEfStorage>();
        services.AddScoped<IInitializer, SqliteEfFakerInitializer>();
        // services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(config["client"]);
            });
        });

        return services;
    }
}