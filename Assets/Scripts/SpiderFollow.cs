﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour {

	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedRange = 20;
	public GameObject TheEnemy;
	public float EnemySpeed;
	public int AttackTrigger;
	public RaycastHit Shot;

	public int IsAttacking;
	public GameObject ScreenFlash;
	public AudioSource Hurt01;
	public AudioSource Hurt02;
	public AudioSource Hurt03;
	public int PainSound;

	void Update() {
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) {
				EnemySpeed = 0.03f;
				if (AttackTrigger == 0) {
					TheEnemy.GetComponent<Animation> ().Play ("walk");
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
				}
			} 
			else {
				EnemySpeed = 0;
				TheEnemy.GetComponent<Animation> ().Play ("idle");
			}
		}

		if (AttackTrigger == 1) {
			if (IsAttacking == 0) {
				StartCoroutine (EnemyDamage ());
			}
			EnemySpeed = 0;
			TheEnemy.GetComponent<Animation> ().Play ("attack");
		}
	}

	void OnTriggerEnter() {
		AttackTrigger = 1;
	}

	void OnTriggerExit() {
		AttackTrigger = 0;
	}

	IEnumerator EnemyDamage() {
		IsAttacking = 1;
		PainSound = Random.Range (1, 4);
		yield return new WaitForSeconds (0.4f);
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 2;
		if (PainSound == 1) {
			Hurt01.Play ();
		}
		if (PainSound == 2) {
			Hurt02.Play ();
		}
		if (PainSound == 3) {
			Hurt03.Play ();
		}
		yield return new WaitForSeconds (0.05f);
		ScreenFlash.SetActive (false);
		yield return new WaitForSeconds (0.75f);
		IsAttacking = 0;
	
	}
}
