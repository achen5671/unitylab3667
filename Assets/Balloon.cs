using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Balloon sprite. Contains balloon logic such as movement and collission
// AC:
// * Auto movment [DONE]
// * on collission to left and right screen
// * flip image
public class Balloon : MonoBehaviour
{
    // float ?
    private const int velocity = 10;

    // What is this doing?
    private float min=2f;
    private float max=3f;
    // Start is called before the first frame update
    void Start(){
        // TODO: What is this doing
        min=transform.position.x;
        max=transform.position.x + 20;
    }

    // Update is called once per frame
    void Update(){
        // Auto translate
        transform.position=new Vector2(Mathf.PingPong(Time.time*velocity,max-min)+min, transform.position.y);
        transform.Rotate(0, 180, 0);
    }
}
