using Microsoft.EntityFrameworkCore;
using PrescriptionAPI.Data;
using PrescriptionAPI.Services;
using PrescriptionAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddScoped<PrescriptionValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();