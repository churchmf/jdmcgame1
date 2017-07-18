using NUnit.Framework;
using RoboArena;
using System.Collections.Generic;
using System.Linq;

namespace Tests
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
        public void CanSimulateMatch()
        {
            var participantIds = new List<string> { "A", "B" };
            Match match = m_Simulator.Create(participantIds);

            MatchResult result = m_Simulator.Simulate(match);
            Assert.IsNotNull(result);
        }
    }
}

