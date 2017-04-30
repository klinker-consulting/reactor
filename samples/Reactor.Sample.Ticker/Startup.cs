using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reactor.Sample.Ticker.Quotes;
using Reactor.AspNetCore;
using Reactor.Sample.Ticker.AutoRefresh.Services;
using Reactor.Sample.Ticker.General.Http;

namespace Reactor.Sample.Ticker
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("quoteSettings.json")
                .Build();
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<AutoRefreshService>();
            services.AddTransient<IQuotesHub, QuotesHub>();
            services.AddMvc();
            services.AddSignalR();
            services.AddReactor(new State());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSignalR(b =>
            {
                b.MapHub<QuotesHub>("streams/quotes");
            });
            app.UseMvc();
            app.ApplicationServices.GetService<AutoRefreshService>().Start();
        }
    }
}
