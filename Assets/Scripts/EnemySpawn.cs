using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	
	//Instantiates the enemy passed in by the SpawnManager
	public void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, transform.position, Quaternion.identity);
	}
}
