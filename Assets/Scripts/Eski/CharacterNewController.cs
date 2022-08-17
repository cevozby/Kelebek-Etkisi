using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNewController : MonoBehaviour
{
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

    void Start()
    {
        renkli = false;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        playerRB.velocity = direction * speed;

        HandleSpriteFlip();

        Fener();

        if (!OldWomenDialogue.oldWomenQuestCheck)
        {
            umbrella.SetActive(true);
        }
        else
        {
            umbrella.SetActive(false);
        }

        if(direction.x == 0 && direction.y == 0)
        {
            playerSR.sprite = idleSprite;
            fener.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.675f, transform.position.z);
        }
        else
        {
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
