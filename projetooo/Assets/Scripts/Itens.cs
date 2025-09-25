using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Itens : MonoBehaviour
{
    public int itemCount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("itens"))
        {
            Destroy(other.gameObject);
            itemCount++;
        }
    }
}
