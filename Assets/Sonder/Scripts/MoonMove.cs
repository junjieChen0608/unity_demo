using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
    public Transform Moon;
    public GameObject MoonlightPrefab;
    public float GravityScale = 1.0f;
    private Animator m_animator;
    private bool m_falling;
    private string TAG = "[MoonMove] ";

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // call when it detects enter Moon trigger
    public void Tremble()
    {
        m_animator.SetTrigger("Collide");
        GameObject Moonlight = Instantiate(MoonlightPrefab, Moon.position, Moon.rotation);
        Rigidbody2D rb = Moonlight.GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityScale;
    }
}
