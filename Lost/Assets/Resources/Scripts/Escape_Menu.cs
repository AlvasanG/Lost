using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_Menu : MonoBehaviour {

	//void Update () {
	//	if(Input.GetKeyDown(KeyCode.Escape)) UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("_LastScene"));
	//}
	//private void OnTriggerEnter()
//    {
  //      UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    //}

public string _sceneToLoadOnPlay = "Level";
UnityEngine.SceneManagement.Scene scene;
	public void PlayGame () {
		PlayerPrefs.SetString("_LastScene", scene.name);
		UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay);
	}
	
}
