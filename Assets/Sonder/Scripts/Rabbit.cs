using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private int m_facingDirection = 1;
    private bool m_biu = false;
    private float  m_delayToIdle = 0.0f;

    public Camera cam;
    public SpriteRenderer sr;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && (!PersistentManagerScript.Instance.starIsAlive)) {
            m_animator.SetBool("Biu", true);
        } else {
                 m_delayToIdle -= Time.deltaTime;
                if(m_delayToIdle < 0)
                    m_animator.SetBool("Biu", false);
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

     void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - transform.position;
        Vector2 lookDir = mousePos - m_body2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if (angle < 0 && angle > -180.0f)
        {
            //transform.localScale.x *= 1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //sr.flipX = false;
            m_facingDirection = 1;
        } else {
           // transform.localScale.x *= -1;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //sr.flipX = true;
            m_facingDirection = -1;
        }
    }

}
