using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// See:
// https://www.youtube.com/watch?v=H69PfxOr6bk
public class KillPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        // Reload scene and reset score (score before level)
        if (other.CompareTag("player")) {
            Kill();
        }
    }

    public static void Kill() {
        Score.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerLives.MinusLives();
    }
}
