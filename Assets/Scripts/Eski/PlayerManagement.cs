using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField]
    GameObject characterNormal, characterJumper;

    /*[SerializeField]
    GameObject cameraNormal, cameraJumper;*/

    //bool twoHalfGame, platformGame;

    // Start is called before the first frame update
    void Start()
    {
        //twoHalfGame = true;
        //platformGame = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(Stats.sleep < 3)
		{
			 characterNormal.SetActive(false); characterJumper.SetActive(true);
		}
		/*else 
		{
			characterNormal.SetActive(true); characterJumper.SetActive(false);
		}*/
		
        /*if (twoHalfGame)
        {
            characterNormal.SetActive(true);
            //cameraNormal.SetActive(true);

            characterJumper.SetActive(false);
            //cameraJumper.SetActive(false);
        }
        if (platformGame)
        {
            characterJumper.SetActive(true);
            //cameraJumper.SetActive(true);

            characterNormal.SetActive(false);
            //cameraNormal.SetActive(false);
        }*/
    }
}
