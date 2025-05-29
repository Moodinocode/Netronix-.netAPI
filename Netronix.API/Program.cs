using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Mappings;
using Netronix.API.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NetronixDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NetronixConnectionString")));


builder.Services.AddScoped<IProductRepository, SQLProductRepository>();
builder.Services.AddScoped<ITagRepository, SQLTagRepository>();
builder.Services.AddScoped<IOrderRepository, SQLOrderRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


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
