using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.Data.Abstract;
using Blog.Data.Concrete.EfCore;
using Blog.Web.Identity;
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
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(300);
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
        Name = ".BlogApp.Security.Cookie"
    };

});









var sqliteConnection=builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<BlogContext>(options=>options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<IArticleRepository, EfCoreArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
builder.Services.AddScoped<IWriterRepository, EfCoreWriterRepository>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IWriterService, WriterManager>();


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
    name: "search",
    pattern: "search",
    defaults: new { controller = "Blog", action = "Search" }
);
app.MapControllerRoute(
    name: "articles",
    pattern: "articles/{category?}",
    defaults: new { controller = "Home", action = "ArticlesByCategories" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
