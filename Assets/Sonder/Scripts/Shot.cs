using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject LightPrefab;
    public float LightForce;

    private int LevelIdx;

    void Start()
    {
        LevelIdx = PersistentManagerScript.Instance.LevelIdx;
        PersistentManagerScript.Instance.LevelShots[LevelIdx] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
        	Shoot();
            PersistentManagerScript.Instance.LevelShots[LevelIdx]++;        
        }
    }

    void Shoot()
    {
    	GameObject Light = Instantiate(LightPrefab, firePoint.position, firePoint.rotation);
    	Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * LightForce, ForceMode2D.Impulse);
    }
}
