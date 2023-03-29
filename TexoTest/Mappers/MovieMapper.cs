using CsvHelper.Configuration;
using System.Globalization;
using TexoTest.Models;

namespace TexoTest.Mappers
{
    public sealed class MovieMapper : ClassMap<MoviesData>
    {
        public MovieMapper()
        {
            Map(m => m.Year).Name("year");
            Map(m => m.Title).Name("title");
            Map(m => m.Studios).Name("studios");
            Map(m => m.Producers).Name("producers");
            Map(m => m.Winner).Name("winner");
        }
    }
}
