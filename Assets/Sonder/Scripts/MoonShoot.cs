using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonShoot : MonoBehaviour
{
    private Animator m_animator;
    private bool m_shoot = false;
    private bool m_isStill = false;
    private string sceneName;
    public Transform Moon3;
    public GameObject LightPrefab;

    public float LightForce;

    // Use this for initialization
    public void Start()
    {
        m_animator = GetComponent<Animator>();
        Scene scene1 = SceneManager.GetActiveScene();
        sceneName = scene1.name;
        if (sceneName == "Level_4")
        {
            m_animator.SetTrigger("Still");
        }
    }

    public void Still()
    {
        if (!m_isStill)
        {
            m_animator.SetTrigger("Still");
            m_isStill = true;
        }
        else
        {
            Debug.Log("Moon is still.");
        }
    }

    public void shoot()
    {
        // moon shake then shoot
        if (!m_shoot)
        {
            m_animator.SetTrigger("Shoot");
            m_shoot = true;
        }
        GameObject Light = Instantiate(LightPrefab, Moon3.position, Moon3.rotation);
        Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * LightForce, ForceMode2D.Impulse);
        // after shoot, moon becomes still again.
        m_animator.SetTrigger("Still");
    }
}
