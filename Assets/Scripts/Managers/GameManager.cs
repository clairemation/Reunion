using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] SpawnManager spawnManager;
	[SerializeField] Text scoreText;
	[SerializeField] int maxScore = 25;

	int score = 0; 

	void OnEnable(){
		EventManager.StartListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void OnDisable(){
		EventManager.StopListening(EventNames.SCORE_INCREASED, IncreaseScore);
	}

	void IncreaseScore(){
		score++;
		spawnManager.UpdateSpawnRates(score, maxScore);
		scoreText.text = score.ToString();
	}
}
