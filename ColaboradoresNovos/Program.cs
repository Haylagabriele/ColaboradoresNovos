using ColaboradoresNovos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IServiceCollection serviceCollection = builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    global::Microsoft.EntityFrameworkCore.DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));

});


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

string Nome = "Hayla";
ConsoleWriteLine(Nome);

void ConsoleWriteLine(string nome)
{
    throw new NotImplementedException();
}