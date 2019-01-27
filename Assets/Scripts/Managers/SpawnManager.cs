using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[Header("References")]
	//Array of spawners
	[SerializeField] private EnemySpawn[] spawners;
	//Array of enemy prefabs
	[SerializeField] private GameObject[] enemies;

	[Tooltip("When mult. enemies spawn at once, the delay between them")]
	[SerializeField] private float spawnDelay = 1f;

	[Header("Spawn Variable Curves")]
	[SerializeField] private ValueCurve maxEnemiesCurve;
	[SerializeField] private ValueCurve minTimeCurve;
	[SerializeField] private ValueCurve maxTimeCurve;
	[SerializeField] private ValueCurve minSpawnCountCurve;
	[SerializeField] private ValueCurve maxSpawnCountCurve;

	[Header("Debugging")]
	[SerializeField] bool debugPrintSpawn = false;
	[SerializeField] bool spawnEnemyOnStart = false;
	[SerializeField] bool dryRun = false;

	int enemyPopulation = 0;

	float minTime;
	float maxTime;
	int minSpawnCount;
	int maxSpawnCount;
	int maxEnemies;

	private EnemySpawn currentSpawner;
	private int spawnerNum;
	private int enemyNum;
	private float spawnTime;

	bool spawnRatesSet = false;


	void Start () 
	{
		spawnTime = spawnEnemyOnStart ? 0f : Random.Range(minTime, maxTime);
	}

	public void UpdateSpawnRates (int score, int maxScore) {
		float progress = Mathf.Lerp (0, maxScore, score);

		minTime = minTimeCurve.GetValue (progress);
		maxTime = maxTimeCurve.GetValue (progress);
		minSpawnCount = minSpawnCountCurve.GetIntValue (progress);
		maxSpawnCount = maxSpawnCountCurve.GetIntValue (progress);
		maxEnemies = maxSpawnCountCurve.GetIntValue (progress);
		spawnRatesSet = true;

		if (debugPrintSpawn) {
			print("Spawn Rates Updated");
			print("Level " + score + " of " + maxScore);
			print("Time range: " + minTime + " to " + maxTime + " seconds");
			print("Spawn range: " + minSpawnCount + " to " + maxSpawnCount + " enemies");
			print("Max enemies: " + minSpawnCount + " to " + maxSpawnCount + " enemies");
		}
	}

	void SpawnEnemies () {
		int spawn_count = Random.Range (minSpawnCount, maxSpawnCount);
		int total_spawned = 0;
		for (int n = 0; n < spawn_count; n++) {
			if (enemyPopulation >= maxEnemies) {
				break;
			}
			if (!dryRun) {
				StartCoroutine(RandomSpawnWithDelay(spawnDelay));
				enemyPopulation++;
			}
			total_spawned++;
		}
		if (debugPrintSpawn) {
			print(total_spawned + " enemies spawned");
		}
	}

	IEnumerator RandomSpawnWithDelay (float delay) {
		yield return new WaitForSeconds(delay);
		RandomSpawn();
	}

	void Update () {
		if (spawnRatesSet) {
			spawnTime -= Time.deltaTime;
			if (spawnTime <= 0) {
				SpawnEnemies();
				spawnTime = Random.Range (minTime, maxTime);
			}
		}
	}

	void RandomSpawn(){
		GetRandomSpawner().SpawnEnemy(GetRandomEnemy());
	}

	EnemySpawn GetRandomSpawner()
	{
		return spawners[Random.Range(0, spawners.Length)];	
	}

	GameObject GetRandomEnemy()
	{
		return enemies[Random.Range(0, enemies.Length)];
	}
}
