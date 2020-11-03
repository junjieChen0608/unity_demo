using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject LightPrefab;
    public GameObject panel;
    public float LightForce;
    private string TAG = "[Shot ]";

    void Update()
    {
        if (Input.GetMouseButtonUp(0)&& (!PersistentManagerScript.Instance.starIsAlive))
        {
            Debug.Log(TAG + "Pointer is over UI Object is: " + IsPointerOverUIObject());
            if (!IsPointerOverUIObject())
            {
                Shoot();
            }    
        }
    }

    void Shoot()
    {
    	GameObject Light = Instantiate(LightPrefab, firePoint.position, firePoint.rotation);
    	Rigidbody2D rb = Light.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * LightForce, ForceMode2D.Impulse);
    }

    private bool IsPointerOverUIObject()
    {
        var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
