using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objs;
    void Awake ()
    {
        objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    // static Music instance = null;

    // private void Awake()
    // {
    //     if (instance != null)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         instance = this;
    //         GameObject.DontDestroyOnLoad(gameObject);
    //     }
    // }
}
