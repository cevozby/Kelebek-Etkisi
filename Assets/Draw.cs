using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

	[SerializeField] private GameObject _object;
	[SerializeField] private GameObject _brush;
	[SerializeField] private Camera _camera;

	private Vector2 mousePosition;

	public static int coolDown;
	public bool coolDownBool;
	
	void Start()
	{
		coolDown = 3;
	}

    void Update()
    {
		mousePosition = Input.mousePosition;
        mousePosition = _camera.ScreenToWorldPoint(mousePosition);
		_brush.transform.position = new Vector2(mousePosition.x, mousePosition.y);
		
         if(Input.GetMouseButton(0) && Canvas.inside && !coolDownBool) 
         {
			coolDownBool = true;
			Invoke("TimeReset", coolDown - 0.25f);
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 0f;       // we want 2m away from the camera position
			Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
			Instantiate(_object, new Vector3(objectPos.x, objectPos.y, 0), Quaternion.identity);
         }
    }
	
	void TimeReset()
	{
		coolDownBool = false;
	}
}
