using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{

    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
