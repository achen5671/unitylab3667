using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ## Miscellaneous resources
// Tile Map
// https://www.youtube.com/watch?v=1NCvpZDtTMI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=12&ab_channel=MisterTaftCreates
// See: (for user input)
// * https://www.youtube.com/watch?v=guelZvubWFY
public class StartGame : MonoBehaviour
{
    [SerializeField] public InputField playerNameInput;

    // Start is called before the first frame update
    public void LoadGame(int index) {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        Score.Reset();
        SceneManager.LoadScene(index);
    }  


    // Magic numbers suks. This means if scene build changes, this will be incorrect
    public void LoadSettings () {
        SceneManager.LoadScene(7);
    }

    // This should be called LoadMenu() for a clearer name
    public void LoadStart() {
        SceneManager.LoadScene(0);
    }

    public void LoadDirections() {
        SceneManager.LoadScene(6);
    }

    // 1: easy, 2: hard
    public void SetDifficuly(int i) {
        PersistentData.Instance.SetDifficuly(i);
    }
}
