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
        // For some reason ternary is not working so this will do for now
        if (PersistentData.Instance.GetDifficulty() == 2)
            livesText.text = "Lives: " + playerLives;
        else
            livesText.text = "Lives: INF";

    }

    void Update() {
        if (PersistentData.Instance.GetDifficulty() == 2)
            livesText.text = "Lives: " + playerLives;
        else
            livesText.text = "Lives: INF";

        if (playerLives == 0) {
            // end game if you run out of lives
            SceneManager.LoadScene(5);
        }
    }

    public void SetLives(int l) {
        playerLives = l;
    }

    public static void MinusLives() {
        if (PersistentData.Instance.GetDifficulty() == 2)
            playerLives -= 1;
    }

    public int GetPlayerLives() {
        return playerLives;
    }
}
