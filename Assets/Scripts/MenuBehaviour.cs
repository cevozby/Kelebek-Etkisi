using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
//using TMPro;

public class MenuBehaviour : MonoBehaviour
{
	//[SerializeField]private TextMeshProUGUI text;

	[SerializeField] private AudioMixer audioMixer;

	[SerializeField] Slider volumeSlider;
	
	[SerializeField] GameObject pausePanel;
	
	bool pause;
	
    void Start()
    {
		if(!PlayerPrefs.HasKey("musicVolume"))
		{
			PlayerPrefs.SetFloat("musicVolume", 1);
			Load();
		}else{Load();}
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(!pause){ pause = true; pausePanel.SetActive(true); }else{pause = false; pausePanel.SetActive(false);}
		}
    }
	
	public void Play()
	{
		SceneManager.LoadScene("Level");
	}
	
	public void Quit()
	{
		Application.Quit();
	}
	
	public void ChangeVolume()
	{
		AudioListener.volume = volumeSlider.value;
		Save();
	}
	
	private void Load()
	{
		volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
	}
	
	private void Save()
	{
		PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
	}
	
	[SerializeField]private float outValue;
	public void SoundManagement()
	{
		audioMixer.GetFloat("Volume", out outValue);
		
		if(outValue != -80f){outValue = -80f;}else{outValue = 0f;}
		
		audioMixer.SetFloat("Volume", outValue);
		
	}
		
}
