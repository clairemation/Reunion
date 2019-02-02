using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Stats")]
	[SerializeField] int baseHealth = 3;
	[SerializeField] float baseSpeed;
	[SerializeField] GameObject instantSFX;
	[SerializeField] AudioClip hurtSound;
	[SerializeField] AudioClip shieldSound;

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
	Animator anim;
	float speed;
	int health;

	bool shieldActive = false;

	void Start(){
		health = baseHealth;
		speed = baseSpeed;
		renderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();
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
		anim.SetBool ("shield", true);
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
			anim.SetBool ("shield", false);

			GameObject temp = Instantiate(instantSFX, transform.position, Quaternion.identity);
			temp.GetComponent<PlaySoundAndDie>().Activate(shieldSound);
			//Change protagonist sprite back to normal
		}
		else
		{
			health --;
			hearts[health].gameObject.SetActive(false);

      		cameraShake.shouldShake = true;
			StartCoroutine(Flashing());

			GameObject temp = Instantiate(instantSFX, transform.position, Quaternion.identity);
			temp.GetComponent<PlaySoundAndDie>().Activate(hurtSound);

			if(health <= 0)
			{
				GameOver ();

			}
		}
	}

	void GameOver(){
		Debug.Log ("Game Over");
		Time.timeScale = 0f;
		cameraShake.StopShaking ();
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

	public void StopFlashing(){
		StopAllCoroutines ();
		renderer.enabled = true;
	}
}
