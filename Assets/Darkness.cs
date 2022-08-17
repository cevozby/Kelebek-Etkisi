using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class Darkness : MonoBehaviour
{
	[SerializeField] private PostProcessVolume activeVolume;
	
	ColorGrading CG;
	ChromaticAberration CA;
	MotionBlur MB;
	Vignette Vg;
	Bloom BL;
	DepthOfField DOF;
	
	[SerializeField] private GameObject _player;
	bool darkness;
	
    private void Start()
    {
        activeVolume.profile.TryGetSettings(out CG);		
		activeVolume.profile.TryGetSettings(out CA);
		activeVolume.profile.TryGetSettings(out MB);	
		activeVolume.profile.TryGetSettings(out Vg);	
		activeVolume.profile.TryGetSettings(out BL);	
		activeVolume.profile.TryGetSettings(out DOF);
    }
	
    void Update()
    {
        if(darkness)
		{
			CG.brightness.value = Mathf.Lerp(CG.brightness.value, -99, 2 * Time.deltaTime);
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Debug.Log("fiuuuuuuuuuuuuuuu");
			darkness = true;
		}
	}
}
