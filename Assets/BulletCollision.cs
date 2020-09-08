using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
	private int bounceCount = 15;
	// when hit surfaces
    void OnCollisionEnter2D(Collision2D collision)
 	{
 		--bounceCount;
		Debug.Log("bullet collision enter, bounce left " + bounceCount);
		// bullet bounces up to 15 times
		if (bounceCount == 0)
		{
			Destroy(gameObject);
		}
 	}

 	// when hit enemies
 	void OnTriggerEnter2D(Collider2D collider)
 	{
 		Debug.Log("bullet trigger enter");
 		Bandit bandit = collider.GetComponent<Bandit>();
 		if (bandit != null)
 		{
 			bandit.Die();
 		}
 	}
}
