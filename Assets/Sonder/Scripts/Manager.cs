using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private int sceneIndexTemp;

    void Start()
    {

        Scene scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            PersistentManagerScript.Instance.LevelIdx = sceneIndexTemp;
            Debug.Log("The hightest unlocked level is: Level_" + PersistentManagerScript.Instance.maxUnlockedIdx);
            Debug.Log("This is Level_" + sceneIndexTemp);
        }
        
    }
}
 