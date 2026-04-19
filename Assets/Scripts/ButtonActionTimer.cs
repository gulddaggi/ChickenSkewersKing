using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActionTimer : MonoBehaviour
{
    float time = 0f;
    bool timerOn = true;
    float maxTime = 10f;
    bool isBurnOut = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (time < maxTime)
            {
                time += Time.deltaTime;
                Color curColor = this.GetComponent<TextMesh>().color;
                Color addColor = new Color(curColor.r, curColor.g - (time / maxTime) * Time.deltaTime, curColor.b, curColor.a);
                this.GetComponent<TextMesh>().color = addColor;
            }
            else if (time >= maxTime)
            {
                this.GetComponentInParent<Skewer>().ButtonActionTimeOver();
                this.GetComponent<TextMesh>().text = "X";
                timerOn = false;
                isBurnOut = true;
                this.GetComponentInParent<Skewer>().TimerOver();
            }
        }

    }



    public void TimerOff()
    {
        timerOn = false;
        if (time >= maxTime)
        {
            isBurnOut = true;
            this.GetComponentInParent<Skewer>().TimerOver();
        }
        this.GetComponent<TextMesh>().text = "";
    }
    
}
