using KUSYS_Demo.Business;
using KUSYS_Demo.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices(services =>
{
    services.AddSingleton<IStudentBusiness, StudentBusiness>();
    services.AddSingleton<ICourseBusiness, CourseBusiness>();
    services.AddSingleton<IStudentDal, StudentDal>();
    services.AddSingleton<ICourseDal, CourseDal>();
});



var mapper = new AutoMap();

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