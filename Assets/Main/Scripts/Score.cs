using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    private const int POINTS_PER_TARGET = 1;
    private const int POINTS_TO_NEXT_LEVEL = 1;

    [SerializeField] public Text scoreText;
    [SerializeField] public static int score = 0;

    // Create next level script?
    private static int scoreToNextLevel = 1;
    public int toNextScene;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void Update() {
        scoreText.text = "Score: " + score;
        if (score == scoreToNextLevel) {
            SceneManager.LoadScene(toNextScene);
            scoreToNextLevel++;
        }
    }

    // Use own method to update score
    public static void AddScore() {
        score += POINTS_PER_TARGET;
    }
}
