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
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<LoanService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "";
        options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
        options.CorrelationCookie.SameSite = SameSiteMode.None;
        options.Events.OnRedirectToAuthorizationEndpoint = ctx =>
        {
            var redirectUri = ctx.RedirectUri;
            if (!builder.Environment.IsDevelopment() && redirectUri.Contains("redirect_uri="))
            {
                var encoded = Uri.EscapeDataString("https://communitylibrary-rl1v.onrender.com/signin-google");
                redirectUri = System.Text.RegularExpressions.Regex.Replace(
                    redirectUri,
                    @"redirect_uri=[^&]*",
                    $"redirect_uri={encoded}");
            }
            ctx.Response.Redirect(redirectUri);
            return Task.CompletedTask;
        };
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped(sp => sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        // --- LOCALLY DISABLED: Allow login without email confirmation ---
        options.SignIn.RequireConfirmedAccount = false;
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

using (var scope = app.Services.CreateScope())
{
    await DatabaseInitializer.InitializeAsync(scope.ServiceProvider);
}

app.Run();