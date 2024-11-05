using BLL.DAL;
using BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
//Bundan sonra her servis oluşturduğumuzda bağımlılığını yönetmek için Program.cs'e ekliyoruz.

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

//Örneğin database tablosu yerine excel tablosundan kayıt almak istedik. Database işlemleri için oluşturduğumuz varolan class'lara dokunmayız onun yerine dependency injection sayesinde yeni bir class oluşturup yine servisi program.cs'e ekleyerek rahatlıkla bu işlemi yapabiliriz.