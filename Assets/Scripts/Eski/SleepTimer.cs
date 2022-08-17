using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SleepTimer : MonoBehaviour
{
    float sleepTimeCount;

    public TextMeshProUGUI sleepTimerText;

    // Start is called before the first frame update
    void Start()
    {
        sleepTimeCount = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }

    void TimeCount()
    {
        if(sleepTimeCount > 0.1f)
        {
            //sleepTimeCount -= Time.deltaTime;
        }
        else if (sleepTimeCount <= 0.1f)
        {
            CharacterController.sleep = true;
        }

        sleepTimerText.text = sleepTimeCount.ToString("0") + " s";
    }

}
