using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private int sceneIndexTemp;
    private int countOfShot;
    private float elapsedTime;
    private string TAG = "[Manager] ";
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndexTemp = scene.buildIndex;
        countOfShot = 0;
        elapsedTime = 0.0f;

        if (sceneIndexTemp >=1 && sceneIndexTemp <= 5)
        {
            PersistentManagerScript.Instance.LevelIdx = sceneIndexTemp;
            // Debug.Log(TAG + "The hightest unlocked level is: Level_" + PersistentManagerScript.Instance.maxUnlockedIdx);
            Debug.Log(TAG + "This is Level_" + sceneIndexTemp);
        }
    }

    // count number of shots and elapsed time in seconds
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ++countOfShot;
            Debug.Log(TAG + "shot " + countOfShot + " times");
        }
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
    }
}
 