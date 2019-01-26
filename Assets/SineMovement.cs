using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {
	
	[SerializeField] float angle = 0f;
	[SerializeField] float initialCurveAmplitude = 0.5f;

	Quaternion angleOffset;
	float progress;
	float curveAmplitude;

	void OnEnable(){
		Init();
	}

	void Init(){
		progress = 0f;
		curveAmplitude = initialCurveAmplitude;
		SetAngle(angle);
	}

	void Update () {
		Quaternion curveLocation = Quaternion.Euler (0f, 0f, Mathf.Sin (progress) * 90f * curveAmplitude);
		transform.position += curveLocation * angleOffset * Vector3.right * 0.05f;
		progress += 0.05f;
	}

	void OnCollisionEnter2D(Collision2D col){
		//Turn around
		if (col.gameObject.CompareTag ("Obstacle")) {
			angle = (angle + 180f) % 360f;
			SetAngle (angle);
		}
	}

	void SetAngle(float degrees){
		angleOffset = Quaternion.Euler (0f, 0f, angle);
	}
}
