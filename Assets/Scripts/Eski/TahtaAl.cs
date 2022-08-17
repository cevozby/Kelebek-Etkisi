using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TahtaAl : MonoBehaviour
{
    public GameObject fButton;
    public GameObject tahtaImage;
    public TextMeshProUGUI questText;

    bool playerCheck;

    public static bool tahtaCheck;

    // Start is called before the first frame update
    void Start()
    {
        tahtaCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        TahtaAlimi();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && CopKutusu.copCheck)
        {
            fButton.SetActive(true);
            questText.text = "Tahta parçasýný al";
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && CopKutusu.copCheck)
        {
            fButton.SetActive(false);
            playerCheck = false;
        }
    }

    void TahtaAlimi()
    {
        if (playerCheck && Input.GetKeyDown(KeyCode.F))
        {
            fButton.SetActive(false);
            gameObject.SetActive(false);
            tahtaCheck = true;
            tahtaImage.SetActive(true);
        }
    }
}
