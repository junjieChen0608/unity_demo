using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private int thisLevelIndex;

    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        thisLevelIndex =  PersistentManagerScript.Instance.LevelIdx;
        Debug.Log("Play again: " + thisLevelIndex);
    }

    public void LoadScene() {
        StartCoroutine(Transition());
    }
    IEnumerator Transition() {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
         Debug.Log("[Again] Almost load the level: " + thisLevelIndex);
        SceneManager.LoadScene(thisLevelIndex);
    }
}
