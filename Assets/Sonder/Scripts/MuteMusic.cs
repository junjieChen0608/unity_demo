using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour {

    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Button musicToggleButton;

    private AudioSource m_MyAudioSource;
    private GameObject[] music;
    private string TAG = "[MuteMusic] ";

    void Awake()
    {
        if (PersistentManagerScript.Instance.muted)
        {
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }
    
    void Start() 
    {
        music = GameObject.FindGameObjectsWithTag("Music");   
    }
    
    public void UpdateIconAndVolume() 
    {
        Debug.Log(TAG + "Audio mute is " + PersistentManagerScript.Instance.muted);
            if (PersistentManagerScript.Instance.muted)
            {
                AudioListener.volume = 1;   // then mute it now
                musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;   
                PersistentManagerScript.Instance.muted = false;         
            } 
            else 
            {             
                AudioListener.volume = 0;  // else, mute it now
                musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
                PersistentManagerScript.Instance.muted = true;              
            }   
    }

    public void onPointerEnter()
    {
        Debug.Log(TAG + "I'm here.");
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
