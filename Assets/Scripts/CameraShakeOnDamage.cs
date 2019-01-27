using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeOnDamage : MonoBehaviour {

	[SerializeField] float shakePower = 0.7f;
	[SerializeField] float shakeDuration = 1.0f;
	[SerializeField] float shakeSlowDownAmount = 1.0f;

	Transform camera;
	
	[HideInInspector] public bool shouldShake = false;
	
	Vector3 originalPosition;
	float initialDuration;

	void Start(){

		camera = Camera.main.transform;
		originalPosition = camera.localPosition;
		initialDuration = shakeDuration;

	}

	void Update(){

		if(shouldShake){

			if(shakeDuration > 0){

				camera.localPosition = originalPosition + Random.insideUnitSphere * shakePower;
				shakeDuration -= Time.deltaTime * shakeSlowDownAmount;

			}else{

				shouldShake = false;
				shakeDuration = initialDuration;
				camera.localPosition = originalPosition;
			}
		}
	}
}
