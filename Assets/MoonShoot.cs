using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonShoot : MonoBehaviour
{
    private Animator m_animator;
    private bool m_shoot = false;
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

    public void shoot()
    {
        GameObject Light = Instantiate(LightPrefab, firePoint.position, firePoint.rotation);

    }
}
