using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DogFollowing : MonoBehaviour
{
    public Transform playerTransform;
    public Transform doctorTransform;
    public GameObject fButton;

    [SerializeField]
    GameObject dogWB, dogRGB;

    public TextMeshProUGUI questText;

    SpriteRenderer dogSR;

    Animator dogAnim;

    bool dogCheck;
    public static bool playerSelectDog;

    float xMesafe;

	[SerializeField] private AudioSource audio0, audio1;
	[SerializeField] private GameObject dialoguePanel;
	[SerializeField] private GameObject konusmaKanali, konusmaKanali_2;
	
	[SerializeField] private GameObject replicaDog;

    int count = 1;

    void Start()
    {		
        playerSelectDog = false;
        dogSR = GetComponent<SpriteRenderer>();
        dogAnim = GetComponent<Animator>();
        xMesafe = 1.2f;
    }

    
    void Update()
    {
        FollowPlayerCheck();
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !dogCheck && count == 1)
        {
            if (!playerSelectDog)
            {
                dogCheck = true;
            }
            
            fButton.SetActive(true);
            questText.text = "Köpeði yanýna al.";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dogCheck)
        {
            dogCheck = false;
            fButton.SetActive(false);
        }
    }

    void FollowPlayerCheck()
    {
        if(dogCheck && Input.GetKeyDown(KeyCode.F))
        {         
			CharacterController.dialogue = true;
			audio0.Play();
            //dogCheck = false;
            fButton.SetActive(false);
			dialoguePanel.SetActive(true);
			konusmaKanali.SetActive(true);
            //dogWB.SetActive(false);
            //dogRGB.SetActive(true);
        }
    }
	
	 public void AcceptButton()
    {
		if(dogCheck)
		{
            
                if (count == 1)
                {
                    
                    audio0.Stop();
                    audio1.Play();
                    dogCheck = false;
                    playerSelectDog = true;
                    dogWB.SetActive(false);
                    dogRGB.SetActive(true);
                    konusmaKanali.SetActive(false);
                    konusmaKanali_2.SetActive(true);
                    count++;
                }
                else if (count == 2)
                {
                    dialoguePanel.SetActive(false);

                    konusmaKanali_2.SetActive(false);

                    CharacterController.dialogue = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.transform.SetParent(playerTransform);
                    transform.localPosition = new Vector2(1.1f, -1.35f);
                //Destroy(this);
                }
             
			
			//dilenciWB.SetActive(false);
			//dilenciRGB.SetActive(true);
		}
    }

    public void RefuseButton()
    {
		//if(dogCheck)
		//{
			CharacterController.dialogue = false;
			dialoguePanel.SetActive(false);
			konusmaKanali.SetActive(false);
		//}
    }

    void FollowPlayer()
    {
        if (playerSelectDog && !DoktorDialogue.doctorDialogueCheck)
        {
            if (Input.GetKey(KeyCode.D))
            {
                dogSR.flipX = true;
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                dogSR.flipX = false;
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 1);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                dogSR.flipX = true;
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 0);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                dogSR.flipX = false;
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 0);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 0);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                //transform.position = new Vector3(playerTransform.position.x + xMesafe, playerTransform.position.y, transform.position.z);
                dogAnim.SetFloat("Speed", 0);
            }
        }
        else if (DoktorDialogue.doctorDialogueCheck)
        {
			replicaDog.SetActive(true);
			Destroy(gameObject);
            //transform.position = new Vector3(doctorTransform.position.x + 1f, doctorTransform.position.y - 1f, transform.position.z);
            dogAnim.SetFloat("Speed", 0);
        }
    }

}
