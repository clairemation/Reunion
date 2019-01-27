using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseItem : MonoBehaviour {

	[SerializeField] AudioClip sfx;
	[SerializeField] GameObject instantSFX;

	protected void Awake(){
		GetComponent<Collider2D>().isTrigger = true;
	}

	protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			Activate(coll.gameObject.GetComponent<Player>());
			GameObject temp = Instantiate(instantSFX, transform.position, Quaternion.identity); 
			temp.GetComponent<PlaySoundAndDie>().Activate(sfx);
			Destroy(gameObject);
		}
	}

	protected abstract void Activate(Player player);
}
