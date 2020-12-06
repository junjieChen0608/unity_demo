using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    private Animator m_animator;
    private bool m_isExploded = false;
    private string TAG = "[BalloonCollision ]";

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
 	{
 		if (!m_isExploded) {
             m_isExploded = true;
             StartCoroutine(Transition());
         }   
        
 	}

    IEnumerator Transition() {
        m_animator.SetTrigger("Exploded");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
