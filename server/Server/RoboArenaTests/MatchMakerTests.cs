﻿using NUnit.Framework;
using Runner;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class MatchMakerTests
    {
        private MatchMaker m_MatchMaker;

        [SetUp]
        public void Init()
        {
            m_MatchMaker = new MatchMaker();
        }

        [Test]
        public void HasQueued()
        {
            // TODO mock database
            List<QueuedParticipant> queued = m_MatchMaker.GetQueuedParticipants();
            Assert.IsNotEmpty(queued);
        }
    }
}