using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {

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
		curveAmplitude = initialCurveAmplitude;
		SetAngle(angle);
	}

	void Update () {
		float stage = Mathf.Sin (progress) * RIGHT_ANGLE;
		Quaternion curveLocation = Quaternion.Euler (0f, 0f, stage * curveAmplitude);
		transform.position += curveLocation * angleOffset * Vector3.right * step;
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
