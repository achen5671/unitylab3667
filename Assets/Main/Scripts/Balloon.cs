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
    private const int velocity = 20;

    // What is this doing?
    private float min=0f;
    private float max=3f;
    [SerializeField] private bool autoMove;
    [SerializeField] private bool expand;
    [SerializeField] private float secondsToPop;
    [SerializeField] private AudioClip popSound;

    float scale = 0.01f;


    // Start is called before the first frame update
    void Start(){
        // TODO: What is this doing
        min=transform.position.x;
        max=transform.position.x + 20;
    }

    // Update is called once per frame
    void Update(){
        if (expand){
            // Time is a little off. fix seconds
            scale += 0.05f * secondsToPop * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);
            if (scale >= 0.5f)
                Pop();
        }
    }

    void FixedUpdate() {
        // Auto translate
        // transform.position=new Vector2(Mathf.PingPong(Time.time*velocity,max-min), transform.position.y);
        // See:
        // * https://answers.unity.com/questions/1606381/how-to-make-a-object-move-right-automatically-in-2.html
        if (autoMove)
            transform.Translate(Vector2.right * Time.deltaTime * velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "EdgeCollider")
        {
            transform.Rotate(0, 180, 0);
        }
    }
    
    public void Pop() {
        SoundManager.instance.PlaySound(popSound);
        Destroy(gameObject);
    }
}
