using BLL.Abstract;
using BLL.Concrete;
using CORE.Identity;
using CORE.Mapping;
using DAL.Abstract;
using DAL.Concrete.EfCore;
using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WEBUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            //Dependency Injection
            builder.Services.AddScoped<IProductDal, EfCoreProductDal>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IAboutDal, EfCoreAboutDal>();
            builder.Services.AddScoped<IAboutService, AboutService>();

            builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IContactDal, EfCoreContactDal>();
            builder.Services.AddScoped<IContactService, ContactService>();

            builder.Services.AddScoped<IMailDal, EfCoreMailDal>();
            builder.Services.AddScoped<IMailService, MailService>();


            #region  Service lifetimes(Servis ömürleri) ?
            /*
  

Asp.Net ‘te sunucuya gelen her istek ile yeni bir servis kapsamý oluþturulur, bu istek sona erdiðinde istek ile beraber çözümlenen tüm servisler, servis kapsamý ile beraber temizlenir. Bu servis ömürleri (service lifetimes) , servislerin ne þekilde çözümleneceðini ve temizleneceðini belirler.

Asp.Net Core’da varsayýlan olarak gelen Dependency injection kütüphanesi bize üç adet servis ömrü sunar.

· AddSingleton

· AddScoped

· AddTransient

Bunlarý kýsaca bir özetleyelim daha sonra örnek ile daha detaylý ele alalým.

AddSingleton ?


Uygulamamýz ilk çalýþtýðýnda , servisin bir tane instance ’ýný oluþturur ve bu bilgiyi memory de tutar. Servis her çaðrýldýðýnda en baþta oluþturulan instance ’ý kullanýlýr. Yani ICacheManager dependency injection yapýlan Controller da her hangi bir method’a istek atýldýðýnda, uygulama ilk çalýþtýðý anda memory’e attýðý MyRedisClienti getirir yeniden newlemez.

AddScoped ?


Gelen her istekte yeni bir instance oluþturur. Yani IGeneralManager dependency injection yapýlan Controller da her hangi bir method ’a istek atýldýðýnda bu servis yeniden çaðrýlmýþ olur ve yeni bir instance oluþturur. Ayný istek aþamasýnda bir instance oluþturur ve onu kullanýr, farklý isteklerde yeni bir instance oluþturur.

AddTransient ?


Servis her çaðrýldýðýn da yeni bir instance oluþturur. Yani ayný istek aþamasýnda da farklý isteklerde de servis birden fazla kez çaðrýlýyorsa servis her çaðrýldýðýnda yeni bir instance oluþturur.

Bütün bunlarý daha anlaþýlýr hale getirebilmek için birde örnekler üzerinden bakalým./
   */
            #endregion

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
