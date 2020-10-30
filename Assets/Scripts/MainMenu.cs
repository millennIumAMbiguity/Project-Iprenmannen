using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		//TODO: Fix scene setup
		Stats.instance = new Stats.data();
		AutoFade.LoadLevel(1, 2f, 2f, Color.black);
		Debug.Log("Play Game");
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		Debug.LogWarning("Could not exit application because is editor.");
#else
		Application.Quit();
#endif
		
	}
}
