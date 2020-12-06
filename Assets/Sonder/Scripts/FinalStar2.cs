using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStar2 : MonoBehaviour
{
    public GameObject christmas;
    public GameObject fog;
    public GameObject tree;

    private Animator m_animator;
    private Animator m_christmas;
    private Animator m_fog;
    private Animator m_tree;
    private Rigidbody2D m_body2d;
    private bool m_isAlive = false; 
    private string sceneName = "Win";
    private int LevelIdx;
    private string TAG = "[FinalStar2] ";

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_christmas = christmas.GetComponent<Animator>();
        m_fog = fog.GetComponent<Animator>();
        m_tree = tree.GetComponent<Animator>();
        LevelIdx = PersistentManagerScript.Instance.LevelIdx; 
    }

    public void Live() 
    {
        Debug.Log(TAG + "Now Level_" + LevelIdx + " still have: " + PersistentManagerScript.Instance.levelStarCnt[LevelIdx] + " stars");
        if(!m_isAlive)
        {
            m_animator.SetTrigger("Live");
            m_isAlive = true;
            
            PersistentManagerScript.Instance.levelStarCnt[LevelIdx]--;
            Debug.Log(TAG + "Left star: " + PersistentManagerScript.Instance.levelStarCnt[LevelIdx]);

            if (PersistentManagerScript.Instance.levelStarCnt[LevelIdx] == 0) {   
                PersistentManagerScript.Instance.starIsAlive = true;
                StartCoroutine(Transition());
            }

        } else {
            Debug.Log(TAG + "Star2 is alive.");
        }
    }

    IEnumerator Transition() {
        yield return new WaitForSeconds(3);
        m_fog.SetTrigger("Dismiss");
        // m_tree.SetTrigger("Dismiss");
        m_christmas.SetTrigger("MerryChristmas");
    }
}
