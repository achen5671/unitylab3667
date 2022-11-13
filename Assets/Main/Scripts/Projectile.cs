using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    [SerializeField] private AudioClip popSound;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    

    private void OnTriggerEnter2D(Collider2D collision) {
        Balloon balloon = collision.GetComponent<Balloon>();

        if(balloon != null) {
            SoundManager.instance.PlaySound(popSound);
            balloon.Pop();
            // todo: Move this to Score.cs
            Score.AddScore();
        }
        
        Destroy(gameObject);
    }

    // Not necessary?
    // destroy item when item is out of camera
    // void OnBecameInvisible() {
    //      Destroy(gameObject);
    //  }
}