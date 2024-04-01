using Shopping_cart.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Shopping_cart.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Shopping_cart.Services;
using Shopping_cart.CustomFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Enables integration between FluentValidation and ASP.NET MVC's automatic validation pipeline.
builder.Services.AddFluentValidationAutoValidation();

//Enables integration between FluentValidation and ASP.NET client-side validation.
builder.Services.AddFluentValidationClientsideAdapters();

//Registering Model and Validator to show the error message on client side
builder.Services.AddTransient<IValidator<ApplicationUser>, ApplicationUserValidator>();

// Dependencies to the container
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<ApplicationDBcontext>(options =>
{
	options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
		options =>
		{
			options.SignIn.RequireConfirmedEmail = true;
		}
	)
	.AddEntityFrameworkStores<ApplicationDBcontext>()
	.AddDefaultTokenProviders();

builder.Services.AddTransient<ISenderEmail, EmailService>();
builder.Services.AddScoped<ConfirmEmailFilter>();
builder.Services.AddScoped<PasswordResetTokenFilter>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
