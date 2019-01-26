using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour {

	protected void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			Activate(coll.gameObject.GetComponent<Player>());
		}
	}

	protected abstract void Activate(Player player);
}
