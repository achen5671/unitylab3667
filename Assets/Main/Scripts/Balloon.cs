using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Balloon sprite. Contains balloon logic such as movement and collission
// AC:
// * Auto movment [DONE]
// * on collission to left and right screen
// * flip image
public class Balloon : MonoBehaviour
{
    // float ?
    private const int velocity = 20;

    [SerializeField] private bool autoMove;
    [SerializeField] private bool expand;
    [SerializeField] private float secondsToPop;
    [SerializeField] private AudioClip popSound;
    bool isScaling = false;

    // Start is called before the first frame update
    void Start(){
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
        Score.ResetScore();

        // Reset scene if balloon pops
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
