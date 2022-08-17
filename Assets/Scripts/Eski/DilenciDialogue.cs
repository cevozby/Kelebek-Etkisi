using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DilenciDialogue : MonoBehaviour
{
    public GameObject fButton;
    public GameObject kekImage;
    public GameObject konusmaKanali, konusmaKanali_2;
    public TextMeshProUGUI questText;

    [SerializeField]
    GameObject dilenciWB, dilenciRGB;

    bool playerCheck;

    public static bool dilenciQuestCheck;

	[SerializeField] private Transform _player;
	
	[SerializeField] private AudioSource audio0;
	[SerializeField] private AudioSource audio1;
	[SerializeField] private GameObject dialoguePanel;

    int count = 1;

    void Start()
    {
        playerCheck = false;
        dilenciQuestCheck = false;
    }


    void Update()
    {
        PlayerDialogue();		
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && OldWomenDialogue.oldWomenQuestCheck && !playerCheck && count == 1)
        {
            fButton.SetActive(true);
            questText.text = "Dilenciyle konuþ!";
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && OldWomenDialogue.oldWomenQuestCheck && playerCheck)
        {
            fButton.SetActive(false);
            playerCheck = false;
        }
    }

    void PlayerDialogue()
    {
        if (playerCheck && Input.GetKeyDown(KeyCode.F))
        {	
			audio0.Play();
            CharacterController.dialogue = true;
            fButton.SetActive(false);
			dialoguePanel.SetActive(true);
            konusmaKanali.SetActive(true);
        }
    }

    public void AcceptButton()
    {
		if(playerCheck)
		{
            if (playerCheck)
            {
                if (count == 1)
                {
                    kekImage.SetActive(false);
                    audio0.Stop();
                    audio1.Play();
                    dilenciQuestCheck = true;
                    dilenciWB.SetActive(false);
                    dilenciRGB.SetActive(true);
                    konusmaKanali.SetActive(false);
                    konusmaKanali_2.SetActive(true);
                    count++;
                }
                else if (count == 2)
                {
                    dialoguePanel.SetActive(false);

                    konusmaKanali_2.SetActive(false);

                    playerCheck = false;
                    CharacterController.dialogue = false;
                    Destroy(this);
                }

                /*dialoguePanel.SetActive(false);
                audio0.Stop();
                audio1.Play();	
                konusmaKanali.SetActive(false);
                kekImage.SetActive(false);
                dilenciQuestCheck = true;
                dilenciWB.SetActive(false);
                dilenciRGB.SetActive(true);
                playerCheck = false;
                CharacterController.dialogue = false;
                Destroy(this);*/
            }
		}
    }

    public void RefuseButton()
    {
		//if(playerCheck)
		//{
			audio0.Stop();
			audio1.Stop();
			CharacterController.dialogue = false;
			dialoguePanel.SetActive(false);
			konusmaKanali.SetActive(false);
		//}
    }
}
