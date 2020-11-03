using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
[RequireComponent(typeof(EventTrigger))]
public class MouseInputUIBlocker : MonoBehaviour
{
    //  public static bool BlockedByUI;
    private EventTrigger eventTrigger;
    private string TAG = "[MouseInputUIBlocker] ";
 
    private void Start()
    {
        Debug.Log(TAG + "Never enters starts");
        eventTrigger = GetComponent<EventTrigger>();
        if(eventTrigger != null)
        {
            EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
            // Pointer Enter
            enterUIEntry.eventID = EventTriggerType.PointerEnter;
            enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
            eventTrigger.triggers.Add(enterUIEntry);
 
            //Pointer Exit
            EventTrigger.Entry exitUIEntry = new EventTrigger.Entry();
            exitUIEntry.eventID = EventTriggerType.PointerExit;
            exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
            eventTrigger.triggers.Add(exitUIEntry);
        }
    }
 
    public void EnterUI()
    {
        Debug.Log(TAG + "Never enters a UI");
        PersistentManagerScript.Instance.blockedByUI = true;
    }
    
    public void ExitUI()
    {
        PersistentManagerScript.Instance.blockedByUI = false;
    }
 
}