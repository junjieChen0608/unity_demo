using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_isAlive = false;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
 
    }

    public void Live()
    {
        if(!m_isAlive)
        {
            Debug.Log("star is dying");
            m_animator.SetTrigger("Live");
            m_isAlive = true;
        } else {
            Debug.Log("star already live");
        }
    }
}
