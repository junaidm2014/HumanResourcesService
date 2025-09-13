using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register EF repositories
builder.Services.AddDbContext<HumanResourcesService.Data.HumanResourcesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<HumanResourcesService.Repositories.IEmployeeRepository, HumanResourcesService.Repositories.EmployeeRepository>();
builder.Services.AddScoped<HumanResourcesService.Repositories.IDepartmentRepository, HumanResourcesService.Repositories.DepartmentRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication stub (to be implemented)
// app.UseMiddleware<AuthStubMiddleware>();

app.MapControllers();

app.Run();
