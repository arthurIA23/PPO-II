using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Itens : MonoBehaviour
{
    public int itemCount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            itemCount++;
        }
    }
}
