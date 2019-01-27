using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] AudioClip walkingSound;
	[SerializeField] AudioClip hitSound;
	[SerializeField] AudioClip spawnSound;

	AudioSource audioSource;

	/*
	if the Enemy collides with a Player it will call the
	Damage() method on the Player
	*/

	void Awake(){
		audioSource = GetComponent<AudioSource>();

		audioSource.clip = walkingSound;
		audioSource.loop = true;
		audioSource.Play();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Player>().TakeDamage();

			PlayHitSoundAndDie();
		}
	}

	void PlayHitSoundAndDie(){
		Destroy(GetComponent<SpriteRenderer>());
		Destroy(GetComponent<Collider>());
		Destroy(GetComponent<Rigidbody>());
		StartCoroutine(PlayHitSoundAndDieCoroutine(hitSound));
	}

	IEnumerator PlayHitSoundAndDieCoroutine (AudioClip sound) {
		audioSource.clip = sound;
		audioSource.loop = false;
		audioSource.Play();
		yield return new WaitForSeconds(sound.length);
		Destroy(this.gameObject);
	}
}
