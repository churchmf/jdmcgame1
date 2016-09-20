(function() {
    "use strict"
    var Arena = require("../Arena"),
        Robot = require("../Robot"),
        should = require("should"),
        context = describe

    describe("Arena", function() {
        describe("#hasCollision()", function() {
            context("Robot are overlapping", function() {
                var arena = new Arena()
                var aRobot = new Robot({position: [0,0]})
                var bRobot = new Robot({position: [0,0]})

                it("should have collision", function() {
                    var hasCollision = arena.hasCollision({robots: [aRobot, bRobot]})
                    hasCollision.should.be.true
                })
            })

            context("Robot are not overlapping", function() {
                var arena = new Arena()
                var aRobot = new Robot({position: [1,0]})
                var bRobot = new Robot({position: [0,0]})

                it("should not have collision", function() {
                    var hasCollision = arena.hasCollision({robots: [aRobot, bRobot]})
                    hasCollision.should.be.false
                })
            })
        })
    })
}())