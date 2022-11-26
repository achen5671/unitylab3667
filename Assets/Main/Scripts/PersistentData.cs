using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    [SerializeField] string playerName;
    [SerializeField] int difficulty;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerName = "Anonymous";
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetDifficuly(int i)
    {
        difficulty = i;
    }

    public string GetName() {
        return playerName;
    }

    public int GetDifficulty() {
        return difficulty;
    }
}
