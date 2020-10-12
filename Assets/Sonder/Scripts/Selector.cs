using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Selector : MonoBehaviour
{
    public Button[] Levels;

    void Start ()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		for (int i = 0; i < Levels.Length; i++)
		{
			if (i + 1 > levelReached)
				Levels[i].interactable = false;
		}
	}

    public void Select(string levelName){
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
         SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }
}
