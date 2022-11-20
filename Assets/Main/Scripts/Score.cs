using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    private const int POINTS_PER_TARGET = 10;
    private const int NEXT_GOAL = 30; // need better name

    [SerializeField] public Text scoreText;
    [SerializeField] public static int score = 0;

    // Create next level script?
    private static int scoreToNextLevel = 10;
    // private?
    public int toNextScene;

    private void Awake() {
        toNextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void Update() {
        scoreText.text = "Score: " + score;
        if (score == scoreToNextLevel) {
            // todo: restart game on last scene or have a game over screen
            SceneManager.LoadScene(toNextScene);
            scoreToNextLevel += NEXT_GOAL;
        }
    }

    // Use own method to update score
    public static void AddScore() {
        score += POINTS_PER_TARGET;
    }

    public static int GetScore() {
        return score;
    }
}
