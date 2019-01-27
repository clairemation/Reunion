using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingMovement : BaseMovement {

	[SerializeField] float speed = 0.02f;
	[SerializeField] float angle = 25f;
	Vector3 direction;

	Player player;

	void Awake(){
		player = FindObjectOfType<Player> ();
	}

	void OnEnable(){
		Init();
	}

	void Init(){
		direction = player.transform.position - transform.position;
		direction.Normalize ();
	}

	void FixedUpdate () {
		transform.position += direction * speed;
	}
}
