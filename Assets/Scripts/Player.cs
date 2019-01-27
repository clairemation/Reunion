using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Stats")]
	[SerializeField] int baseHealth = 3;
	[SerializeField] float baseSpeed;

	[Header("Controls")]
	[SerializeField] KeyCode walkRight;
	[SerializeField] KeyCode walkLeft;
	[SerializeField] KeyCode walkUp;
	[SerializeField] KeyCode walkDown;

	float speed;
	float health;

	void Start(){
		health = baseHealth;
		speed = baseSpeed;
	}

	void FixedUpdate () {
		CheckMovement ();
	}

	public void TimedSpeedIncrease (float seconds, float multiplier) {
		float increase = multiplier * baseSpeed - baseSpeed;
		StartCoroutine(IncreaseSpeedForSeconds(increase, seconds));
	}

	IEnumerator IncreaseSpeedForSeconds (float increase, float seconds) {
		speed += increase;
		yield return new WaitForSeconds(seconds);
		speed -= increase;
	}

	void CheckMovement () {
		float vert = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		float hori = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		transform.Translate(hori, vert, 0f);
	}
}
