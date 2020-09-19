using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour { 
    public Rigidbody rb;

    public float speed = 4.0f;

    int moveDir = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * moveDir * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDir *= -1;
    }
}
