using BeautySalonAPI;
using BeautySalonAPI.Entities;
using BeautySalonAPI.Services;
using BeautySalonAPI.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args); // == public static IHostBuilder CreateHostBuilder

// Add services to the container.
// Similar to ConfigureServices in DotNet5
builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BeautySalonDbContext>();
builder.Services.AddScoped<Seeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// To set Middlewares

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BeautySalonAPI"));

app.UseAuthorization();

app.MapControllers();

app.Run();
