using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCollision : MonoBehaviour {

	/*
	if the Enemy collides with a Player it will call the
	Damage() method on the Player
	*/
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().Damage();

			Destroy(this.gameObject);
		}
	}
}
