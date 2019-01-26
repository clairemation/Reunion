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


	/* 
	The Hearts, Game Over Panel, and Reset Button
	will most likely be controlled by a Game Manager later
	 */
	[Header("Hearts")]
	[SerializeField] GameObject[] hearts;

	[Header("Game Over Panel")]
	[SerializeField] GameObject gameOverPanel;

	[Header("Reset Button")]
	[SerializeField] GameObject resetButton;

	float speed;
	int health;

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
		float vert = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float hori = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate(hori, vert, 0f);
	}

	public void Damage()
	{
		health --;
		hearts[health].SetActive(false);

		if(health <= 0)
		{
			//Game Over
			Debug.Log("Game Over");
			gameOverPanel.SetActive(true);
			resetButton.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
