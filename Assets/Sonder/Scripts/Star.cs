using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_isAlive = false;
    private Animator            transitionAnim;
    public string               sceneName;

    // Use this for initialization
    public void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        transitionAnim = GetComponent<Animator>();
        //sceneName = "Win";
 
    }

    public void Live() 
    {
        if(!m_isAlive)
        {
            Debug.Log("star is dying");
            m_animator.SetTrigger("Live");
            m_isAlive = true;
            StartCoroutine(Transition(sceneName));
        } else {
            Debug.Log("star already live");
        }
    }
    IEnumerator Transition(string sceneName) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(sceneName);
    }
}
