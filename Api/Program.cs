namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        WebApplication app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.MapFallbackToFile("index.html");

        app.UseCors(b => b
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        
        app.Run();
    }
}