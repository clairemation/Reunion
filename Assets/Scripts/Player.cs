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

	[Header("Main Camera")]
	[SerializeField] private CameraShakeOnDamage cameraShake;


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

	bool shieldActive = false;

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

	public void HealthRestore()
	{
		if(health < 3)
		{
			hearts[health].gameObject.SetActive(true);
			health ++;
		}
	}

	public void ShieldActivated()
	{
		Debug.Log("Shield On");
		shieldActive = true;
		//Change protagonist sprite to have shield
	}

	void CheckMovement () {
		float vert = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float hori = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate(hori, vert, 0f);
	}

	public void TakeDamage()
	{
		if(shieldActive)
		{
			Debug.Log("Shield Off");
			shieldActive = false;
			//Change protagonist sprite back to normal
		}
		else
		{
			health --;
			hearts[health].gameObject.SetActive(false);

      cameraShake.shouldShake = true;
			StartCoroutine(Flashing());

			if(health <= 0)
			{
				//Game Over
				Debug.Log("Game Over");
				gameOverPanel.gameObject.SetActive(true);
				resetButton.gameObject.SetActive(true);
				Destroy(this.gameObject);
			}
		}
	}

	void GameOver(){
		Time.timeScale = 0f;
		gameOverPanel.SetActive(true);
		resetButton.gameObject.SetActive(true);
		Destroy(this.gameObject);
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
