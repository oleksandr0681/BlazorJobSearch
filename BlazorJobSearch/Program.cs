using BlazorJobSearch.Components;
using BlazorJobSearch.Components.Account;
using BlazorJobSearch.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorJobSearch.JobSearchServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), optionsLifetime: ServiceLifetime.Singleton);
builder.Services.AddDbContextFactory<ApplicationDbContext>((DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddDistributedMemoryCache(); // Усі сесії працюють поверх об'єкта IDistributedCache. Додаю використання IDistributedCache.
builder.Services.AddSession(); // Додаю сервіси сесії.
builder.Services.AddScoped<AppData>();
//builder.Services.AddSingleton<AppData>();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        ApplicationDbContext applicationIdentityDbContext = services.GetRequiredService<ApplicationDbContext>();
        applicationIdentityDbContext.Database.Migrate();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        string userRoleJobCandidate = "JobCandidate";
        string userRoleEmployer = "Employer";
        if (await roleManager.FindByNameAsync(userRoleJobCandidate) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(userRoleJobCandidate));
        }
        if (await roleManager.FindByNameAsync(userRoleEmployer) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(userRoleEmployer));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, ex.Message);
    }
}
app.UseSession(); // Додаю middleware для роботи з сесіями.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
