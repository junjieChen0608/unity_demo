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
    public Transform firePoint;
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
            m_animator.SetTrigger("Shoot");
            m_shoot = true;
        }
        else
        {
            Debug.Log("Never enter move mode");
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
        GameObject Light = Instantiate(LightPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * LightForce, ForceMode2D.Impulse);
    }
}
