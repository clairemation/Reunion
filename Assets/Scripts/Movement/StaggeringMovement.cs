using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggeringMovement : MonoBehaviour {

	const float RIGHT_ANGLE = 90f;

	[SerializeField] float speed = 0.05f;
	[SerializeField] float step = 0.05f;
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
		curveAmplitude = 0f;
		SetAngle(angle);
	}

	void FixedUpdate () {
		float sin = Mathf.Sin (progress);
		float angle = sin * 360f;
		step = (1f - sin) * 0.05f;
		Quaternion curveLocation = Quaternion.Euler (0f, 0f, angle);
		Vector3 direction = curveLocation * angleOffset * Vector3.right;
		direction.Normalize ();
		transform.position += direction * step;
		progress += speed;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Obstacle")) {
			TurnAround ();
		}
	}

	void TurnAround(){
		angle = (angle + 180f) % 360f;
		SetAngle (angle);
	}

	void SetAngle(float degrees){
		angleOffset = Quaternion.Euler (0f, 0f, angle);
	}
}
