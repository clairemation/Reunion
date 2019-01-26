using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetGame : MonoBehaviour {

	//This method will reset the game once we make a build with scene indexes
	public void Reset()
	{
		Debug.Log("Reset Game");
		//SceneManager.LoadScene(0);
	} 
}
