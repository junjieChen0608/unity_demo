using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public Button[] buttons;
    private string TAG = "[LevelButtonManager] ";
    
    void Start()
    {
        Debug.Log(TAG + "Number of buttons: " + buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < Mathf.Min(PersistentManagerScript.Instance.maxUnlockedIdx, buttons.Length); i++)
        {
            buttons[i].interactable = true;
        }
    }
}
