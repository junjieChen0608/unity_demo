using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFade : MonoBehaviour
{
    private Animator fadeAnim;
    private string TAG = "[GuideFade ]";

    private void Start()
    {
        fadeAnim = GetComponent<Animator>();
        Fade();
    }

    private void Fade() {
        StartCoroutine(Transition());
    }

    IEnumerator Transition() {
        yield return new WaitForSeconds(4);
        fadeAnim.SetTrigger("Faded");     
    }
}
