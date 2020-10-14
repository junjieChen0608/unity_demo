using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class TestEndAndStart : MonoBehaviour
{
    private int countOfShoot = 0;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        AnalyticsResult result = Analytics.CustomEvent("Test level starts");
        Debug.Log("We are at " + scene.name);
        Debug.Log("Analytic start results: " + result);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            countOfShoot++;
            Debug.Log("we fired " + countOfShoot + " times hhh");
        }
    }

    void OnDisable()
    {
        AnalyticsResult endResult = Analytics.CustomEvent("Test Star Dies");
        Debug.Log("Analytic end results: " + endResult + "\n" + Time.timeSinceLevelLoad);
        AnalyticsResult shootResult = Analytics.CustomEvent(
            "Shoot for Test",
            new Dictionary<string, object> {
                {scene.name, countOfShoot}
            });
        Debug.Log("Analytic shoot results: " + shootResult);
    }
}
