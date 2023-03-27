using KUSYS_Demo.Business;
using KUSYS_Demo.Business.Core;
using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Repository.Core;
using KUSYS_Demo.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost", "http://localhost:3000")
                          .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices(services =>
{
    services.AddSingleton<IStudentBusiness, StudentBusiness>();
    services.AddSingleton<ICourseBusiness, CourseBusiness>();
    services.AddSingleton<IStudentCourseBusiness, StudentCourseBusiness>();
    services.AddSingleton<IStudentCourseDal, StudentCourseDal>();
    services.AddSingleton<IStudentDal, StudentDal>();
    services.AddSingleton<ICourseDal, CourseDal>();
    services.AddSingleton<IMapper, AutoMap>();
});

//var mapper = new AutoMap();
new DBInitializer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

