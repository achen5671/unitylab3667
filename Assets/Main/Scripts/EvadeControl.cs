using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeControl : MonoBehaviour
{
    public Balloon[] balloonArray;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("player")){
            foreach (Balloon balloon in balloonArray){
                balloon.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("player")){
            foreach (Balloon balloon in balloonArray){
                balloon.chase = false;
            }
        }
    }
}
