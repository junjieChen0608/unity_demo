using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeletion : MonoBehaviour
{

    private Animator transitionAnim;

    void Start()
    {
        Debug.Log("[LevelSelection_Test0:] Max unlocked index is " + PersistentManagerScript.Instance.maxUnlockedIdx);
        transitionAnim = GetComponent<Animator>();       
    }

    public void LoadScene(int currentSceneIndex) {
        Debug.Log("[LevelSelection_Test1:] Max unlocked index is " + PersistentManagerScript.Instance.maxUnlockedIdx);
        Debug.Log("You click on: " + currentSceneIndex);
        Debug.Log("Max unlocked index is " + PersistentManagerScript.Instance.maxUnlockedIdx);
        if (currentSceneIndex <= PersistentManagerScript.Instance.maxUnlockedIdx) 
        {
            StartCoroutine(Transition(currentSceneIndex));
        }
    }
    IEnumerator Transition(int currentSceneIndex) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
         Debug.Log("[LevelSelection] Almost load Level_: " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }


}
