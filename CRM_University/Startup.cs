using CRM_University.Core.Interfaces;
using CRM_University.Data.Context;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM_University
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
            var CRMConString = Configuration["Data:CRM_University:ConnectionString"];
            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(CRMConString));
            services.AddControllersWithViews();
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Group>, GroupRepository>();
            services.AddTransient<IRepository<Subject>, SubjectRepository>();
            services.AddTransient<IRepository<Tuition>, TutionRepository>();
            services.AddTransient<IRepository<Faculty>, FacultyRepository>();
            services.AddTransient<IRepository<Examination>, ExaminationRepository>();
            services.AddTransient<IRepository<Assessment>, AssessmentRepository>();
            services.AddTransient<IRepository<StudentSubject>, StudentSubjectRepository>();
            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
