using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Star2 : MonoBehaviour
{
    public GameObject PanelRref;
    private Animator m_animator;
    private Animator transitionAnim;
    private Rigidbody2D m_body2d;
    private bool m_isAlive = false; 
    private string sceneName = "Win";
    private int LevelIdx;
    private string TAG = "[Star2] ";

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        transitionAnim = PanelRref.GetComponent<Animator>();
        LevelIdx = PersistentManagerScript.Instance.LevelIdx; 
    }

    public void Live() 
    {
        Debug.Log(TAG + "Now Level_" + LevelIdx + " still have: " + PersistentManagerScript.Instance.levelStarCnt[LevelIdx] + " stars");
        if(!m_isAlive)
        {
            m_animator.SetTrigger("Live");
            m_isAlive = true;
            
            PersistentManagerScript.Instance.levelStarCnt[LevelIdx]--;
            Debug.Log(TAG + "Left star: " + PersistentManagerScript.Instance.levelStarCnt[LevelIdx]);

            if (PersistentManagerScript.Instance.levelStarCnt[LevelIdx] == 0) {   
                PersistentManagerScript.Instance.starIsAlive = true;
                StartCoroutine(Transition(sceneName));
            }

        } else {
            Debug.Log(TAG + "Star2 is alive.");
        }
    }

    IEnumerator Transition(string sceneName) {
        yield return new WaitForSeconds(6);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
}
