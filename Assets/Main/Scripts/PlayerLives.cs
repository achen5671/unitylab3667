using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] public static int playerLives = 3;
    [SerializeField] public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + playerLives;
    }

    void Update() {
        livesText.text = "Lives: " + playerLives;

        if (playerLives == 0) {
            // end game if you run out of lives
            SceneManager.LoadScene(5);
        }
    }

    public void SetLives(int l) {
        playerLives = l;
    }

    public static void MinusLives() {
        playerLives -= 1;
    }

    public int GetPlayerLives() {
        return playerLives;
    }
}
