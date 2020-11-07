using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonAnimation : MonoBehaviour
{
    private string TAG = "[ReturnButtonAnimation ]";

    public void onPointerEnter()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }

    public void onPointerExit()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void onPointerDown()
    {
        transform.localScale = new Vector3(0.92f, 0.92f, 0.92f);
    }
}
