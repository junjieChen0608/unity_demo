using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
    private Animator m_animator;
    private string TAG = "[MoonMove] ";

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // call when it detects enter Moon trigger
    public void Tremble()
    {
        m_animator.SetTrigger("Collide");
    }
}
