using RoboArena;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Runner
{
    public class MatchRunner
    {
        private MatchSimulator m_Simulator;
        private Queue<MatchResult> m_MatchResultQueue;

        private const string DatabaseConnectionString = @"Server=localhost\SQLEXPRESS;Database=RoboArena;Trusted_Connection=True;";

        public MatchRunner()
        {
            m_Simulator = new MatchSimulator();
        }

        public void Tick()
        {
            List<Match> newMatches = GetNewMatches();

            List<MatchResult> results = new List<MatchResult>();
            foreach(Match match in newMatches)
            {
                results.Add(m_Simulator.Simulate(match));
            }

            SubmitResults(results);
        }

        private List<Match> GetNewMatches()
        {
            var matches = new List<Match>();
            using (var connection = new SqlConnection(DatabaseConnectionString))
            {
                string query = @"SELECT * FROM Matches m WHERE m.Status = 0";
                var command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Match match = ReadMatch(reader);
                        matches.Add(match);
                    }
                }
            }
            // TODO query database for matches
            return new List<Match>();
        }

        private Match ReadMatch(SqlDataReader reader)
        {
            return new Match
            {
                Id = reader["id"] as string,
            };
        }

        private void SubmitResults(List<MatchResult> results)
        {
            // TODO submit results
        }
    }
}
