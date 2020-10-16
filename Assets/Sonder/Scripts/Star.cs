using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Star : MonoBehaviour
{  
    private Animator m_animator;
    private Animator transitionAnim;
    private Rigidbody2D m_body2d;
    private bool m_isAlive = false; 
    private string sceneName = "Win";
    private string TAG = "[Star] ";

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        transitionAnim = GetComponent<Animator>();
    }

    public void Live() 
    {
        if(!m_isAlive)
        {
            m_animator.SetTrigger("Live");
            m_isAlive = true;
            PersistentManagerScript.Instance.starIsAlive = true;
            StartCoroutine(Transition(sceneName));

        } else {
            Debug.Log(TAG + "Star is alive.");
        }
    }

    IEnumerator Transition(string sceneName) {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(sceneName);
    }
}
