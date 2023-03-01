using football_league.core.Interfaces;
using football_league.core.Models;

namespace football_league.core.Implementation
{
    public class League : ILeague
    {
        public List<Game> Games { get; private set; } = new List<Game>();

        public Dictionary<int, List<Game>> Matches { get; private set; } = new Dictionary<int, List<Game>>();

        public League()
        {

        }

        public void AcceptInput(string entry)
        {
            var countries = entry.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var games = new List<Game>();

            foreach (var country in countries)
            {
                var idx = country.LastIndexOf(" ");

                var c = country[..idx];
                var s = country[(idx + 1)..];

                games.Add(new Game
                {
                    Country = c.Trim(),
                    Score = Convert.ToInt32(s.Trim()),
                    Identifier = country
                });
            }

            Matches.Add(Matches.Count + 1, new List<Game> { games[0], games[1] });
            Games.AddRange(games);
        }

        public List<string> GroupLeague()
        {
            var output = new Dictionary<string, int>();
            var grouped = Games.GroupBy(x => x.Country).ToList();

            foreach (var group in grouped)
            {
                var country = group.Key;
                var point = group.Sum(x => x.Points);

                output.Add(country, point);
            }

            return output.OrderByDescending(x => x.Value)
                .Select(x => $"{x.Key} {x.Value}")
                .ToList();
        }

        public void CalculateLeagueOutcome()
        {
            foreach (var kvp in Matches)
            {
                var player1 = kvp.Value[0];
                var player2 = kvp.Value[1];

                if (player1.Score == player2.Score)
                {
                    // BOTH gets 1 point
                    Games.First(x => x.Identifier == player1.Identifier).Points = 1;
                    Games.First(x => x.Identifier == player2.Identifier).Points = 1;
                }
                else if (player1.Score > player2.Score)
                {
                    // Player1 gets the win
                    Games.First(x => x.Identifier == player1.Identifier).Points = 3;
                    Games.First(x => x.Identifier == player2.Identifier).Points = 0;
                }
                else if (player1.Score < player2.Score)
                {
                    // Player2 gets the win
                    Games.First(x => x.Identifier == player2.Identifier).Points = 0;
                    Games.First(x => x.Identifier == player2.Identifier).Points = 3;
                }
            }
        }
    }
}