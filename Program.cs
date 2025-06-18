using Microsoft.EntityFrameworkCore;
using System.Dynamic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var databaseProvider = builder.Configuration["DatabaseProvider"];


builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (databaseProvider == "Sqlite")
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    }
});
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanCalculatorService, LoanCalculatorService>();
builder.Services.AddScoped<LoanFacade>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loans}/{action=Create}/{id?}");
   
app.Run();
