using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public void PauseGame(bool isPaused){
		Time.timeScale = isPaused ? 0f : 1f;
	}
}
