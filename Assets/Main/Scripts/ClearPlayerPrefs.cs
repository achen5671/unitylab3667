using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    public void Clear() {
        PlayerPrefs.DeleteAll();
        Debug.Log("high score cleared");
    }
}
