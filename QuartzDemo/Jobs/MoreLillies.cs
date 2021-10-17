using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using QuartzDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Jobs
{
    public class MoreLillies : IJob
    {
        private readonly ILogger<MoreLillies> _logger;
        private readonly IServiceScopeFactory _service;
        public MoreLillies(IServiceScopeFactory service, ILogger<MoreLillies> logger)
        {
            _logger = logger;
            _service = service;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                using( IServiceScope scope  = _service.CreateScope())
                {
                    FloristDbContext dbcontext = scope.ServiceProvider.GetRequiredService<FloristDbContext>();
                    Flower lily = new Flower() { FlowerName = "Lily", WhenAdded = DateTime.Now };
                    dbcontext.Flowers.Add(lily);
                    dbcontext.SaveChanges();
                }
                _logger.LogInformation("We added more Lilles :) :) ");
            }
            catch
            {
                _logger.LogInformation("Failed to add Flowers!!!");
            }
            return Task.CompletedTask;
        }
    }
}
