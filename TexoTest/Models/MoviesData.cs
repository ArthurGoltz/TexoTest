using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TexoTest.Models
{
    public class MoviesData
    {
        public int Year { get; set; }
        [Key]
        public string Title { get; set; }
        public string Studios { get; set; }
        public string Producers { get; set; }  
        public string Winner { get; set; }
    }
}
