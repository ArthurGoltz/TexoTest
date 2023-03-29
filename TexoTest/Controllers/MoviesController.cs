using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.ComponentModel.Design.Serialization;
using System.Text;
using TexoTest.Data;
using TexoTest.Models;
using TexoTest.Repository;
using TexoTest.Service;

namespace TexoTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _context;
        private readonly ICSVService _csvService;

        public MoviesController(IMovieRepository context, ICSVService csvService)
        {
            _context = context;
            _csvService = csvService;
        }

        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        [HttpGet("winnerIntervalResponse")]
        public async Task<IActionResult> GetMovieWinnerIntervalInfo()
        {
            return Ok(_context.GetMoviesWinnersByProducerIntervalMaxAndMin());
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> FileUpload([FromForm] IFormFileCollection file)
        {
            var moviesData = _csvService.ReadCSV<MoviesData>(file[0].OpenReadStream()).ToList();
            await _context.AddMovieList(moviesData);
            return Ok(moviesData);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
