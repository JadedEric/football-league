using football_league.core.Implementation;

namespace football_league.tests
{
    [TestClass()]
    public class LeagueTests
    {
        List<string> matches;
        League league;

        [TestInitialize()]
        public void Initialize()
        {
            matches = new List<string>()
            {
                "Spain 3, Portugal 3",
                "Argentina 1, South Africa 0",
                "Spain 1, South Africa 1",
                "Argentina 3, Portugal 1",
                "Spain 4, India 0"
            };

            league = new League();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            league.Games.Clear(); 
            league.Matches.Clear();
        }

        [TestMethod()]
        public void Can_Accept_User_Input_and_Store()
        { 
            foreach (var item in matches)
            {
                league.AcceptInput(item);
            }

            // each country is now a separate entry
            Assert.AreEqual(league.Games.Count, 10);

            // each match is uniquely identifiable so we can calculate the necessary scores
            Assert.AreEqual(league.Matches.Count, 5);
        }

        [TestMethod()]
        public void Can_Calculate_League_Outcomes_Per_Match()
        {
            foreach (var item in matches)
            {
                league.AcceptInput(item);
            }

            league.CalculateLeagueOutcome();

            Assert.AreEqual(league.Games[0].Points, 1);
            Assert.AreEqual(league.Games[1].Points, 1);
        }

        [TestMethod()]
        public void Can_Group_League()
        {
            foreach (var item in matches)
            {
                league.AcceptInput(item);
            }

            league.CalculateLeagueOutcome();

            var actual = league.GroupLeague();

            var expected = new List<string>
            {
                "Argentina 6",
                "Spain 5",
                "Portugal 1",
                "South Africa 1",
                "India 0"
            };

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
