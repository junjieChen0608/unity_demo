using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    private int bounceCount = 15;

	void Start()
	{
		// destroy bullet after 5s
		Destroy(gameObject, 5);
	}

	// called when hit surfaces
    void OnCollisionEnter2D(Collision2D collision)
 	{
 		--bounceCount;
		Debug.Log("light collision enter, bounce left " + bounceCount);
		// bullet bounces up to 15 times
		if (bounceCount == 0 && gameObject != null)
		{
			Destroy(gameObject);
		}
 	}

 	// called when hit star
 	void OnTriggerEnter2D(Collider2D collider)
 	{
 		Debug.Log("light trigger enter");
 		Star star = collider.GetComponent<Star>();
 		if (star != null)
 		{
 			star.Live();
			Destroy(gameObject);
 		}
        MoonShoot moon = collider.GetComponent<MoonShoot>();

        if (moon != null)
        {
            moon.shoot();
            Destroy(gameObject);
        }
 	}
}
