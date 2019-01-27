using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWhenNear : MonoBehaviour {

	[SerializeField] float distanceThreshold = 0.5f;

	HomingMovement homingMovement;
	SineMovement baseMovement;
	bool isHoming = false;
	Player player;

	void Awake(){
		player = FindObjectOfType<Player> ();
		homingMovement = GetComponent<HomingMovement> ();
		baseMovement = GetComponent<SineMovement> ();
	}

	void Update(){
		if (isHoming) {
			if (Vector3.Distance (transform.position, player.transform.position) > distanceThreshold) {
				EnableHoming (false);
			}
		} else {
			if (Vector3.Distance (transform.position, player.transform.position) < distanceThreshold) {
				EnableHoming (true);
			}
		}
	}

	void EnableHoming(bool enabled){
		baseMovement.enabled = !enabled;
		homingMovement.enabled = enabled;
		isHoming = enabled;
	}
}
