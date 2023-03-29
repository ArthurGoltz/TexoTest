using System;
using TexoTest.Models;
using Microsoft.EntityFrameworkCore;
using TexoTest.Data;
using TexoTest.Service;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace TexoTest.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieReaderContext _context;
        public MovieRepository(MovieReaderContext context)
        {
            _context = context;
        }

        public async Task<int> AddMovieList(List<MoviesData> moviesData)
        {
            try
            {
                _context.MoviesData.AddRange(moviesData);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //implement log
                throw;
            }

        }

        public WinnerIntervalResponse GetMoviesWinnersByProducerIntervalMaxAndMin()
        {
            try
            {
                var getWinners = IntervalService.GetWinners(_context.MoviesData.ToList());

                var getProducersWithMoreThanOneWin = IntervalService.GetProducersWithMoreThanOneWin(getWinners);

                var intervalInfoList = IntervalService.getIntervalInfoWin(getProducersWithMoreThanOneWin);

                var movieProducerInterval = new WinnerIntervalResponse
                {
                    Max = new List<IntervalInfo>(),
                    Min = new List<IntervalInfo>()
                };

                movieProducerInterval.Max = intervalInfoList.Where(x => x.Interval == intervalInfoList.MaxBy(y => y.Interval).Interval).ToList();

                movieProducerInterval.Min = intervalInfoList.Where(x => x.Interval == intervalInfoList.MinBy(y => y.Interval).Interval).ToList();
                return movieProducerInterval;
            }
            catch (Exception)
            {
                //implement Log
                throw;
            }
        }


    }
}
