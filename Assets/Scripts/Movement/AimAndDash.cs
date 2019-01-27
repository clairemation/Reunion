using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndDash : MonoBehaviour {

	WanderMovement wanderMovement;
	DashingMovement dashingMovement;
	GameObject player;

	int counter;
	float countdown;

	void Awake(){
		wanderMovement = GetComponent<WanderMovement> ();
		dashingMovement = GetComponent<DashingMovement> ();
		player = GameObject.FindWithTag ("Player");
		Init ();
	}

	void Init(){
		counter = 0;
		SetCountdown ();
	}

	void FixedUpdate(){
		countdown -= Time.deltaTime;
		if (countdown <= 0f) {
			if (counter >= 2) {
				StartCoroutine (FreezeThenDash ());
				counter = 0;
			}
			wanderMovement.SetRandomDirection ();
			SetCountdown ();
			counter++;
		}
	}

	IEnumerator FreezeThenDash(){
		wanderMovement.enabled = false;
		yield return new WaitForSeconds (1f);
		dashingMovement.enabled = true;
		yield return new WaitForSeconds (1.5f);
		dashingMovement.enabled = false;
		wanderMovement.enabled = true;
	}

	void SetCountdown(){
		countdown = Random.Range (2f, 3f);
	}
}
