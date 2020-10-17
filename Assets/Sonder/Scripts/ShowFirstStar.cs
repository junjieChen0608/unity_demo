using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFirstStar : MonoBehaviour
{
    private Animator m_animator;
    private int currLevelIdx;
   
    void Start()
    {
        m_animator = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;
        
        if (PersistentManagerScript.Instance.LevelShots[currLevelIdx] < 1000)
        {
            m_animator.SetBool("getFirstStar", true);
        }   
    }
}
