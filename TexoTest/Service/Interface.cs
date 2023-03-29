using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;
using TexoTest.Mappers;

namespace TexoTest.Service
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
    }

    public class CSVService : ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLowerInvariant(),
                Delimiter = ";",
                HasHeaderRecord = true
                
            };
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, csvConfig);
            csv.Context.RegisterClassMap<MovieMapper>();
            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
