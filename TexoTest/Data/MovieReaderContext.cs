using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TexoTest.Models;

namespace TexoTest.Data
{
    public class MovieReaderContext : DbContext
    {
        public MovieReaderContext(DbContextOptions<MovieReaderContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "MovieReaderDB");
        //}

        public DbSet<MoviesData> MoviesData { get; set; }
    }
}
