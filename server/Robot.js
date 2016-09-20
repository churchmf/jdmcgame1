(function() {
    var Arena = require("./Arena")

    var Robot = function(params) {
        this.position = params.position
        this.facing = params.facing || Number(Arena.CARDINALITY.north)
        this.id = params.id
    }

    Robot.prototype.move = function() {
        var newPosition = this.position
        if(this.facing === Arena.CARDINALITY.north) {
            newPosition = [this.position[0], this.position[1]+1]
        } else if(this.facing === Arena.CARDINALITY.south){
            newPosition = [this.position[0], this.position[1]-1]
        } else if(this.facing === Arena.CARDINALITY.west) {
            newPosition = [this.position[0]-1, this.position[1]]
        } else {
            newPosition = [this.position[0]+1, this.position[1]]
        }
        return newPosition
    }

    module.exports = Robot
}())