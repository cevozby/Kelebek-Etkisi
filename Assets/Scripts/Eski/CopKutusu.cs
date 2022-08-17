using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CopKutusu : MonoBehaviour
{
    public GameObject fButton;
    public TextMeshProUGUI questText;

    bool playerCheck;
    public static bool copCheck;
	
	[SerializeField]private GameObject trashes;
	
    void Start()
    {
        playerCheck = false;
        copCheck = false;
    }

    void Update()
    {
        CopleriAt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DilenciDialogue.dilenciQuestCheck)
        {
            fButton.SetActive(true);
            questText.text = "Çöpleri at";
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DilenciDialogue.dilenciQuestCheck)
        {
            fButton.SetActive(false);
            playerCheck = false;
        }
    }

    void CopleriAt()
    {
        if(playerCheck && !copCheck && Input.GetKeyDown(KeyCode.F))
        {
            fButton.SetActive(false);
            copCheck = true;
			trashes.SetActive(true);
			Destroy(gameObject);
            //transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z);
        }
    }

}
