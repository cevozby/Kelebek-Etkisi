using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Brush : MonoBehaviour
{
	private float timer = 3;
	[SerializeField] private TextMeshProUGUI text;
	
    void Start()
    {
        Invoke("DestroyThis", Draw.coolDown);
    }


	void Update()
	{
		timer -= Time.deltaTime;
		
		text.text = (Mathf.Round(timer)).ToString();
	}
	
	void DestroyThis()
	{
		Destroy(gameObject);
	}
	
	/*private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Colliders")) Destroy(other.gameObject);
	}*/
}
