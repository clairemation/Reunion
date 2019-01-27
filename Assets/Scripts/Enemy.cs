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

			Destroy(this.gameObject);
		}
	}
}
