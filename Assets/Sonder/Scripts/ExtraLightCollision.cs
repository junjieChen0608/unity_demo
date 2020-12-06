using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLightCollision : MonoBehaviour
{
	private int currLevel;
	private string TAG = "[ExtraLightCollision] ";

	private void Start()
	{
		currLevel = PersistentManagerScript.Instance.LevelIdx;
	}

 	// called when hit star & moon 
 	void OnTriggerEnter2D(Collider2D collider)
 	{
		// when hit star
 		Star star = collider.GetComponent<Star>();
 		if (star != null)
 		{
			if (PersistentManagerScript.Instance.levelStarCnt[currLevel] == 1)
			{
            	Destroy(gameObject);
			}
 			star.Live();		
 		}   
 	}
}
