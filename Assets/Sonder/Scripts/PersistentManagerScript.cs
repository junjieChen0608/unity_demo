using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{

    public static PersistentManagerScript Instance 
    { 
        get; private set; 
    }

    public int LevelIdx;
    public int maxUnlockedIdx;
    public int[] LevelShots;
    public int[] bestLevelShots;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            LevelShots = new int[10];
            bestLevelShots = new int[10];
            maxUnlockedIdx = 1;
            Debug.Log("This is initialized");
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            Debug.Log("It is destroyed");
        }
    }
}
