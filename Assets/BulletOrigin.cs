using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrigin : MonoBehaviour
{
	public Rigidbody2D rb;
	public Camera cam;
	public GameObject playerRef;

	Vector2 mousePos;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(playerRef.transform.position.x,
								 		 playerRef.transform.position.y+1.0f,
								 		 playerRef.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
    }
}
