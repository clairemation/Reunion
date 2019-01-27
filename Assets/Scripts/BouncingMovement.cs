using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingMovement : Movement {

	[SerializeField] float speed = 0.05f;
	[SerializeField] float angle = 25f;

	Vector3 direction;
	Collider2D collider;
		
	void Awake(){
		collider = GetComponent<Collider2D> ();
	}

	void OnEnable(){
		Init();
	}

	void Init(){
		direction = (Quaternion.Euler (0f, 0f, angle) * Vector3.right);
		direction.Normalize ();
	}

	void FixedUpdate () {
		transform.position += direction * speed;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Obstacle")) {
			direction = Vector3.Reflect (direction, col.GetContact (0).normal);
		}
	}
}
