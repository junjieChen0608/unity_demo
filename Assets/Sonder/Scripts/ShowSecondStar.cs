using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSecondStar : MonoBehaviour
{
    private Animator m_animator;
    private int currLevelIdx;
   
    void Start()
    {
        m_animator = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;

        if (PersistentManagerScript.Instance.LevelShots[currLevelIdx] < 10)
        {
            // yield return new WaitForSeconds(1);
            m_animator.SetBool("getSecondStar", true);
        }    
    }
}
