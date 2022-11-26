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


    // Magic numbers suks.
    public void LoadSettings () {
        SceneManager.LoadScene(1);
    }

    public void LoadStart() {
        SceneManager.LoadScene(0);
    }

    public void LoadDirections() {
        SceneManager.LoadScene(6);
    }
}
