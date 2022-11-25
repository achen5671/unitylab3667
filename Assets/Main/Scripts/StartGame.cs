using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
}
