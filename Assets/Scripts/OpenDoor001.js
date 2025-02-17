﻿import UnityEngine.UI;

var TextDisplay : GameObject;
var TheDistance : float = PlayerCasting.DistanceFromTarget;

var TheDoor : GameObject;

var ObjectiveComplete : GameObject;


function Update() {
	TheDistance = PlayerCasting.DistanceFromTarget;

}

function OnMouseOver() {
	if (TheDistance <= 2) {
		TextDisplay.GetComponent.<Text>().text = "Press Button";
	}
	if(Input.GetButtonDown("Action")){
		if(TheDistance <= 2) {
			OpenTheDoor();
			ObjectiveComplete.SetActive(true);
		}
	}
}

function OnMouseExit() {
	TextDisplay.GetComponent.<Text>().text = "";
}

function OpenTheDoor () {
	TheDoor.GetComponent("Animator").enabled = true;
	yield WaitForSeconds(1);
	TheDoor.GetComponent("Animator").enabled = false;
	yield WaitForSeconds(5);
	TheDoor.GetComponent("Animator").enabled = true;
	yield WaitForSeconds(1);
	TheDoor.GetComponent("Animator").enabled = false;

}