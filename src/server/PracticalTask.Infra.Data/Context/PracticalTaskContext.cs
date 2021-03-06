﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracticalTask.Domain.Models;
using PracticalTask.Infra.Data.Mappings;


namespace PracticalTask.Infra.Data.Context
{
    public class PracticalTaskContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            // define the database to use
            //for SQlLite insted of SQLCompact
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
    }
}
