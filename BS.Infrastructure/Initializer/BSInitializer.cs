using BS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public static class BSInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Brand>().HasData(new Brand 
            {
                Id=1,
                Models=new List<Model>
                {
                    new Model { Id = 1,ModelName = "Accent"},
                    new Model { Id = 1, ModelName = "Elentra" },
                    new Model { Id = 1, ModelName = "Verna" }
                },
                BrandName = "Hyundai"
            });


            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 2,
                Models = new List<Model>
                {
                    new Model { Id = 1,ModelName = "X5"},
                    new Model { Id = 1, ModelName = "X6" },
                    new Model { Id = 1, ModelName = "X4" }
                },
                BrandName = "BMW"
            });


            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 3,
                Models = new List<Model>
                {
                    new Model { Id = 1,ModelName = "Astra"},
                    new Model { Id = 1, ModelName = "Corsa" },
                    new Model { Id = 1, ModelName = "Victra" }
                },
                BrandName = "Opel"
            });
        }
    }
}
