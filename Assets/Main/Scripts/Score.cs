using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    private const int POINTS_PER_TARGET = 15;
    private const int NEXT_GOAL = 30; // need better name

    [SerializeField] public Text scoreText;
    [SerializeField] public static int score = 0;

    // used to track and reset score if balloon pop
    public static int tempScore = 0;

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
        if (score >= scoreToNextLevel) {
            // todo: restart game on last scene or have a game over screen
            SceneManager.LoadScene(toNextScene);

            // reset tempscore if you proceed to next level
            tempScore = 0;

            // Increase next ogal limit
            scoreToNextLevel += NEXT_GOAL;
        }
    }

    // Use own method to update score
    public static void AddScore(float scale = (float)1) {
        // scale is the scale of the balloon.
        // bigger ballon gives more points than smaller ones (for expanding balloons)
        // Math is weird but meh. smol ballon = more points than bigger
        int _score = 1;
        // 0.5 becasue thats the scale of balloon. THis is terrible but works for now
        if (scale < 0.5)
            _score = Mathf.RoundToInt( POINTS_PER_TARGET * (1-(float)scale));
        else 
            _score = POINTS_PER_TARGET;
        score += _score;
        tempScore += _score;
    }

    public static int GetScore() {
        return score;
    }

    // Use own method to update score
    public static void ResetScore() {
        score -= tempScore;
        tempScore = 0;
    }
}
