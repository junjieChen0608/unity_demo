using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private int sceneIndexTemp;
    private int countOfShot;
    private int currLevelIdx;
    private float elapsedTime;
    private string TAG = "[Manager] ";
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        countOfShot = 0;
        elapsedTime = 0.0f;
        PersistentManagerScript.Instance.starIsAlive = false;
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;
        UpdateLevelIndex();
    }

    void Update()
    {
        CountLevelShots();
        elapsedTime += Time.deltaTime;
    }

    void OnDisable()
    {
        Debug.Log(TAG + scene.name + " is completed");

        // record total shots of this level to analytics
        AnalyticsResult totalShots = Analytics.CustomEvent(
            "TotalShots",
            new Dictionary<string, object> {
                {scene.name, countOfShot}
            }
        );

        // record total time used in this level to analytics
        AnalyticsResult totalTime = Analytics.CustomEvent(
            "TotalTime",
            new Dictionary<string, object> {
                {scene.name, elapsedTime}
            }
        );

        // record completed level for funnel analyzer
        AnalyticsResult levelComplete = Analytics.CustomEvent(
            "LevelCompleted",
            new Dictionary<string, object> {
                {"level", scene.name}
            }
        );
        Debug.Log(TAG + "total shots " + totalShots);
        Debug.Log(TAG + "total time " + totalTime);
        Debug.Log(TAG + "level complete " + levelComplete);

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
    void UpdateLevelIndex()
    {
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
            ++PersistentManagerScript.Instance.LevelShots[currLevelIdx];
        }
    }

    // Update the best shots for each level
    void UpdateBestShots()
    {
        PersistentManagerScript.Instance.bestLevelShots[currLevelIdx] = Mathf.Min(PersistentManagerScript.Instance.bestLevelShots[currLevelIdx], PersistentManagerScript.Instance.LevelShots[currLevelIdx]);
        
        Debug.Log(TAG + "Best shots for this level: " + PersistentManagerScript.Instance.bestLevelShots[currLevelIdx]); 
    }
}