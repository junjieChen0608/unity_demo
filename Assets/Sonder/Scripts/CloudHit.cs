using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHit : MonoBehaviour
{

	private Animator m_animator;
    private string TAG = "[CloudHit ] ";

	void Start()
	{
        m_animator = GetComponent<Animator>();
	}


	// called when hit cloud
    void OnCollisionEnter2D(Collision2D collision)
 	{
          m_animator.SetTrigger("HitCloud");
 	}

}
