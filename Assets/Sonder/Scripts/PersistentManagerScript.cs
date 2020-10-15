using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    private static PersistentManagerScript _instance;

    public static PersistentManagerScript Instance 
    { 
        get { return _instance; }
        // private set; 
    }

    public int LevelIdx;
    public int maxUnlockedIdx;
    public int[] LevelShots;
    public int[] bestLevelShots;
    public int[] levelStarCnt;

    private void Awake()
    {
        
        if (_instance == null)
        {
            _instance = this;
            LevelShots = new int[10];
            bestLevelShots = new int[10];
            levelStarCnt = new int[10];
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
