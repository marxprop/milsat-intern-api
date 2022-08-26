using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilsatInternAPI.Data;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
    
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<MilsatInternAPIContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MilsatInternAPIContext") ?? throw new InvalidOperationException("Connection string 'MilsatInternAPIContext' not found.")));

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(); 
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
