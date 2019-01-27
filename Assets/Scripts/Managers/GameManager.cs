using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] SpawnManager spawnManager;
	[SerializeField] Text scoreText;
	[SerializeField] ScoreItem scoreItem;
	[SerializeField] int maxScore = 25;
	[SerializeField] bool debugMessages = false;

	int score = 0; 

	void OnEnable(){
		EventManager.StartListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void OnDisable(){
		EventManager.StopListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void Start(){
		RandomSpawnScoreItem();
	}

	void IncreaseScore(){
		score++;
		spawnManager.UpdateSpawnRates(score, maxScore);
		scoreText.text = score.ToString();
		RandomSpawnScoreItem();
	}

	void RandomSpawnScoreItem () {
		
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

		Instantiate (scoreItem, spawnPoint, Quaternion.identity);
		if (debugMessages) {
			print("Score item spawned at " + spawnPoint);
		}
	}
}
