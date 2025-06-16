using Dal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("Allow All", opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddScoped<IDal.IDal<Dto.City>,Dal.Cities>();
builder.Services.AddScoped<Bll.Cities,Bll.Cities>();
builder.Services.AddScoped<IDal.IDal<Dto.Company>, Dal.Companies>();
builder.Services.AddScoped<Bll.Companies, Bll.Companies>();
builder.Services.AddScoped<IDal.IDal<Dto.DriveType>, Dal.DriveTypes>();
builder.Services.AddScoped<Bll.DriveTypes, Bll.DriveTypes>();
builder.Services.AddScoped<IDal.IDal<Dto.Model>, Dal.Models_>();
builder.Services.AddScoped<Bll.Models, Bll.Models>();
builder.Services.AddScoped<IDal.IDal<Dto.TypeVehicle>, Dal.TypeVehicles>();
builder.Services.AddScoped<Bll.TypeVehicles, Bll.TypeVehicles>();
builder.Services.AddScoped<IDal.ICar, Dal.Cars>();
builder.Services.AddScoped<Bll.Cars, Bll.Cars>();
builder.Services.AddScoped<Dal.Users,Dal.Users>();
builder.Services.AddScoped<Bll.User,Bll.User>();
builder.Services.AddScoped<Dal.Lendings,Dal.Lendings>();
builder.Services.AddScoped<Bll.Lending,Bll.Lending>();
builder.Services.AddDbContext<CarRentalContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow All");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
