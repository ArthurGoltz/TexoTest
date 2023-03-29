using TexoTest.Models;

namespace TexoTest.Repository
{
    public interface IMovieRepository
    {
        public Task<int> AddMovieList(List<MoviesData> moviesData);
        public WinnerIntervalResponse GetMoviesWinnersByProducerIntervalMaxAndMin();
    }
}   