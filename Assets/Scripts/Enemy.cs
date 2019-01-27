using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] AudioClip walkingSound;
	[SerializeField] AudioClip hitSound;
	[SerializeField] AudioClip spawnSound;
	[SerializeField] GameObject instantSFX;

	AudioSource audioSource;

	/*
	if the Enemy collides with a Player it will call the
	Damage() method on the Player
	*/

	void Awake(){
		audioSource = GetComponent<AudioSource>();
		StartCoroutine(PlaySpawnSoundThenWalking());
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Player> ().TakeDamage ();
			Die ();
		}
	}

	void Die(){
		GameObject deathSFXObj = Instantiate(instantSFX, transform.position, Quaternion.identity);
		deathSFXObj.GetComponent<PlaySoundAndDie>().Activate(hitSound);
		Destroy(gameObject);
	}

	IEnumerator PlaySpawnSoundThenWalking(){
		audioSource.clip = spawnSound;
		audioSource.Play();
		yield return new WaitForSeconds(spawnSound.length);
		audioSource.clip = walkingSound;
		audioSource.loop = true;
		audioSource.Play();
	}
}
