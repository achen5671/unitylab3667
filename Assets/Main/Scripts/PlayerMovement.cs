using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rename to player ?
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;

	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();

		// Grab animator references
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
		movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
			jumpPressed = true;

		// set animator params
		anim.SetBool("run", movement != 0);
		anim.SetBool("grounded", isGrounded);
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded)
			Jump();
	}

	// flip player facing direction
    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void Jump()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		jumpPressed = false;
		isGrounded = false;
		anim.SetTrigger("jump");
	}

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			isGrounded = true;
	}

	public bool canAttack() {
		// return movement == 0;
		return true;
	}
}