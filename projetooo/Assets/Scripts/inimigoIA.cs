using UnityEngine;

public class inimigoIA : MonoBehaviour
{

    public float speed;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool faceRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        Debug.Log(ground);

        if (ground == false)
        {
            speed = speed * -1;
        }
        if (speed > 0 && faceRight == false)
        {
            Flip();
        }
        else if (speed < 0 && faceRight == true)
        {
            Flip();
        }
    }
    
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Inverter direção ao colidir com o player
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = speed * -1;
        }
        // Ignorar colisão entre inimigos
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.CompareTag("itens"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        
      
    }
}
