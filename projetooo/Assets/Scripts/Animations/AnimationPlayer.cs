using System;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator anime;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Player player;

    void Start()
    {
        // Inicializa a referência do player
        player = GetComponent<Player>();
        
        // Se não encontrar no mesmo GameObject, tenta encontrar na cena
        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
        }
    }

    void Update()
    {
       
        if (player.isGrounded())
        {
            float velX = Mathf.Abs(rb.linearVelocity.x);
            if (velX > 0)
            {
                anime.SetBool("runing", true);
            }
            else
            {
                anime.SetBool("runing", false);
            }
        }

        else
        {
            float velY = rb.linearVelocity.y;
            if (velY > 0)
            {
                anime.SetBool("jumping", true);
            }
            else
            {
                anime.SetBool("jumping", false);
            }
            
        }
        
    }


}

