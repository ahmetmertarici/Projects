using Blog.API.Identity;
using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.Business.Jobs;
using Blog.Data.Abstract;
using Blog.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quartz;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyIdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<MyIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(30);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".BlogApp.Security.Cookie"
    };

});


builder.Services.AddQuartz(q =>
{
    // Quartz.NET için baðýmlýlýk enjeksiyonu job fabrikasýný kullanma
    q.UseMicrosoftDependencyInjectionJobFactory();

    // Makale yayýnlama iþini tanýmla
    q.AddJob<ArticlePublishJob>(opts => opts.WithIdentity("ArticlePublishJob"));

    // Makale yayýnlama iþi için tetikleyici tanýmla
    // Örnek olarak, her gece yarýsý çalýþacak bir CRON ifadesi kullanýyoruz
    q.AddTrigger(opts => opts
        .ForJob("ArticlePublishJob") // Ýþ ismiyle eþleþtir
        .WithIdentity("ArticlePublishJob-trigger") // Tetikleyici ismi
        .WithCronSchedule("0 46 11 * * ?")); // Gece yarýsý CRON ifadesi
});

// Quartz Hosted Service'i ekleyin ki, uygulama ayaða kalktýðýnda iþler çalýþmaya baþlasýn
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var sqliteConnection = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<IArticleRepository, EfCoreArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
builder.Services.AddScoped<IAboutMeRepository, EfCoreAboutMeRepository>();
builder.Services.AddScoped<IToDoListRepository, EfCoreToDoListRepository>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IAboutMeService, AboutMeManager>();
builder.Services.AddScoped<IToDoListService, ToDoListManager>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
