using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpController : MonoBehaviour
{
    [SerializeField]
    float speed, jumpForce;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    bool ground;

	//[SerializeField] PlayerManagement

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        ground = true;
    }


    private void FixedUpdate()
    {
        
        CharacterMovement();
        
    }

    void Update()
    {
		//if(CharacterController.dream) 
		
        CharacterJump();
        CharacterStop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            ground = true;
            playerAnim.SetBool("Ground", ground);
        }
    }

    void CharacterMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
            playerSR.flipX = false;
            playerAnim.SetFloat("Speed", speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(-speed, playerRB.velocity.y);
            playerSR.flipX = true;
            playerAnim.SetFloat("Speed", speed);
        }
    }

    void CharacterJump()
    {
        if(Input.GetKeyDown(KeyCode.W) && ground)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            ground = false;
            playerAnim.SetTrigger("Jumping");
            playerAnim.SetBool("Ground", ground);
            
        }
    }

    void CharacterStop()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            playerAnim.SetFloat("Speed", 0);
            playerAnim.SetBool("Ground", ground);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            playerAnim.SetFloat("Speed", 0);
            playerAnim.SetBool("Ground", ground);
        }
    }
}
