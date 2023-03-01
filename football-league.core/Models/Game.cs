namespace football_league.core.Models
{
    public class Game
    {
        public string Country { get; set; } = string.Empty;

        public int Score { get; set; }

        public int Points { get; set; }

        public string Identifier { get; set; } = string.Empty;
    }
}
