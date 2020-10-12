using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Star : MonoBehaviour
{
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_isAlive = false;
    private int countOfShoot = 0;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();

        //log the end of each level, this is hard code version
        AnalyticsResult result = Analytics.CustomEvent("Test level starts");
        Debug.Log("Analytic start results: " + result);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            countOfShoot++;
            Debug.Log("we fired " + countOfShoot + " times");
        }
    }

    public void Live()
    {

        if(!m_isAlive)
        {
            //log the end of each level, this is hard code version
            AnalyticsResult endResult =  Analytics.CustomEvent("Test Star Dies");
            Debug.Log("Analytic end results: "+endResult);
            AnalyticsResult shootResult = Analytics.CustomEvent(
                "Shoot for Test",
                new Dictionary<string, object> {
                    { "testLevel", countOfShoot }
                });
            Debug.Log("Analytic shoot results: " + shootResult);
            Debug.Log("star is dying");
            m_animator.SetTrigger("Live");
            m_isAlive = true;
        } else {
            Debug.Log("star already live");
        }
    }
}
