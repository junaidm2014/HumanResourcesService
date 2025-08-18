
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register CSV repositories for now
builder.Services.AddSingleton<HumanResourcesService.Repositories.IEmployeeRepository, HumanResourcesService.Repositories.EmployeeCsvRepository>();
builder.Services.AddSingleton<HumanResourcesService.Repositories.IDepartmentRepository, HumanResourcesService.Repositories.DepartmentCsvRepository>();

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

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
