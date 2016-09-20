(function() {
    "use strict"

    var Robot = require("../Robot"),
        Arena = require("../Arena")
        should = require("should"),
        context = describe

    describe("Robot", function() {
        describe("#move()", function() {
            var originalPosition,
                robot

            beforeEach(function() {
                originalPosition = [0,0]
                robot = new Robot({position: originalPosition})
            })

            it("should update it's position", function() {
                robot.move()
                JSON.stringify(robot.position).should.not.equal(JSON.stringify(originalPosition))
            })

            context("Robot is facing north", function() {
                it("should increase it's y-coord", function() {
                    robot.move()
                    JSON.stringify(robot.position).should.equal(JSON.stringify([0,1]))
                })
            })

            context("Robot is facing south", function() {
                beforeEach(function() {
                    robot.facing = Arena.CARDINALITY.south
                })

                it.only("should decrease it's y-coord", function() {
                    robot.move()
                    JSON.stringify(robot.position).should.equal(JSON.stringify([0,-1]))
                })
            })

            context("Robot is facing west", function() {
                beforeEach(function() {
                    robot.facing = Arena.CARDINALITY.west
                })

                it.only("should decrease it's x-coord", function() {
                    robot.move()
                    JSON.stringify(robot.position).should.equal(JSON.stringify([-1,0]))
                })
            })

            context("Robot is facing east", function() {
                beforeEach(function() {
                    robot.facing = Arena.CARDINALITY.east
                })

                it.only("should increase it's x-coord", function() {
                    robot.move()
                    JSON.stringify(robot.position).should.equal(JSON.stringify([1,0]))
                })
            })
        })
    })
}())