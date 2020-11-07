using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonlightOrigin : MonoBehaviour
{

	public GameObject playerRef;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(playerRef.transform.position.x,
								 		 playerRef.transform.position.y,
								 		 playerRef.transform.position.z);
    } 
}
