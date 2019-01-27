using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] SpawnManager spawnManager;
	[SerializeField] Text scoreText;
	[SerializeField] int maxScore = 25;
	[SerializeField] bool debugMessages = false;

	[SerializeField] ScoreItem scoreItem;
	[SerializeField] SpeedItem speedItem;
	[SerializeField] HealthItem healthItem;
	[SerializeField] ShieldItem shieldItem;

	[Range(0f,1f)]
	[SerializeField] float chanceSpawnItem;

	int score = 0; 

	void OnEnable(){
		EventManager.StartListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void OnDisable(){
		EventManager.StopListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void Start(){
		RandomSpawnItem(scoreItem);
	}

	void IncreaseScore () {
		score++;
		spawnManager.UpdateSpawnRates (score, maxScore);
		scoreText.text = score.ToString ();
		RandomSpawnItem (scoreItem);
		if (Random.value > chanceSpawnItem) {
			BaseItem randomItem = null;
			switch (Random.Range (0, 3)) {
				case 0:
					randomItem = speedItem;
					break;
				case 1:
					randomItem = shieldItem;
					break;
				case 2:
					randomItem = healthItem;
					break;
				default:
					break;
			}
			RandomSpawnItem(randomItem);
		}
	}

	void RandomSpawnItem (BaseItem item) {
		
		bool pointFound = false;
		Vector2 spawnPoint = Vector2.zero;
		Collider2D collider;
		while (!pointFound) {
			Vector2 randomPoint = new Vector2 ((Random.Range (1f, 9f) / 10f), (Random.Range (1f, 9f) / 10f));
			collider = Physics2D.OverlapPoint (Camera.main.ViewportToWorldPoint(randomPoint));
			if (collider == null) {
				spawnPoint = new Vector3(randomPoint.x, randomPoint.y, 0f);
				spawnPoint = Vector3.Scale (Camera.main.ViewportToWorldPoint (spawnPoint), new Vector3 (1f, 1f, 0f));
				pointFound = true;
			} else {
				if (debugMessages) {
					print("Can't spawn candy at " + randomPoint);
				}
			}
		}

		Instantiate (item, spawnPoint, Quaternion.identity);
		if (debugMessages) {
			print("Score item spawned at " + spawnPoint);
		}
	}
}
