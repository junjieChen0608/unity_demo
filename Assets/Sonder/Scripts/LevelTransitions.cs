using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private int nextLevelIndex;


    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        nextLevelIndex = PersistentManagerScript.Instance.LevelIdx + 1;
    }

    public void LoadScene() {
        StartCoroutine(Transition());
    }
    IEnumerator Transition() {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
         Debug.Log("[LevelTransitions]Almost load the level: " + nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }


}
