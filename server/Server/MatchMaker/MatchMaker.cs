﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Runner
{
    public class MatchMaker
    {
        private const string DatabaseConnectionString = @"Server=localhost\SQLEXPRESS;Database=RoboArena;Trusted_Connection=True;";

        public void MatchQueued(params QueuedParticipant[] participants)
        {
            using (var connection = new SqlConnection(DatabaseConnectionString))
            {
                connection.Open();

                int matchId = 0;
                using (var command = new SqlCommand("Create_Match", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.AddWithValue("@seed", Guid.NewGuid().GetHashCode());
                    matchId = (int) command.ExecuteScalar();
                }

                foreach (QueuedParticipant participant in participants)
                {
                    string query = @"INSERT INTO MatchParticipant(MatchId, ParticipantId)
                                     VALUES (@match, @participant)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@match", matchId);
                    command.Parameters.AddWithValue("@participant", participant.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Pops participants from database
        /// </summary>
        /// <returns></returns>
        public List<QueuedParticipant> ClaimQueuedParticipants()
        {
            var queued = new List<QueuedParticipant>();
            using (var connection = new SqlConnection(DatabaseConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Claim_Queued_Participants", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            queued.Add(ReadQueuedParticipant(reader));
                        }
                    }
                }
            }
            return queued;
        }

        private QueuedParticipant ReadQueuedParticipant(SqlDataReader reader)
        {
            return new QueuedParticipant
            {
                Id = reader["Id"] as int?,
            };
        }
    }

    public class QueuedParticipant
    {
        public int? Id { get; set; }
    }
}
