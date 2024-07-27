using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isLeft;
    public GameObject floor;

    private void Awake()
    {
        sr = GetComponentsInChildren<SpriteRenderer>()[1];
        isLeft = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trans();
        
    }
    public void trans()
    {
        if (isLeft)
        {
            sr.transform.Rotate(0, 0, 90);
        }
        else
        {
            sr.transform.Rotate(0, 0, -90);
        }
        isLeft=!isLeft;
        floor.GetComponent<FloorController>().isTrigger = true;
        
    }

}
