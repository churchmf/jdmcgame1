using NUnit.Framework;
using RoboArena;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoboArenaTests
{
    [TestFixture]
    public class MatchSimulatorTests
    {
        private MatchSimulator m_Simulator;

        [SetUp]
        public void Init()
        {
            m_Simulator = new MatchSimulator();
        }

        [Test]
        public void CreateMatch()
        {
            var participantIds = new List<string> { "A", "B" };
            Match match = m_Simulator.Create(participantIds);

            Assert.True(match.Participants.Select(p => p.Data.Id).OrderBy(x => x).SequenceEqual(participantIds.OrderBy(x => x)));
            Assert.IsNotNull(match.World);
        }

        [Test]
        public void SimulateMatch()
        {
            var participantIds = new List<string> { "A", "B" };
            Match match = m_Simulator.Create(participantIds);

            MatchResult result = m_Simulator.Simulate(match);
            Assert.IsNotNull(result);
        }
    }
}

