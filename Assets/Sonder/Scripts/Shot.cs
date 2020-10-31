using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject LightPrefab;
    public float LightForce;

    void Update()
    {
        if (Input.GetMouseButtonUp(0)&& (!PersistentManagerScript.Instance.starIsAlive))
        {
            Shoot();
        }
    }

    void Shoot()
    {
    	GameObject Light = Instantiate(LightPrefab, firePoint.position, firePoint.rotation);
    	Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * LightForce, ForceMode2D.Impulse);
    }
}
