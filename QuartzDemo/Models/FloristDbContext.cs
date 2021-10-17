using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzDemo.Models
{
    class FloristDbContext:DbContext
    {
        public FloristDbContext(DbContextOptions<FloristDbContext> options) : base(options)
        {

        }

        public  DbSet<Flower> Flowers { get; set; }
    }
}
