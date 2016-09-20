(function() {
    var Arena = require("./Arena")
    var _ = require("lodash")

    var GameManager = function (params) {
        this.robots = params.robots
        this.arena = params.arena
    }

    GameManager.prototype.executeAction = function (params) {
        var actor = params.Actor
        var action = params.Action

        var clone = _.cloneDeep(this.robots)
        // TODO execute action

        arena.hasCollision(this.robots)
    }

    module.exports = GameManager
}())