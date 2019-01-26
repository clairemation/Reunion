using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	//Array of spawners
	[SerializeField]
	private GameObject[] spawners;

	//Array of enemy prefabs
	[SerializeField]
	private GameObject[] enemies;

	private GameObject current_spawner;

	private float min_time = 15.0f;
	private float max_time = 30.0f;
	private int spawner_num;
	private int enemy_num;
	private float spawn_time;

	//boolean to prevent logic from happening more than once when timer is down to 0
	private bool spawn_ready = false;

	// Use this for initialization
	void Start () 
	{
		spawn_time = Random.Range(min_time, max_time);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Spawn time countdown
		spawn_time -= Time.deltaTime;

		if(spawn_time <= 0 && spawn_ready == false)
		{
			spawn_ready = true;

			spawner_num = Random.Range(0, 8);
			enemy_num = Random.Range(0, 3);

			current_spawner = spawners[spawner_num];
			current_spawner.GetComponent<EnemySpawn>().SpawnEnemy(enemies[enemy_num]);

			spawn_time = Random.Range(min_time, max_time);

			spawn_ready = false;
		}
	}
}
