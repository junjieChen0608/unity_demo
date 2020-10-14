using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // public int sceneIndex;
    // public bool[] lockState;
    // public GameObject winRef;
    private int sceneIndexTemp;
    // private bool lockStateTemp;

    void Start()
    {
    //     // lockState = new bool[10];
    //     // lockState[0] = false;
    //     // for (int i = 1; i < 10; i++) {
    //     //     lockState[i] = true;
    //     // }
    }  

    void Update()
    {
        // if (winRef != null) {
        //     lockStateTemp = winRef.GetComponent<Star>().isLocked;
        // }


        Scene scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            // sceneIndex = sceneIndexTemp;
            // lockState[sceneIndex] = lockStateTemp;
            PersistentManagerScript.Instance.LevelIdx = sceneIndexTemp;
            // Debug.Log("Level" + sceneIndex + " isLocked is " + lockStateTemp);
            Debug.Log("The hightest unlocked level is: Level_" + PersistentManagerScript.Instance.maxUnlockedIdx);
            Debug.Log("This is Level_" + sceneIndexTemp);
        }
        
    }

    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }


}
