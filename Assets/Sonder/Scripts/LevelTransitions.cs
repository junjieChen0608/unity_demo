using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
   private Animator transitionAnim;
    private int nextLevelIndex;
    private string TAG = "[LevelTransitions] ";

    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        nextLevelIndex =  PersistentManagerScript.Instance.LevelIdx + 1;
        Debug.Log(TAG + "Next Level: Level_" + nextLevelIndex);
    }

    public void LoadScene() {
        StartCoroutine(Transition());
    }
    IEnumerator Transition() {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        Debug.Log(TAG + "Is Loading Level_" + nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }
}
