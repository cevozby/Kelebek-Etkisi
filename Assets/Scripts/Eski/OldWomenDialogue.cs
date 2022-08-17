using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldWomenDialogue : MonoBehaviour
{
    public GameObject fButton;
    public GameObject kekImage;
    public GameObject umbrella;
    public GameObject konusmaKanali, konusmaKanali_2;

    [SerializeField]
    GameObject oldWomenWB, oldWomenRGB;

    public TextMeshProUGUI questText;

    bool playerCheck;

    public static bool oldWomenQuestCheck;
	
	[SerializeField] private AudioSource audio0;
	[SerializeField] private AudioSource audio1;

	[SerializeField] private GameObject dialoguePanel;

    int count = 1;
	
    void Start()
    {
        playerCheck = false;
        oldWomenQuestCheck = false;
    }

    
    void Update()
    {
        PlayerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerCheck && count == 1)
        {
            fButton.SetActive(true);
            questText.text = "Teyzeyle konuþ";
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerCheck)
        {
            fButton.SetActive(false);
            playerCheck = false;
        }
    }

    void PlayerDialogue()
    {
        if(playerCheck && Input.GetKeyDown(KeyCode.F))
        {
			//playerCheck = false;
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
            if(count == 1)
            {
                umbrella.SetActive(true);
                audio0.Stop();
                audio1.Play();
                oldWomenQuestCheck = true;
                oldWomenWB.SetActive(false);
                oldWomenRGB.SetActive(true);
                konusmaKanali.SetActive(false);
                konusmaKanali_2.SetActive(true);
                count++;
            }
			else if(count == 2)
            {
                dialoguePanel.SetActive(false);

                konusmaKanali_2.SetActive(false);
                kekImage.SetActive(true);

                playerCheck = false;
                CharacterController.dialogue = false;
                Destroy(this);
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
