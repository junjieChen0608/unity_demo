using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeletion : MonoBehaviour
{

    private Animator transitionAnim;
    // private int previousLevelIndex;
    // private bool[] lockingStates;    
    

    void Start()
    {
        transitionAnim = GetComponent<Animator>();       
        // lockingStates = GameObject.Find("Global_Vars").GetComponent<Manager>().lockState;
    }

    public void LoadScene(int currentSceneIndex) {
        // if (!lockingStates[currentSceneIndex - 1]) {
        // StartCoroutine(Transition(currentSceneIndex));
        // }

        if (currentSceneIndex <= PersistentManagerScript.Instance.maxUnlockedIdx) 
        {
            StartCoroutine(Transition(currentSceneIndex));
        }
    }
    IEnumerator Transition(int currentSceneIndex) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
         Debug.Log("Almost load Level_: " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }


}
