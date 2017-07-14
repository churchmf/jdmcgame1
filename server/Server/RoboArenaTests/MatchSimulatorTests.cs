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
            var participantIds = new List<string> { "1234", "4321" };
            Match match = m_Simulator.Create(participantIds);

            Assert.True(match.Participants.Select(p => p.Data.Id).OrderBy(x => x).SequenceEqual(participantIds.OrderBy(x => x)));
            Assert.IsNotNull(match.World);
        }

        [Test]
        public void SimulateMatchDraw()
        {
            var participantIds = new List<string> { "1234", "4321" };
            Match match = m_Simulator.Create(participantIds);

            MatchResult result = m_Simulator.Simulate(match);
            Assert.AreEqual(result.WinnerId, String.Empty);
        }
    }
}

