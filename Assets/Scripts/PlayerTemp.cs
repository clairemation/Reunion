using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour {

	//speed of player
	[SerializeField]
	private float speed;

	// Variables to control the movement with the helo of Input
	private float moveX;
	private float moveY;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");

		transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
	}
}
