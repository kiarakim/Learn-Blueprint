﻿static var CurrentScore : int;
var InternalScore : int;

var ScoreText : GameObject;

function Update() {
	InternalScore = CurrentScore;
	ScoreText.GetComponent.<Text>().text = "" + InternalScore;
}