using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireBoy")
        {
            ScoreManager.instance.FireBoyGetScore();
            Destroy(this.gameObject);
        }
        
    }
}
