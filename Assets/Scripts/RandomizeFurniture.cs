using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeFurniture : MonoBehaviour {

	//Prefabs to instantiate when randomizing the furniture
	[SerializeField]
	private GameObject couchPrefab;
	[SerializeField]
	private GameObject tablePrefab;

	//variables to randomize the positions of the furniture on x and y plane
	private float x_pos;
	private float y_pos;

	// Use this for initialization
	void Start () 
	{
		//For loop to instantiate random furniture within 4 separate segments
		for(int i = 0; i <= 3; i++ )
		{
			if(i == 0)
			{
				x_pos = Random.Range(-6, -1);
				y_pos = Random.Range(1, 3);
			}
			else if(i == 1)
			{
				x_pos = Random.Range(1, 6);
				y_pos = Random.Range(1, 3);
			}
			else if(i == 2)
			{
				x_pos = Random.Range(-6, -1);
				y_pos = Random.Range(-3, -1);
			}
			else if(i == 3)
			{
				x_pos = Random.Range(1, 6);
				y_pos = Random.Range(-3, -1);
			}

			int num = Random.Range(0, 2);

			if(num == 0)
			{
				Instantiate(couchPrefab, new Vector3(x_pos, y_pos, 0f), couchPrefab.transform.rotation);
			}
			else 
			{
				Instantiate(tablePrefab, new Vector3(x_pos, y_pos, 0f), Quaternion.identity);
			}
		}
	}
}
