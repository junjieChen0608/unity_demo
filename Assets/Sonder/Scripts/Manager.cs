using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int sceneIndex;
    public bool[] lockState;
    public GameObject winRef;
    // public GameObject[] objs;
    private int sceneIndexTemp;
    private bool lockStateTemp;

    void Start()
    {
        lockState = new bool[10];
        lockState[0] = false;
        for (int i = 1; i < 10; i++) {
            lockState[i] = true;
        }
    }  

    void Update()
    {
        if (winRef != null) {
            lockStateTemp = winRef.GetComponent<Star>().isLocked;
        }
        Scene scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            sceneIndex = sceneIndexTemp;
            lockState[sceneIndex] = lockStateTemp;
            Debug.Log("Level" + sceneIndex + " isLocked is " + lockStateTemp);
            Debug.Log("This is level" + sceneIndex);
        }
        // objs = GameObject.FindGameObjectsWithTag("LevelIndex");
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


}
