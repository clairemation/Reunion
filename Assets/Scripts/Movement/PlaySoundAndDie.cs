using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAndDie : MonoBehaviour {

	public void Activate(AudioClip clip){
		AudioSource source = GetComponent<AudioSource>();
		source.clip = clip;
		source.loop = false;
		source.Play();
		StartCoroutine(DieAfterSeconds(clip.length));
	}

	IEnumerator DieAfterSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
