using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UC_13_Henrique_Webssite.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UC_13_Henrique_WebssiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UC_13_Henrique_WebssiteContext") ?? throw new InvalidOperationException("Connection string 'UC_13_Henrique_WebssiteContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
