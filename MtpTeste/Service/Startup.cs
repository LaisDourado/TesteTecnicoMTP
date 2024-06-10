using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MtpTeste.Service
{
	public class Startup : IStartupService
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddScoped<ITarefasService, TarefasService>();			

			services.AddDbContext<Db_Context>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddControllersWithViews();
		}

		public void Configure(WebApplication app, IWebHostEnvironment environment)
		{			
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
				pattern: "{controller=ListaDeTarefas}/{action=Index}/{id?}");

			app.Run();
		}
	}
	public static class StartupExtensions
	{
		public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartupService
		{
			var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartupService;
			if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

			startup.ConfigureServices(webAppBuilder.Services);

			var app = webAppBuilder.Build();
			startup.Configure(app, app.Environment);

			app.Run();

			return webAppBuilder;
		}
	}
}
