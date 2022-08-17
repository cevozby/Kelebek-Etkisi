using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
	public static bool inside;
	[SerializeField] private GameObject _player;
	
	[SerializeField] private float distanceBetweenObjects;

    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, _player.transform.position);
        Debug.DrawLine(transform.position, _player.transform.position, Color.green);
    }
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Brush") && !other.CompareTag("Player"))
		{
			if(distanceBetweenObjects > 3 && distanceBetweenObjects < 100) inside = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Brush"))
		{
			inside = false;
		}
	}
}
