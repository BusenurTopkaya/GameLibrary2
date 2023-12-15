using GameLibray.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameLibray.Models.Dal
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GType> Types { get; set; }
        public DbSet<GCatagory> Categories { get; set; }
        public DbSet<GCountry> Countries { get; set; }
        public DbSet<GPlatform> Platforms { get; set; }
        public DbSet<GPlayerAge> PlayerAges { get; set; }
        //public DatabaseContext()
        //{
        //    Database.SetInitializer(new DatabaseBuilder());
        //}
    }
    //public class DatabaseBuilder : CreateDatabaseIfNotExists<DatabaseContext>
    //{
    //    protected override void Seed(DatabaseContext context)
    //    {
    //        //Ülkeler insert ediliyor.
    //        for (int i = 0; i < 150; i++)
    //        {
    //            GCountry country = new GCountry();
    //            country.CountryName = FakeData.PlaceData.GetCountry();

    //            context.Countries.Add(country);
    //        }

    //        context.SaveChanges();




    //    }
    //}
 }