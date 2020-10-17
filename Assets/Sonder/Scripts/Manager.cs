using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private int sceneIndexTemp;
    private int currLevelIdx;
    private float elapsedTime;
    private string TAG = "[Manager] ";
    private Scene scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;

        UpdateLevelIndex();

        elapsedTime = 0.0f;
        PersistentManagerScript.Instance.starIsAlive = false;
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;
           
    }

    void Update()
    {
        CountLevelShots();
        elapsedTime += Time.deltaTime;
    }

    void OnDisable()
    {
        Debug.Log(TAG + scene.name + " is completed");

        if (PersistentManagerScript.Instance.starIsAlive)
        {
            // CountLevelTotalShots();
            UpdateBestShots();
            Debug.Log(TAG + "Total shots for this play: " + PersistentManagerScript.Instance.LevelShots[currLevelIdx]);
            PersistentManagerScript.Instance.LevelShots[currLevelIdx] = 0; 
            UpdateMaxUnlocked();
        }
    }

    // Update global level index
    // If current is a level, update it; else, keep the previous index
    void UpdateLevelIndex(){
        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            PersistentManagerScript.Instance.LevelIdx = sceneIndexTemp;
            
            Debug.Log(TAG + "The hightest unlocked level is: Level_" + PersistentManagerScript.Instance.maxUnlockedIdx);
            Debug.Log(TAG + "This is Level_" + sceneIndexTemp);
        }
    }

    // Update the highest unlocked level index
    void UpdateMaxUnlocked()
    {
        if (currLevelIdx >= PersistentManagerScript.Instance.maxUnlockedIdx)
        {
            PersistentManagerScript.Instance.maxUnlockedIdx = currLevelIdx + 1;
            
            Debug.Log(TAG + "Now the max unlocked index is: " + PersistentManagerScript.Instance.maxUnlockedIdx);
        } 
    }

    void CountLevelShots()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ++ PersistentManagerScript.Instance.LevelShots[currLevelIdx];
        }
    }

    // Update the best shots for each level
    void UpdateBestShots()
    {
        PersistentManagerScript.Instance.bestLevelShots[currLevelIdx] = Mathf.Min(PersistentManagerScript.Instance.bestLevelShots[currLevelIdx], PersistentManagerScript.Instance.LevelShots[currLevelIdx]);
        
        Debug.Log(TAG + "Best shots for this level: " + PersistentManagerScript.Instance.bestLevelShots[currLevelIdx]); 
    }
}