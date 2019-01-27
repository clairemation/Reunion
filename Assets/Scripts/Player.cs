using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
	[SerializeField] Image[] hearts;

	[SerializeField] GameObject gameOverPanel;

	[SerializeField] Button resetButton;

	SpriteRenderer renderer;

	float speed;
	int health;

	void Start(){
		health = baseHealth;
		speed = baseSpeed;

		renderer = GetComponent<SpriteRenderer>();
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

	public void TakeDamage()
	{
		health --;
		hearts[health].gameObject.SetActive(false);

		StartCoroutine(Flashing());

		if(health <= 0)
		{
			gameOverPanel.SetActive(true);
			resetButton.gameObject.SetActive(true);
			Destroy(this.gameObject);
		}
	}

	IEnumerator Flashing()
	{
		gameObject.tag = "Invincible";

		for(int n = 0; n < 11; n++)
		{
			yield return new WaitForSeconds(0.2f);
			renderer.enabled = (n%2 == 0);
		}
		gameObject.tag = "Player";
	}
}
