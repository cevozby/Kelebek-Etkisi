using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KopruTamir : MonoBehaviour
{
    public GameObject fButton;
    public GameObject tahtaImage;
    public GameObject tahta;
    public GameObject engel;
    public TextMeshProUGUI questText;
	
    bool playerCheck;
	
	[SerializeField] private AudioSource audio0;
	[SerializeField] private AudioSource audio1;
	//[SerializeField] private GameObject dialoguePanel;

    void Start()
    {
        playerCheck = false;
    }

    void Update()
    {
        TamirEt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && TahtaAl.tahtaCheck)
        {
			Debug.Log("saddasfgsdlkgjsakgjds");
			//audio0.Play();
            fButton.SetActive(true);
            questText.text = "Köprüyü tamir et!";
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && TahtaAl.tahtaCheck)
        {
            fButton.SetActive(false);
            playerCheck = false;
        }
    }

    void TamirEt()
    {
        if(playerCheck && Input.GetKeyDown(KeyCode.F))
        {
			//audio1.Play();
            fButton.SetActive(false);
            tahtaImage.SetActive(false);
            tahta.SetActive(true);
            Destroy(engel);
            Destroy(this);
        }
    }

}
