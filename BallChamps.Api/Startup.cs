using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using System.Text;
using BallChampsApi.Models;
using BallChampsApi.Services;
using DataLayer.BallChamps;

namespace BallChampsApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        string BallChampsConnectionString;

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //BallChamps
            BallChampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");

        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSignalRCore();
            // Register the Swagger generator, defining one or more Swagger documents  
            services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(XmlCommentsFilePath);

            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            //services.AddControllers();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JWT Authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);

            services.AddAuthentication(au =>
            {

                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {

                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });

            services.AddScoped<IAuthenticateService, AuthenticateService>();

            //BallChamps
            services.AddDbContextPool<BallChampsDBContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<ProfileContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<BlogContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<UserContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CourtContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CommentContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CourtWaitingListContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<ProductContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<FollowersContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<PostContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<GameHistoryContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<AdminSettingsContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<InboxContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CommentContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<RateContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<RuleContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<GameDetailContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<EventContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<SquadContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<NewsFeedContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<NotificationContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CampaignContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<UserSettingContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<CourtPlayerBetContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<PrivateRunContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<PlayerHistoryContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<PlayerInviteContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));
            services.AddDbContextPool<ReserveCourtContext>(opitons => opitons.UseSqlServer(BallChampsConnectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<ChatHub>("ChatHub");
            });
        }

        private class GetTypeInfo
        {
        }
    }
}
