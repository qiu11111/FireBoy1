using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStarController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "IceGirl")
        {
            ScoreManager.instance.IceGirlGetScore();
            Destroy(this.gameObject);
        }
    }
}
