using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionKey : MonoBehaviour
{
    public Sprite[] keyPefs;
    string[] keycodes = { "DownArrow", "LeftArrow", "RightArrow", "UpArrow" }; // 아래, 좌, 우, 위
    public int curKeyCode = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeySetting(int _index)
    {
        this.GetComponent<Image>().sprite = keyPefs[_index];
        curKeyCode = _index;
    }

    public void Correct()
    {
        this.GetComponent<Image>().color = Color.blue;
        // 점수 유지
    }

    public void InCorrect()
    {
        this.GetComponent<Image>().color = Color.red;
        // 점수 감산
    }

    public void InitKey()
    {
        this.GetComponent<Image>().color = Color.white;
        this.GetComponent<Image>().sprite = null;
    }
}
