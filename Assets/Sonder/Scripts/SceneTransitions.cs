using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private string TAG = "[SceneTransitions ]";

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(Transition(sceneName));

    }
    IEnumerator Transition(string sceneName) {
        Debug.Log(TAG + "Scene Transition");
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
}
