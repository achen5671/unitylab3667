using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        // Reload scene and reset score (score before level)
        if (other.CompareTag("player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Score.ResetScore();
        }
    }
}
