using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        m_grounded = true;
        m_animator.SetBool("Grounded", m_grounded);
    }
	
	// Update is called once per frame
	void Update () {
        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);
    }

    public void Die()
    {
        if(!m_isDead)
        {
            Debug.Log("bandit dead");
            m_animator.SetTrigger("Death");
            m_isDead = true;
        } else {
            Debug.Log("bandit already dead");
        }
    }

    public bool getStatus()
    {
        return m_isDead;
    }
}
