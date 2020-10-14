using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private int thisLevelIndex;

    void Update()
    {
        transitionAnim = GetComponent<Animator>();
        // thisLevelIndex = GameObject.Find("Global_Vars").GetComponent<Manager>().sceneIndex;
        thisLevelIndex =  PersistentManagerScript.Instance.LevelIdx;
        Debug.Log("Play again: " + thisLevelIndex);
    }

    public void LoadScene() {
        StartCoroutine(Transition());
    }
    IEnumerator Transition() {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
         Debug.Log("Almost load the level: " + thisLevelIndex);
        SceneManager.LoadScene(thisLevelIndex);
    }
}
