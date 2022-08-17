using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	public static float sleep;
	//public static float hunger;
	
	[SerializeField]private float startSleep; 
	//[SerializeField]private float startHunger;
	
	//[SerializeField]private bool flame; 
	
	[SerializeField]private Image sleepBar;
	//[SerializeField]private Image hungerBar;
	//public static float temperature;
	
	//[SerializeField] private GameObject sleepWarning0, sleepWarning1;
	//[SerializeField] private GameObject hungerWarning0, hungerWarning1;
	
    private void Start()
    {
        startSleep = 25; //200 
		sleep = startSleep;
		//startHunger = 55; //135
        //hunger = startHunger;
        //cold = 25;
    }

    private void Update()
    {		
		if(sleep > 0 /*&& !flame*/ && DarkForest.inDarkForest) sleep -= Time.deltaTime;
		//if(flame) sleep += Time.deltaTime; 
		sleepBar.fillAmount = sleep / startSleep;
		
		/*if(hunger > 0 && !flame) hunger -= Time.deltaTime;
		if(flame) sleep += Time.deltaTime;
		hungerBar.fillAmount = hunger / startHunger;*/
		
		/*if(Stats.sleep < 50)
		{
			sleepWarning1.SetActive(false);
			sleepWarning0.SetActive(true);
		}
		if(Stats.sleep < 10)
		{
			sleepWarning0.SetActive(false);
			sleepWarning1.SetActive(true);
		}
		 if(Stats.hunger < 50)
		{
			hungerWarning1.SetActive(false);
			hungerWarning0.SetActive(true);
		}
		if(Stats.hunger < 10)
		{
			hungerWarning0.SetActive(false);
			hungerWarning1.SetActive(true);
		}*/
    }
}
