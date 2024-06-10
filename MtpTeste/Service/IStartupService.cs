namespace MtpTeste.Service
{
	public interface IStartupService
	{
		IConfiguration Configuration { get; }
		void Configure(WebApplication app, IWebHostEnvironment environment);
		void ConfigureServices(IServiceCollection services);
	}
}
