public static class ApplicationServiceProviderExtensions
{
    public static IApplicationBuilder AddCustomService(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
        initializer.Initialize();

        return app;
    }
}