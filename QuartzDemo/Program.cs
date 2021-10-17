using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using QuartzDemo.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using QuartzDemo.Jobs;
using Quartz.Spi;
using QuartzDemo.Scheduler;
using Quartz;
using Quartz.Impl;
using QuartzDemo.JobFactory;

namespace QuartzDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    /*services.AddDbContext<FloristDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FlowerShop")));*/
                    var optionsBuilder = new DbContextOptionsBuilder<FloristDbContext>();
                    optionsBuilder.UseSqlServer("Server=DESKTOP-29MCA4L;Database=FlowerShop;Trusted_Connection=True");
                    services.AddScoped<FloristDbContext>(f => new FloristDbContext(optionsBuilder.Options));
                    /*services.AddHostedService<Worker>();*/


                    services.AddSingleton<IJobFactory, MyJobFactory>();
                    services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

                    #region Adding JobType
                    services.AddSingleton<MoreLillies>();
                   
                    #endregion

                    #region Adding Jobs 
                    List<JobMetadata> jobMetadatas = new List<JobMetadata>();
                    jobMetadatas.Add(new JobMetadata(Guid.NewGuid(), typeof(MoreLillies), "Add More Lillies Job", "0/10 * * * * ?"));

                    services.AddSingleton(jobMetadatas);
                    #endregion

                    services.AddHostedService<QuartzSchedular>();
                });
    }
}
