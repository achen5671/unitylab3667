using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Balloon sprite. Contains balloon logic such as movement and collission
// AC:
// * Auto movment [DONE]
// * on collission to left and right screen [DONE]
// * flip image [DONE]
public class Balloon : MonoBehaviour
{
    // float ?
    private const int velocity = 20;

    [SerializeField] private bool autoMove;
    [SerializeField] private bool expand;
    [SerializeField] private float secondsToPop;
    [SerializeField] private AudioClip popSound;
    bool isScaling = false;
    
    // use for ballon evading player logic
    [SerializeField] public bool isEvade;
    public float speed;
    public bool chase = false;

    public Transform startingPoint;
    private GameObject player;


    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("player");

        // Expands the balloon
        if (expand) {
            StartCoroutine(scaleOverTime(transform, new Vector3(0, 0, 90), secondsToPop));
        }

    }

    void FixedUpdate() {
        // Auto translate
        // transform.position=new Vector2(Mathf.PingPong(Time.time*velocity,max-min), transform.position.y);
        // See:
        // * https://answers.unity.com/questions/1606381/how-to-make-a-object-move-right-automatically-in-2.html
        if (autoMove)
            transform.Translate(Vector2.right * Time.deltaTime * velocity);
        
        // evades player algo
        if (isEvade) {
            // Follow player if player is in the trigger zone
            if (player == null ) return;
            if (chase) Chase();
            else
                ReturnStartPoint();
            Flip();
        }
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

    // See:
    // * https://stackoverflow.com/questions/46587150/scale-gameobject-over-time
    // for info on scaling an object over time
    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(toScale, startScaleSize, counter / duration);
            yield return null;
        }
    
        isScaling = false;
        Pop();
        KillPlayer.Kill();
    }

    // Balloon evades player algo. This is funky and doesn't really work smoothly but eh
    private void ReturnStartPoint() {
        transform.position = Vector2.MoveTowards(-transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, -player.transform.position, speed * Time.deltaTime);
    }

    private void Flip() {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0,0,0);
        else
            transform.rotation = Quaternion.Euler(0,180,0);

    }
}
