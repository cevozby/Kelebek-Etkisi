using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1231232 : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    public static bool dialogue, sleep;

    bool right, left, up, down;
    bool rightUp, rightDown, leftUp, leftDown;

	public GameObject umbrella;
	public GameObject fener;
	Vector2 direction;
		
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
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
            
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(-speed, playerRB.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, speed);
        }
        if (Input.GetKey(KeyCode.S) && (!Input.GetKey(KeyCode.W) || 
		(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, -speed);
        }
    }

    void CharacterAnimation()
    {
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
		{
			down = false;
            up = false;
            right = false;
            rightUp = false;
            rightDown = false;
		}
		
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
            rightDown = false;
            rightUp = false;
            playerSR.flipX = false;
            playerAnim.SetBool("Right", right);
            playerAnim.SetBool("RightUp", rightUp);
            playerAnim.SetBool("RightDown", rightDown);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            right = true;
            rightDown = false;
            rightUp = false;
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
		
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) /*&& !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)*/)
        {
            rightUp = true;
            playerSR.flipX = false;
            playerAnim.SetBool("RightUp", rightUp);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) /*&& !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W)*/)
        {
            rightDown = true;
            playerSR.flipX = false;
            playerAnim.SetBool("RightDown", rightDown);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) /*&& !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)*/)
        {
            rightUp = true;
            playerSR.flipX = true;
            playerAnim.SetBool("RightUp", rightUp);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) /*&& !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)*/)
        {
            rightDown = true;
            playerSR.flipX = true;
            playerAnim.SetBool("RightDown", rightDown);
        }
    }

    void PlayerStop()
    {
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
		{
			playerRB.velocity = new Vector2(0, playerRB.velocity.y);
		}
		
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
		{
			playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
		}
		
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
		{
			playerRB.velocity = new Vector2(0, playerRB.velocity.y);
			playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
		}
		
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			playerRB.velocity = new Vector2(0, playerRB.velocity.y);
			playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
		}
		
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
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
	
	void Fener()
    {
        if (direction.y > 0)
        {
            if (direction.x > 0)
            {
                fener.transform.position = new Vector3(transform.position.x + 0.375f, transform.position.y - 1, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 0.275f, transform.position.y - 1, transform.position.z);
            }
            else
            {
                fener.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y - 0.875f, transform.position.z);
            }
        }
        else if (direction.y < 0)
        {
            if (direction.x > 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 0.125f, transform.position.y - 1, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y - 1, transform.position.z);
            }
            else
            {
                fener.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.675f, transform.position.z);
            }
        }
        else
        {
            if (direction.x >= 0)
            {
                fener.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y - 1, transform.position.z);
            }
        }
    }

}
