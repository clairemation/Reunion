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
		float x = Random.Range (1f, 9f) / 10f;
		float y = Random.Range (1f, 9f) / 10f;
		Vector3 spawnPoint = Vector3.Scale(Camera.main.ViewportToWorldPoint (new Vector3 (x, y, 0f)), new Vector3(1f, 1f, 0f));
		Instantiate (scoreItem, spawnPoint, Quaternion.identity);
		if (debugMessages) {
			print("Score item spawned at " + spawnPoint);
		}
	}
}
