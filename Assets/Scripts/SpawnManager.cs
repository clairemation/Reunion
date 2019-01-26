using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	//Array of spawners
	[SerializeField]
	private EnemySpawn[] spawners;

	//Array of enemy prefabs
	[SerializeField]
	private GameObject[] enemies;

	private EnemySpawn current_spawner;

	private float min_time = 15.0f;
	private float max_time = 30.0f;
	private int spawner_num;
	private int enemy_num;
	private float spawn_time;

	[SerializeField]
	private bool spawnEnemyOnStart;

	// Use this for initialization
	void Start () 
	{
		if(spawnEnemyOnStart == true)
		{
			spawn_time = 0;
		}
		else
		{
			spawn_time = Random.Range(min_time, max_time);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Spawn time countdown
		spawn_time -= Time.deltaTime;

		if(spawn_time <= 0)
		{
			spawner_num = GetRandomSpawner();
			enemy_num = GetRandomEnemy();

			current_spawner = spawners[spawner_num];
			current_spawner.SpawnEnemy(enemies[enemy_num]);

			spawn_time = Random.Range(min_time, max_time);
		}
	}

	int GetRandomSpawner()
	{
		return Random.Range(0, spawners.Length);
		
	}

	int GetRandomEnemy()
	{
		return Random.Range(0, enemies.Length);
	}
}
