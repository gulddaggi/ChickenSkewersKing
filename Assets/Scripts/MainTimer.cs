using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    public Text timerText;
    int min;
    float sec;
    float setTime = 300f;

    // Update is called once per frame
    void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime >= 60f)
        {
            min = (int)setTime / 60;
            sec = setTime % 60;
            timerText.text = "남은 시간 : " + min + "분" + (int)sec + "초";
        }

        if (setTime < 60f)
        {
            timerText.text = "남은 시간 : " + (int)setTime + "초";
            if (setTime <= 0)
            {
                timerText.text = "남은 시간 : 0초";
                GameManager.Instance.GameOver();
            }
        }


    }
}

