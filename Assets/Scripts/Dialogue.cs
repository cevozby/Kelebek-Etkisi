using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
	[SerializeField]private TextMeshProUGUI text;
	[TextArea(3,10)]
	[SerializeField]private string[] lines;
	[SerializeField]private float textSpeed = 0.3f;
	
	[SerializeField]private int index;
	
	public static bool isDialogueOpen;
	public static bool shiftPanelBool;
	
	[SerializeField]private GameObject NextPanel;
	[SerializeField]private GameObject NextObject;
	[SerializeField]private GameObject Close;
	[SerializeField]private GameObject Open;
	
	[SerializeField]private AudioSource audio;
	
    private void Start()
    {	
			/*text.text = string.Empty;
			StartDialogue();*/			
			audio.Play();
		
    }
	
    private void Update()
    {
			if(Input.GetMouseButtonDown(0))
			{
				if(text.text == lines[index])
				{
					NextLine();
					//audio.UnPause();
				}
				else
				{
					//audio.Pause();
					StopAllCoroutines();
					text.text = lines[index];
				}
			}			
    }
	
	private void StartDialogue()
	{
		text.text = string.Empty;
		index = 0;
		StartCoroutine(TypeLine());
	}
	
	IEnumerator TypeLine()
	{
		foreach(char c in lines[index].ToCharArray())
		{
			audio.UnPause();
			text.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}
	
	private void NextLine()
	{

		if(index < lines.Length - 1)
		{		
			index ++;
			text.text = string.Empty;
			StartCoroutine(TypeLine());
		}else
		{	
			audio.Pause();
			/*if(Open != null){Open.SetActive(true);}
			if(Close != null){Close.SetActive(false);}
			if(NextPanel != null){NextPanel.SetActive(true);}
			if(NextObject != null){NextObject.SetActive(true);}*/
			//gameObject.SetActive(false);

		}
	}
	
	bool enable; 
	void OnEnable()
	{
		if(!enable) enable = true; text.text = ""; StartDialogue();
	}
	
	void OnDisable()
	{
		if(enable) enable = false;
	}
}
