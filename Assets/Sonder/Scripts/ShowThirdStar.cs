using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowThirdStar : MonoBehaviour
{
    private Animator m_animator;
    private int currLevelIdx;
    private string TAG = "[ShowThirdStar ]";
   
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;

        Debug.Log(TAG + "This is Level_" + currLevelIdx);
        Debug.Log(TAG + "This level has shots: " + PersistentManagerScript.Instance.LevelShots[currLevelIdx]);

        if (PersistentManagerScript.Instance.LevelShots[currLevelIdx] <= 3)
        {
            m_animator.SetBool("getThirdStar", true);
        }    
    }
}
