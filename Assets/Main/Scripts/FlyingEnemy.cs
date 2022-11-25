using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEnemy : MonoBehaviour
{

    public float speed;

    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null ) return;
        if (chase) Chase();
        else
            ReturnStartPoint();
        Flip();
    }

    private void ReturnStartPoint() {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Flip() {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0,0,0);
        else
            transform.rotation = Quaternion.Euler(0,180,0);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Reset scene if enemy touches player
        if (collision.gameObject.tag == "player") {
            // todo: make this a Kill() function in KillPlayer.cs
            Score.ResetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void KillEnemy() {
        Destroy(gameObject);
    }
}
