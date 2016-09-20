(function() {
    "use strict"
    var GameManager = require("../GameManager"),
        Robot = require("../Robot"),
        Arena = require("../Arena"),
        should = require("should"),
        context = describe

    describe("GameManager", function() {
        describe("#executeAction()", function() {
            context("state is invalid", function() {
                var arena = new Arena()
                var aRobot = new Robot({position: [0,0]})
                var bRobot = new Robot({position: [1,0], facing: Arena.CARDINALITY.west})
                var gameManager = new GameManager({robots: [aRobot, bRobot], arena: arena})

                it("should resolve collision", function() {
                    var newPosition = bRobot.move()
                    gameManager.executeAction({ Actor: bRobot, Action: newPosition})
                    JSON.stringify(bRobot.position).should.equal(JSON.stringify([0,0]))
                    JSON.stringify(aRobot.position).should.equal(JSON.stringify([-1,0]))
                })
            })
        })
    })
}())