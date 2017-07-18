using RoboArena;
using System.Collections.Generic;
using System.Data;
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

        public MatchResult Simulate(Match match)
        {
            return m_Simulator.Simulate(match);
        }

        /// <summary>
        /// Pops new matches from database
        /// </summary>
        /// <returns></returns>
        public List<Match> ClaimNewMatches()
        {
            var matches = new List<Match>();
            using (var connection = new SqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Claim_New_Matches", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matches.Add(ReadMatch(reader));
                        }
                    }
                }
                
            }
            return matches;
        }

        private Match ReadMatch(SqlDataReader reader)
        {
            return new Match
            {
                Id = reader["id"] as int?,
                Seed = reader["seed"] as int?
            };
        }
    }
}
