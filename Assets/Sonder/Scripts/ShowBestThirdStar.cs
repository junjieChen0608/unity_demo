using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBestThirdStar : MonoBehaviour
{
    public int LevelIdx;
    private Animator m_animator;
    private int currLevelIdx;
   
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;

        if (PersistentManagerScript.Instance.bestLevelShots[LevelIdx] <= 3)
        {
            m_animator.SetBool("getBestThirdStar", true);
        }    
    }
}
