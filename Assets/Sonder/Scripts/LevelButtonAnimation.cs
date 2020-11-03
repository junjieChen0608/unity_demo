using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonAnimation : MonoBehaviour
{
    private string TAG = "[LevelButtonAnimation ]";

    public void onPointerEnter()
    {
        Debug.Log(TAG + "I'm here.");
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void onPointerExit()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void onPointerDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }
}
