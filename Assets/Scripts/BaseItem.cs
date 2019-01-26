using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseItem : MonoBehaviour {

	protected void Awake(){
		GetComponent<Collider2D>().isTrigger = true;
	}

	protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			Activate(coll.gameObject.GetComponent<Player>());
		}
		Destroy(gameObject);
	}

	protected abstract void Activate(Player player);
}
