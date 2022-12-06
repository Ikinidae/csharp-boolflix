using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Data;
using csharp_boolflix.Models.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BoolflixDbContextConnection");
builder.Services.AddDbContext<BoolflixDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BoolflixDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BoolflixDbContext>();

//per far partire con db se funziona
builder.Services.AddScoped<IContentRepository, DbContentRepository>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//prima del MapControllerRoute
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Index}/{id?}");

app.Run();
