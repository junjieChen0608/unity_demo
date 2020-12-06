using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    private int bounceCount = 15;
	private string TAG = "[LightCollision] ";

	void Start()
	{
		// destroy bullet after 5s
		Destroy(gameObject, 5);
	}


	// called when hit surfaces
    void OnCollisionEnter2D(Collision2D collision)
 	{
 		--bounceCount;
		// bullet bounces up to 15 times
		if (bounceCount == 0 && gameObject != null)
		{
			Destroy(gameObject);
		}
 	}

 	// called when hit star & moon
 	void OnTriggerEnter2D(Collider2D collider)
 	{
		// when hit star
 		Star star = collider.GetComponent<Star>();
 		if (star != null)
 		{
 			star.Live();
			Destroy(gameObject);
 		}

	 	// when hit star2
 		Star2 star2 = collider.GetComponent<Star2>();
 		if (star2 != null)
 		{
 			star2.Live();
			Destroy(gameObject);
 		}

		// when hit star in Level 9
 		FinalStar finalstar = collider.GetComponent<FinalStar>();
 		if (finalstar != null)
 		{
 			finalstar.Live();
			Destroy(gameObject);
 		}
		
		// when hit star2 in Level 9
 		FinalStar2 finalstar2 = collider.GetComponent<FinalStar2>();
 		if (finalstar2 != null)
 		{
 			finalstar2.Live();
			Destroy(gameObject);
 		}

		// when hit star3 in Level 9
 		FinalStar3 finalstar3 = collider.GetComponent<FinalStar3>();
 		if (finalstar3 != null)
 		{
 			finalstar3.Live();
			Destroy(gameObject);
 		}

		// when hit moon
		MoonMove moonMove = collider.GetComponent<MoonMove>();
        if (moonMove != null)
        {
            moonMove.Tremble();
            Destroy(gameObject);
        }      
 	}

	 
}
