using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CommunityLibrary.Components;
using CommunityLibrary.Components.Account;
using CommunityLibrary.Data;
using CommunityLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<BookService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    // --- GOOGLE AUTH TEMPORARILY DISABLED FOR LOCAL TESTING ---
    // .AddGoogle(options =>
    // {
    //     options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
    //     options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "";
    // })
    // -----------------------------------------------------------
    .AddIdentityCookies();

// --- USE FAKE DB CONNECTION FOR LOCAL TESTING ---
var connectionString = "Host=localhost;Database=fakedb;Username=fake;Password=fake";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// -------------------------------------------------

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
    options.ForwardLimit = null;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.Use((context, next) =>
    {
        context.Request.Scheme = "https";
        context.Request.Host = new HostString("communitylibrary-rl1v.onrender.com");
        return next();
    });
}

app.UseForwardedHeaders();
app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

// --- DATABASE MIGRATION TEMPORARILY DISABLED FOR LOCAL TESTING ---
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//     db.Database.Migrate();
//     await RoleSeeder.SeedRolesAsync(scope.ServiceProvider);
// }
// ------------------------------------------------------------------

app.Run();