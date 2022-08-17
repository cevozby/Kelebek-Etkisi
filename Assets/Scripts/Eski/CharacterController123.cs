using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController123 : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    public static bool dialogue, sleep;

    bool right, left, up, down;
    bool rightUp, rightDown, leftUp, leftDown;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        dialogue = false;
        sleep = false;
    }

    void FixedUpdate()
    {
        if (!dialogue && !sleep)
        {
            PlayerMovement();
            playerAnim.SetFloat("Speed", speed);
            CharacterAnimation();
        }
        
        
    }

    private void Update()
    {
        PlayerStop();
        if(playerRB.velocity == new Vector2(0, 0))
        {
            playerAnim.SetFloat("Speed", 0);
        }

        if (sleep)
        {
            playerRB.velocity = new Vector2(0, 0);
            playerAnim.SetFloat("Speed", 0);
        }

    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(-speed, playerRB.velocity.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, -speed);
        }
    }

    void CharacterAnimation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
            up = false;
            down = false;
            rightUp = false;
            rightDown = false;
            playerSR.flipX = false;
            playerAnim.SetBool("Right", right);
            playerAnim.SetBool("RightUp", rightUp);
            playerAnim.SetBool("RightDown", rightDown);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            right = true;
            up = false;
            down = false;
            rightUp = false;
            rightDown = false;
            playerSR.flipX = false;
            playerSR.flipX = true;
            playerAnim.SetBool("Right", right);
            playerAnim.SetBool("RightUp", rightUp);
            playerAnim.SetBool("RightDown", rightDown);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            up = true;
            down = false;
            right = false;
            rightUp = false;
            rightDown = false;
            playerAnim.SetBool("Up", up);
            playerAnim.SetBool("Down", down);
            playerAnim.SetBool("Right", right);
            playerAnim.SetBool("RightUp", rightUp);
            playerAnim.SetBool("RightDown", rightDown);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            down = true;
            up = false;
            right = false;
            rightUp = false;
            rightDown = false;
            playerAnim.SetBool("Up", up);
            playerAnim.SetBool("Down", down);
            playerAnim.SetBool("Right", right);
            playerAnim.SetBool("RightUp", rightUp);
            playerAnim.SetBool("RightDown", rightDown);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            rightUp = true;
            playerSR.flipX = false;
            playerAnim.SetBool("RightUp", rightUp);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            rightDown = true;
            playerSR.flipX = false;
            playerAnim.SetBool("RightDown", rightDown);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            rightUp = true;
            playerSR.flipX = true;
            playerAnim.SetBool("RightUp", rightUp);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            rightDown = true;
            playerSR.flipX = true;
            playerAnim.SetBool("RightDown", rightDown);
        }
    }

    void PlayerStop()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            playerAnim.SetFloat("Speed", 0);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        }
    }

}
