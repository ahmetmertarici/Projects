using BusBookingApp.Business.Abstract;
using BusBookingApp.Business.Concrete;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Data.Concrete.EfCore;
using BusBookingApp.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyIdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<MyIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied"; 
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(500);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".BusBookingApp.Security.Cookie"
    };

});



var sqliteConnection=builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<BusBookingContext>(options=>options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<IBusRepository, EfCoreBusRepository>();
builder.Services.AddScoped<ICityRepository, EfCoreCityRepository>();
builder.Services.AddScoped<ICustomerRepository, EfCoreCustomerRepository>();
builder.Services.AddScoped<ITicketRepository, EfCoreTicketRepository>();
builder.Services.AddScoped<ITravelDetailRepository, EfCoreTravelDetailRepository>();
builder.Services.AddScoped<ICompanyIntroductionRepository, EfCoreCompanyIntroductionRepository>();
builder.Services.AddScoped<ISupportRepository, EfCoreSupportRepository>();
builder.Services.AddScoped<IContactRepository, EfCoreContactRepository>();

builder.Services.AddScoped<IBusService, BusManager>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ITicketService, TicketManager>();
builder.Services.AddScoped<ITravelDetailService, TravelDetailManager>();
builder.Services.AddScoped<ICompanyIntroductionService, CompanyIntroductionManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<ISupportService, SupportManager>();





builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
