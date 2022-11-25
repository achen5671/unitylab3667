using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// See:
// * https://www.youtube.com/watch?v=3pK8nW4A_S4
public class PlayPauseGame : MonoBehaviour
{
    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }
}
