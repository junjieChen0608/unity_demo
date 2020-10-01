using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleMove : MonoBehaviour
{
    private Animator            m_animator;
    private bool                m_move = false;
    private string              sceneName;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        Scene scene1 = SceneManager.GetActiveScene();
        sceneName = scene1.name;
                if (sceneName != "Level_1")
        {
            m_animator.SetTrigger("Move");
            m_move = true;

        } else {
            Debug.Log("Never enter move mode");
        }
        
    }

}
