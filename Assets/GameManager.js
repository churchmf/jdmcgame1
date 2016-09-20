#pragma strict
var robots = [];
var tiles = [];

function Start () {
    robots[robots.length] = ( new Robot() );
}

function Update () {

}

function Robot() {
    this.position;
}

function Tile() {
    this.coords = new Vector2();
}