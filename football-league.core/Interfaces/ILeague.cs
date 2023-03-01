using football_league.core.Models;

namespace football_league.core.Interfaces
{
    public interface ILeague
    {
        List<Game> Games { get; }

        void AcceptInput(string entry);

        List<string> GroupLeague();

        void CalculateLeagueOutcome();
    }
}
