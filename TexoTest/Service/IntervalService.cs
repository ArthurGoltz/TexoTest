using Microsoft.EntityFrameworkCore;
using TexoTest.Models;

namespace TexoTest.Service
{
    public static class IntervalService
    {

        public static List<MoviesData> GetWinners(List<MoviesData> moviesData)
        {
            return moviesData.Where(x => x.Winner == "yes").ToList();
        }

        public static Dictionary<string, List<MoviesData>> GetProducersWithMoreThanOneWin(List<MoviesData> moviesData)
        {
            return moviesData.GroupBy(x => x.Producers).Where(x => x.Count() > 1).ToDictionary(group => group.Key, group => group.ToList());
        }

        public static List<IntervalInfo> getIntervalInfoWin(Dictionary<string, List<MoviesData>> getProducersWithMoreThanOneWin)
        {
            var intervalInfoList = new List<IntervalInfo>();
            foreach (var producer in getProducersWithMoreThanOneWin.Keys)
            {
                var moviesData = getProducersWithMoreThanOneWin[producer].OrderBy(x => x.Year).ToList();

                var firstWin = moviesData[0].Year;

                var lastWin = moviesData[1].Year;

                var interval = Math.Abs(lastWin - firstWin);

                var intervalInfo = new IntervalInfo();
                intervalInfo.Producer = producer;
                intervalInfo.Interval = interval;
                intervalInfo.PreviousWin = firstWin;
                intervalInfo.FollowingWin = lastWin;
                intervalInfoList.Add(intervalInfo);
            }
            return intervalInfoList;
        }
    }
}
