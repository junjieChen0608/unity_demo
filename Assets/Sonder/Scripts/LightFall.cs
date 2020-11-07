using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFall : MonoBehaviour
{
    public Transform moonlightPoint;
    public GameObject Moonlight;
    public float GravityScale = 1.0f;
    private bool Falling = false;
    private string TAG = "[LightFall] ";

    void OnTriggerEnter2D(Collider2D collider)
 	{
        MoonMove moonMove = collider.GetComponent<MoonMove>();
            if (moonMove != null)
            {
                Falling = true;
                Destroy(gameObject);
            }  
     }
    
    void Update()
    {
        if (Falling)
        {
            Fall();
        }
    }

    private void Fall()
    {
    	GameObject Light = Instantiate(Moonlight, moonlightPoint.position, moonlightPoint.rotation);
    	Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
		rb.gravityScale = GravityScale;
        Falling = false;
    }
}
