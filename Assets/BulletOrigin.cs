using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrigin : MonoBehaviour
{
	public Rigidbody2D rb;
	public Camera cam;
	private GameObject playerRef;

	Vector2 mousePos;
	
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerRef.transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		// // Debug.Log("angle " + angle);
		rb.rotation = angle;
    }
}
