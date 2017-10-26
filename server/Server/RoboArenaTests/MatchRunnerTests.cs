using NUnit.Framework;
using RoboArena;
using Runner;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class MatchRunnerTests
    {
        private MatchRunner m_MatchMaker;

        [SetUp]
        public void Init()
        {
            m_MatchMaker = new MatchRunner();
        }

        /*
        [Test]
        public void CanClaimNewMatches()
        {
            // TODO mock database
            List<Match> newMatches = m_MatchMaker.ClaimNewMatches();
            Assert.IsNotEmpty(newMatches);
        }
        */
    }
}
