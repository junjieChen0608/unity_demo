using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private int thisLevelIndex;
    private string TAG = "[PlayAgainTransitions] ";

    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        thisLevelIndex =  PersistentManagerScript.Instance.LevelIdx;
        Debug.Log(TAG + "Play again: Level_" + thisLevelIndex);
    }

    public void LoadScene() {
        StartCoroutine(Transition());
    }
    IEnumerator Transition() {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        Debug.Log(TAG + "Is Loading Level_" + thisLevelIndex);
        SceneManager.LoadScene(thisLevelIndex);
    }
}
