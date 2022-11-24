using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int respawn; // unused for now
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Manually set scene
            Score.ResetScore();

        }
    }
}
