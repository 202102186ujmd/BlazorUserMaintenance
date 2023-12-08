using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using WebApiUser.Interfaces;
using WebApiUser.Models;
using WebApiUser.Services;


#region Nlog Service

var logger = LogManager.Setup().
    LoadConfigurationFromAppSettings().
    GetCurrentClassLogger();

logger.Debug("Init main");
#endregion

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //Conexion a la base de datos
    builder.Services.AddDbContext<UserBDContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserConecctionBD"));
    });
    //Inyeccion de dependencias
    builder.Services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
    builder.Services.AddScoped<ISolicitudesRepository, SolicitudesRepository>();
    



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Error en la aplicación");
    throw;
}
finally
{
    LogManager.Shutdown();
}

