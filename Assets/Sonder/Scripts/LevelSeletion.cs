using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeletion : MonoBehaviour
{
    private Animator transitionAnim;
    private string TAG = "[LevelSeletion] ";

    void Start()
    {
        transitionAnim = GetComponent<Animator>();       
    }

    public void LoadScene(int currentSceneIndex) {
        Debug.Log(TAG + "You click on: " + currentSceneIndex);
        Debug.Log(TAG + "Max unlocked index is " + PersistentManagerScript.Instance.maxUnlockedIdx);
        if (currentSceneIndex <= PersistentManagerScript.Instance.maxUnlockedIdx) 
        {
            StartCoroutine(Transition(currentSceneIndex));
        }
    }
    
    IEnumerator Transition(int currentSceneIndex) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        Debug.Log(TAG + "Is Loading Level_" + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }
}
