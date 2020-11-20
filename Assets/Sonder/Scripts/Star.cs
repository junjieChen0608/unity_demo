using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Star : MonoBehaviour
{  
    public GameObject PanelRref;

    private Animator m_animator;
    private Animator transitionAnim;
    private Rigidbody2D m_body2d;
    private bool m_isAlive = false; 
    private string sceneName = "Win";
    private int levelIdx;
    private string TAG = "[Star] ";

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        transitionAnim = PanelRref.GetComponent<Animator>();
        levelIdx = PersistentManagerScript.Instance.LevelIdx;
    }

    public void Live() 
    {
        if(!m_isAlive)
        {
            m_animator.SetTrigger("Live");
            m_isAlive = true;
            
            PersistentManagerScript.Instance.levelStarCnt[levelIdx]--;
            Debug.Log(TAG + "Now Level_" + levelIdx + " still have: " + PersistentManagerScript.Instance.levelStarCnt[levelIdx] + " stars");

            if (PersistentManagerScript.Instance.levelStarCnt[levelIdx] == 0) {  
                PersistentManagerScript.Instance.starIsAlive = true;
                StartCoroutine(Transition(sceneName));
            }

        } else {
            Debug.Log(TAG + "Star is alive.");
        }
    }

    IEnumerator Transition(string sceneName) {
        yield return new WaitForSeconds(6);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
}
