using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BS.Infrastructure
{
    public class BSContext:DbContext
    {


        public BSContext()
        {

        }
        public BSContext(DbContextOptions<BSContext> options) : base(options)
        {

        }

        #region Db-Set
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<AccessCard> AccessCard { get; set; }
        public virtual DbSet<AccessCardCredit> AccessCardCredit { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<ExitGates> ExitGates { get; set; }
        public virtual DbSet<Model> CarModel { get; set; }
        public virtual DbSet<Gate> Gate { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
                var connectionString = configuration.GetConnectionString("AppConnection");
                optionsBuilder.UseSqlServer(connectionString);

            }
        }
    }
}
