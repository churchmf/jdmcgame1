(function() {
    var _ = require("lodash")

    var Arena = function () {
    }

    Arena.CARDINALITY = {north: 0, south: 1, east: 2, west: 3}

    Arena.prototype.hasCollision = function (params) {
        var isValid = false
        var robots = params.robots

        var positionMap = {}

        _.forEach(robots, function(robot) {
            var value = positionMap[JSON.stringify(robot.position)]
            if(!!value) {
                isValid = true
                return isValid
            }
            else
            {
                positionMap[JSON.stringify(robot.position)] = true
            }
        })
        return isValid
    }

    module.exports = Arena
}())