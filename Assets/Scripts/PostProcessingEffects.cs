using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PostProcessingEffects : MonoBehaviour
{
	[SerializeField] private PostProcessVolume activeVolume;
	
	ColorGrading CG;
	ChromaticAberration CA;
	MotionBlur MB;
	Vignette Vg;
	Bloom BL;
	DepthOfField DOF;
 
    private void Start()
    {
        activeVolume.profile.TryGetSettings(out CG);		
		activeVolume.profile.TryGetSettings(out CA);
		activeVolume.profile.TryGetSettings(out MB);	
		activeVolume.profile.TryGetSettings(out Vg);	
		activeVolume.profile.TryGetSettings(out BL);	
		activeVolume.profile.TryGetSettings(out DOF);
    }

    private void Update()
    {
        if(Stats.sleep > 15 && Stats.sleep < 20 /*|| Stats.hunger > 30 && Stats.hunger < 50*/)
		{
			if(CG.contrast.value != 5) CG.contrast.value = 5;
			if(CG.contrast.value != -20) CG.brightness.value = -20;
		}
		
		 if(Stats.sleep > 12 && Stats.sleep < 15 /*|| Stats.hunger > 10 && Stats.hunger < 30*/)
		{
			if(CG.contrast.value != 10) CG.contrast.value = 10;
			if(CG.contrast.value != -20) CG.brightness.value = -40;
		}
		
		if(Stats.sleep < 8 /*|| Stats.hunger < 10*/)
		{
			if(CG.contrast.value != 20) CG.contrast.value = 20;
			if(CG.contrast.value != -40) CG.brightness.value = -60;
		}
		
		/*if(Stats.hunger < 50)
		{
			
		}
		if(Stats.hunger < 10)
		{
			
		}*/
    }
	
	private void DreamWorld()
	{
		
	}
	
	private void FinalWorld()
	{
		
	}
}
