using Microsoft.AspNetCore.ResponseCompression;
using Scooterland.Client.Services.EmployeeServices;
using Scooterland.Server.Repositories.CustomerRepository;
using Scooterland.Server.Repositories.ProductRepository;
using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Server.Repositories.SaleRepository;
using Scooterland.Server.Repositories.SpecializationRepository;
using Scooterland.Server.Repositories.SalesLineItemRepository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductRepository, ProductRepositoryEF>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryEF>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryEF>();
builder.Services.AddScoped<ISaleRepository, SaleRepositoryEF>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepositoryEF>();
builder.Services.AddScoped<ISalesLineItemRepository, SalesLineItemRepositoryEF>();
builder.Services.AddControllers() // Konfigurer JSON-serialisering i serveren til at ignorere cirkulære referencer.
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
	});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
