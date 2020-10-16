using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_isAlive = false;
    private Animator            transitionAnim;
    public string               sceneName;
    public int                  maxUnlocked;
    private int                 currLevelIdx;

    // Use this for initialization
    public void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        transitionAnim = GetComponent<Animator>();
        currLevelIdx = PersistentManagerScript.Instance.LevelIdx;
 
    }

    public void Live() 
    {
        if(!m_isAlive)
        {
            Debug.Log("star is dying");
            m_animator.SetTrigger("Live");
            // Update the highest unlocked level index
            if (currLevelIdx >= PersistentManagerScript.Instance.maxUnlockedIdx)
            {
                PersistentManagerScript.Instance.maxUnlockedIdx = currLevelIdx + 1;
                Debug.Log("Now the max unlocked index is: " + PersistentManagerScript.Instance.maxUnlockedIdx);
            }     
            // Update the best level shots record
            if ((PersistentManagerScript.Instance.bestLevelShots[currLevelIdx] == 0) || (PersistentManagerScript.Instance.LevelShots[currLevelIdx] < PersistentManagerScript.Instance.bestLevelShots[currLevelIdx])) {
                PersistentManagerScript.Instance.bestLevelShots[currLevelIdx] = PersistentManagerScript.Instance.LevelShots[currLevelIdx];
            }
            Debug.Log("This level shots: " + PersistentManagerScript.Instance.LevelShots[currLevelIdx]);
            Debug.Log("Best shots for this level: " + PersistentManagerScript.Instance.bestLevelShots[currLevelIdx]);

            m_isAlive = true;
            StartCoroutine(Transition(sceneName));
        } else {
            Debug.Log("star already live");
        }
    }
    IEnumerator Transition(string sceneName) {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(sceneName);
    }
}
