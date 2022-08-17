using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public static bool dialogue, sleep;
	
    public Rigidbody2D playerRB;

    public SpriteRenderer playerSR;

    public Sprite idleSprite;

    public GameObject umbrella, fener;

    [Header("RENKSÝZ")]
    public List<Sprite> upSprites;
    public List<Sprite> rightUpSprites;
    public List<Sprite> rightSprites;
    public List<Sprite> rightDownSprites;
    public List<Sprite> downSprites;


    [Header("RENKLÝ")]
    public List<Sprite> upSpritesRGB;
    public List<Sprite> rightUpSpritesRGB;
    public List<Sprite> rightSpritesRGB;
    public List<Sprite> rightDownSpritesRGB;
    public List<Sprite> downSpritesRGB;

    public float speed;
    public float frameRate;

    bool renkli;

    float idleTime;

    Vector2 direction;

	[SerializeField] private AudioSource audio;

    void Start()
    {
        renkli = false;
		dialogue = false;
        sleep = false;
    }

    void Update()
    {
        if(!dialogue) direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if(!dialogue) playerRB.velocity = direction * speed;

        HandleSpriteFlip();
		
		Fener();

		if(dialogue) playerRB.velocity = new Vector2(0, 0); 

		//if(dialogue) playerSR.sprite = idleSprite;

        if (!OldWomenDialogue.oldWomenQuestCheck)
        {
            umbrella.SetActive(true);
        }
        else
        {
            umbrella.SetActive(false);
        }
		
		if(direction.x != 0 || direction.y != 0){if(!audio.isPlaying){audio.Play();}}
		if(direction.x == 0 && direction.y == 0){if(audio.isPlaying){audio.Pause();}}    
	   
	   if(direction.x == 0 && direction.y == 0 || dialogue)
        {		
            playerSR.sprite = idleSprite;
			if(fener != null) fener.transform.position = new Vector3(transform.position.x - 3.2f, transform.position.y - 6f, transform.position.z);
        }
        else
        {
			//audio.Pause();
            SetSprite();
        }

    }

    void SetSprite()
    {
        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int totalFrames = (int)(playTime * frameRate);
            int frame = totalFrames % directionSprites.Count;

            playerSR.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
        }
    }

    void HandleSpriteFlip()
    {
        if (!playerSR.flipX && direction.x < 0)
        {
            playerSR.flipX = true;
        }
        else if(playerSR.flipX && direction.x >= 0)
        {
            playerSR.flipX = false;
        }
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if(direction.y > 0)
        {
            if(Mathf.Abs(direction.x) > 0)
            {
                if (!renkli)
                {
                    selectedSprites = rightUpSprites;
                }
                else
                {
                    selectedSprites = rightUpSpritesRGB;
                }
                
            }
            else
            {
                if (!renkli)
                {
                    selectedSprites = upSprites;
                }
                else
                {
                    selectedSprites = upSpritesRGB;
                }
            }
        }
        else if(direction.y < 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                if (!renkli)
                {
                    selectedSprites = rightDownSprites;
                }
                else
                {
                    selectedSprites = rightDownSpritesRGB;
                }
            }
            else
            {
                if (!renkli)
                {
                    selectedSprites = downSprites;
                }
                else
                {
                    selectedSprites = downSpritesRGB;
                }
            }
        }
        else
        {
            if (!renkli)
            {
                selectedSprites = rightSprites;
            }
            else
            {
                selectedSprites = rightSpritesRGB;
            }
        }
        return selectedSprites;
    }
	
	void Fener()
    {
        if (direction.y > 0)
        {
            if (direction.x > 0)
            {
                fener.transform.position = new Vector3(transform.position.x + 2.3f, transform.position.y - 8f, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 3.3f, transform.position.y - 8f, transform.position.z);
            }
            else
            {
                fener.transform.position = new Vector3(transform.position.x + 3.2f, transform.position.y - 6f, transform.position.z);
            }
        }
        else if (direction.y < 0)
        {
            if (direction.x > 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 2.3f, transform.position.y - 8f, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 3.3f, transform.position.y - 8f, transform.position.z);
            }
            else
            {
                fener.transform.position = new Vector3(transform.position.x - 3.2f, transform.position.y - 6f, transform.position.z);
            }
        }
        else
        {
            if (direction.x >= 0)
            {
                fener.transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 8f, transform.position.z);
            }
            else if (direction.x < 0)
            {
                fener.transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 8f, transform.position.z);
            }
        }
    }
	

}
