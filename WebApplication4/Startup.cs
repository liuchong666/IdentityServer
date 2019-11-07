using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //这里不仅要把IdentityServer注册到容器中, 还要至少对其配置三点内容:
            //1.哪些API可以使用这个authorization server.
            //2.那些客户端Client(应用)可以使用这个authorization server.
            //3.指定可以使用authorization server授权的用户.
            services.AddIdentityServer()
                 .AddInMemoryIdentityResources(Config.GetIdentityResources())
                 .AddInMemoryApiResources(Config.GetSoluction())
                 .AddTestUsers(Config.GetUsers())
                 //.AddResourceOwnerValidator()
                 .AddInMemoryClients(Config.GetClients())
                 .AddSigningCredential(new X509Certificate2(@"C:\Users\lc\Desktop\证书文件\myselfsigned.pfx", "123456"));
                 //.AddDeveloperSigningCredential();//.AddSigningCredential();.AddValidationKey()

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
