using ConfigWebApi;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injectin for configuration IOptions<TOption> interface
builder.Services.Configure<ConfigurationOptions>(builder.Configuration.GetSection(ConfigurationOptions.SectionName));

//get access multiple sectins in configuration by named options-1
builder.Services.Configure<ConfigOps>(ConfigOps.SystemConfigSectionName, builder.Configuration.GetSection($"{ConfigOps.SectionName}:{ConfigOps.SystemConfigSectionName}"));

//get access multiple sectins in configuration by named options-2
builder.Services.Configure<ConfigOps>(ConfigOps.BusinessConfigSectionName, builder.Configuration.GetSection($"{ConfigOps.SectionName}:{ConfigOps.BusinessConfigSectionName}"));

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
