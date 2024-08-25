using ILT.Core.Data;
using ILT.Core.Data.Contracts.Services;
using ILT.Core.Data.Entities;
using ILT.Core.Data.Services;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDatabase(builder.Configuration);

        builder.Services.AddScoped<IServiceManager, ServiceManager>(x => 
            new ServiceManager(x.GetRequiredService<DbContextOptions<DatabaseContext>>()));

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}