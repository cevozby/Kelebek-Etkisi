using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoktorDialogue : MonoBehaviour
{
    public GameObject fButton;
    public GameObject konusmaKanali;

    [SerializeField]
    GameObject doctorWB, doctorRGB;

    public TextMeshProUGUI questText;

    bool playerSelect;

    public static bool doctorDialogueCheck;
	
	[SerializeField] private AudioSource audio0;
	[SerializeField] private AudioSource audio1;

	[SerializeField] private GameObject dialoguePanel;
	[SerializeField] private GameObject buttonsToClose;
	[SerializeField] private GameObject Xbutton;
	[SerializeField] private GameObject fener;

	[SerializeField] private List<GameObject> konusmaKanallarý;
	
    void Start()
    {
        doctorDialogueCheck = false;
        playerSelect = false;
    }

    void Update()
    {
        GiveDog();
    }

	[SerializeField] bool playOnce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && DogFollowing.playerSelectDog && !playerSelect)
        {
			if(!playOnce){ playOnce = true; audio0.Play();}
            fButton.SetActive(true);
            questText.text = "Doktorla konuþ";
            playerSelect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DogFollowing.playerSelectDog && playerSelect)
        {
            fButton.SetActive(false);
            playerSelect = false;
        }
    }

    void GiveDog()
    {
        if(playerSelect && Input.GetKeyDown(KeyCode.F))
        {
			CharacterController.dialogue = true;
			buttonsToClose.SetActive(false);
			dialoguePanel.SetActive(true);
			Xbutton.SetActive(true);
			audio0.Stop();
			audio1.Play();		
            fButton.SetActive(false);
			playerSelect = false;
            doctorDialogueCheck = true;
            doctorWB.SetActive(false);
            doctorRGB.SetActive(true);
            konusmaKanali.SetActive(true);
			fener.SetActive(true);
        }
    }

    public void CloseText()
    {
		dialoguePanel.SetActive(false);
		foreach(GameObject konusmaKanalcýgý in konusmaKanallarý)
		{
			konusmaKanalcýgý.SetActive(false);
		}
		//konusmaKanali.SetActive(false);
		CharacterController.dialogue = false;
		
		if(fener.activeSelf)
		{
			Destroy(this);
		}
    }

}
