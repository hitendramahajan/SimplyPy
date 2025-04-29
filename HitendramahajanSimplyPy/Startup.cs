using HitendramahajanSimplyPy.Services; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; 
namespace HitendramahajanSimplyPy 
{ 
    public class Startup 
    { 
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddControllers(); 
            services.AddScoped<DataFetcherService>(); 
            services.AddScoped<PdfMergerService>(); 
        } 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        { 
            if (env.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage(); 
            } 
            app.UseRouting(); 
            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllers(); 
            }); 
        } 
    } 
}