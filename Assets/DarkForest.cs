using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkForest : MonoBehaviour
{
	[SerializeField] private GameObject colliderBack;
	public static bool inDarkForest;

	void Start()
	{
		inDarkForest = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{			
			inDarkForest = true;
			colliderBack.SetActive(true);
			Destroy(this);
		}
	}
}
