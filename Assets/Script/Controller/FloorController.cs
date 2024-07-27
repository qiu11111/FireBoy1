using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float speed;
    public float duration;
    public bool isTrigger;
    public bool up;
    public float timer;
    public Rigidbody2D rd;


    public Transform origin;
    public Transform to;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = origin.position;
    }
    void Update()
    {
        if (isTrigger)
        {
            rd.isKinematic = false;
            if (up)
            {
                if (origin.position.y >= transform.position.y)
                {
                    rd.velocity = Vector2.up * speed;
                }
                    
                else
                {
                    isTrigger = false;
                    up = !up;
                    rd.velocity = Vector2.zero;
                }
            }
            else
            {
                if (to.position.y <= transform.position.y)
                {
                    rd.velocity = Vector2.down * speed;

                }
                else
                {
                    isTrigger = false;
                    up = !up;
                    rd.velocity = Vector2.zero;
                }    
            }
        }
        else
        {
            rd.isKinematic=true;
        }
    }
}
