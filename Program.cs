using BonWeb.Data;
using BonWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BonWeb.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.Categories.Any())
    {
        var coffee = new Category { Name = "Кафе" };
        var peanuts = new Category { Name = "Кикирики" };
        var nuts = new Category { Name = "Апетисани" };

        context.Categories.AddRange(coffee, peanuts, nuts);
        context.SaveChanges();
    }

    if (!context.Categories.Any(c => c.Name == "Зрнести производи"))
    {
        context.Categories.Add(new Category { Name = "Зрнести производи" });
    }

    if (!context.Categories.Any(c => c.Name == "Суво овошје"))
    {
        context.Categories.Add(new Category { Name = "Суво овошје" });
    }

    if (!context.Categories.Any(c => c.Name == "BON Cooking"))
    {
        context.Categories.Add(new Category { Name = "BON Cooking" });
    }

    context.SaveChanges();

    DbSeeder.SeedProducts(context);
}
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminEmail = "admin@bon.mk";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(adminUser, "Admin123!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
app.Run();