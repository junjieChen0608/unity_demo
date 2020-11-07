using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBestFirstStar : MonoBehaviour
{
    public int LevelIdx;
    private Animator m_animator;
    private int currLevelIdx;
   
    void Start()
    {
        m_animator = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;
        
        if (PersistentManagerScript.Instance.bestLevelShots[LevelIdx] < 1000)
        {
            m_animator.SetBool("getBestFirstStar", true);
        }   
    }
}
