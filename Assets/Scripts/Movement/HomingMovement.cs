using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMovement : BaseMovement {

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
		direction = (Quaternion.Euler (0f, 0f, angle) * Vector3.right);
		direction.Normalize ();
	}

	void FixedUpdate () {
		direction = player.transform.position - transform.position;
		direction.Normalize();
		transform.position += direction * speed;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Obstacle")) {
			direction = Vector3.Reflect (direction, col.GetContact (0).normal);
		}
	}
}
