/* Observaçoes:
 * 
 * Dependence Injection
 * - Services, Repositories e DbContext
 * 
 * Lazy Loading Data: Não usando.
 *	- habilitado usando VIRTUAL 
 *	- 3 Jeitos: https://docs.microsoft.com/en-us/ef/core/querying/related-data/#lazy-loading-without-proxies
 * 
 * 
 * 
 * 
 * 
 */


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Repository.Repositories;
using VENTURA_HR.Services.AuthServices;
using VENTURA_HR.Services.UsuarioServices;
using VENTURA_HR.Services.VagaServices;
using VENTURA_HT.Repository.Context;
using VENTURA_HT.Repository.Repositories;

namespace VENTURA_HR.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//database context DI
			services.AddDbContext<VenturaContext>(DbCtxBuilder =>
			{
				DbCtxBuilder.UseSqlServer(Configuration.GetConnectionString("ConnStr"));
			});

			//repositories DI
			services.AddTransient<IUsuarioRepository, UsuarioRepository>();
			services.AddTransient<ICandidatoRepository, CandidatoRepository>();
			services.AddTransient<IEmpresaRepository, EmpresaRepository>();
			services.AddTransient<IAdministradorRepository, AdministradorRepository>();
			services.AddTransient<IEmpresaRepository, EmpresaRepository>();
			services.AddTransient<ICandidatoRepository, CandidatoRepository>();
			services.AddTransient<IVagaRepository, VagaRepository>();
			services.AddTransient<ICriterioRepository, CriterioRepository>();

			//services DI
			services.AddTransient<AuthService>();
			services.AddTransient<IVagaService, VagaService>();
			services.AddTransient<ICriterioService, CriterioService>();
			services.AddTransient<IUsuarioService, UsuarioService>();
			services.AddTransient<IEmpresaService, EmpresaService>();
			services.AddTransient<ICandidatoService, CandidatoService>();


			services.AddCors();
			services.AddControllers()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				})
				.AddJsonOptions(opt =>
				{
					opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				});


			//TODO: PASSA PARA SERVICE PROJECT
			var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("secret"));
			//Token config schema (Bearer)
			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				//Token: Tipo e Config
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;

					// Precisa validar a chave (simetrica)
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),

						// Não vamos usar uma aplicaçao distribuida pra outras.
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//Validate Database is created.
			//using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			//{
			//	var context = serviceScope.ServiceProvider.GetRequiredService<VenturaContext>();
			//	//context.Database.Migrate();
			//	//context.Database.EnsureCreated();
			//}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyOrigin());

			//Auth Configs
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
