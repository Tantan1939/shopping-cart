using Shopping_cart.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Enables integration between FluentValidation and ASP.NET MVC's automatic validation pipeline.
builder.Services.AddFluentValidationAutoValidation();

//Enables integration between FluentValidation and ASP.NET client-side validation.
builder.Services.AddFluentValidationClientsideAdapters();

//Registering Model and Validator to show the error message on client side
builder.Services.AddTransient<IValidator<User>, UserValidator>();

// Dependencies to the container
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
