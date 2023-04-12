using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
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

        public MoviesController(IMovieRepository context)
        {
            _context = context;
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
