using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Client;
using PracticalTest.Core.Repositories.Invoice;
using PracticalTest.Core.Repositories.Loan;
using PracticalTest.Core.Services;
using PracticalTest.Repository;
using PracticalTest.Repository.Repositories.Client;
using PracticalTest.Repository.Repositories.Invoice;
using PracticalTest.Repository.Repositories.Loan;
using PracticalTest.Service.Mapping;
using PracticalTest.Service.Services;
using PracticalTest.Service.Validators;

namespace PracticalTest.UI
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
            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<LoanInsertDtoValidator>());
            services.AddDbContext<LoanDbContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("LoanDb"));
            });

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ILoanRepository,LoanRepository>();
            services.AddScoped<IInvoiceRepository,InvoiceRepository>();
            services.AddScoped<IUniteOfWork, UniteOfWork>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
