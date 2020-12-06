using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonAnim2 : MonoBehaviour
{
    private string TAG = "[ReturnButtonAnimation ]";

    public void onPointerEnter()
    {
        transform.localScale = new Vector3(0.014342f, 0.014342f, 0.014342f);
    }

    public void onPointerExit()
    {
        transform.localScale = new Vector3(0.0121f, 0.0121f, 0.0121f);
    }

    public void onPointerDown()
    {
        transform.localScale = new Vector3(0.011132f, 0.011132f, 0.011132f);
    }
}
