using LemonSharp.VaccinationSite.Application.AppServices;
using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;
using LemonSharp.VaccinationSite.Infrastructure;
using LemonSharp.VaccinationSite.Infrastructure.Repositories;
using LemonSharp.VaccinationSite.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddDbContext<VaccinationSiteContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("VaccinationSite")));
builder.Services.AddScoped<ISiteAppService, SiteAppService>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();

builder.Services.AddSingleton<ISiteQueries, SiteQueries>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
