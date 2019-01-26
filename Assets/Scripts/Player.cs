using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Stats")]
	public int health = 3;
	public float speed;

	[Header("Controls")]
	public KeyCode walkRight;
	public KeyCode walkLeft;
	public KeyCode walkUp;
	public KeyCode walkDown;

	void FixedUpdate () {
		Move ();
	}

	void Move () {
		float vert = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float hori = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate(hori, vert, 0f);
	}
}
