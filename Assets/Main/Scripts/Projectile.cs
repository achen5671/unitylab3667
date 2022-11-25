using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    

    private void OnTriggerEnter2D(Collider2D collision) {
        Balloon balloon = collision.GetComponent<Balloon>();
        if (collision.CompareTag("Balloon")){
            if(balloon != null) {
                balloon.Pop();
                Score.AddScore();
            }
            Destroy(gameObject);
        }
        // Kill Enemy
        if (collision.CompareTag("Enemy")){
            FlyingEnemy enemy = collision.GetComponent<FlyingEnemy>();
            enemy.KillEnemy();
            Destroy(gameObject);
        }
    }
}