using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using StoreFront.Models;


namespace StoreFront
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; set; }
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json");
			Configuration = builder.Build();
		}
		public void ConfigureServices(IServiceCollection services)
		{
            services.AddMvc();
			services.AddEntityFramework()
				.AddDbContext<StoreDbContext>(options =>
					options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
		}


		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();
            app.UseStaticFiles();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}