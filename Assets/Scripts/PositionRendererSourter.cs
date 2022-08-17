using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSourter : MonoBehaviour
{
	[SerializeField]
	private int sortingOrderBase = 5000;
	[SerializeField]
	private int offset = 0;
	[SerializeField]
	private bool runOnlyOnce = false;
    private Renderer renderer;
	
	private float timer;
	private float timerMax = .1f;
	
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    void LateUpdate()
    {
		timer -= Time.deltaTime;
		if(timer <= 0f){timer = timerMax;}
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
		if(runOnlyOnce){Destroy(this);}
    }
}
