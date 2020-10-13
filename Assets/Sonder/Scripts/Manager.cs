using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int sceneIndex;
    // public bool[] lockState;
    // public GameObject[] objs;
    private int sceneIndexTemp;
    // private bool lockStateTemp;

    void Start()
    {
        // lockState = new bool[10];
    }  

    void Update()
    {
        // lockStateTemp = GetComponent<Star>().isLocked;
        Scene scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            sceneIndex = sceneIndexTemp;
            // lockState[sceneIndex] = lockStateTemp;
            Debug.Log("This is level" + sceneIndex);
        }
        // objs = GameObject.FindGameObjectsWithTag("LevelIndex");
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


}
