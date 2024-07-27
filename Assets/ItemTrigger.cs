using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private DeleteController controller => GetComponentInParent<DeleteController>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireBoy")
        {
            controller.addItem();
        }
    }
}
