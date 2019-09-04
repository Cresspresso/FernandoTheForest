using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitchboard : MonoBehaviour {
	
	public void PlayScene()
	{
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
