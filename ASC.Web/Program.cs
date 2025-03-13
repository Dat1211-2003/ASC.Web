using ASC.Web.Configuration;
using ASC.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using ASC.Solution.Configuration;
//using ASC.Solution.Data;
using ASC.Solution.Services;
using ASC.Web.Services;
using ASC.DataAccess;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();





var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddIdentity<IdentityUser, IdentityRole>((options) =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<DbContext, ApplicationDbContext>();


builder.Services.AddOptions();
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("AppSettings"));




builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
builder.Services.AddTransient<ISmsSender, AuthMessageSender>();

builder.Services.AddSingleton<IIdentitySeed, IdentitySeed>();
builder.Services.AddScoped<UnitOfwork, UnitOfwork>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddRazorPages();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();
app.UseSession();

using (var scope = app.Services.CreateScope())
{
    var storageSeed = scope.ServiceProvider.GetRequiredService<IIdentitySeed>();
    await storageSeed.Seed(
    scope.ServiceProvider.GetService<UserManager<IdentityUser>>(),
    scope.ServiceProvider.GetService<RoleManager<IdentityRole>>(),
    scope.ServiceProvider.GetService<IOptions<ApplicationSettings>>());
}

app.Run();
