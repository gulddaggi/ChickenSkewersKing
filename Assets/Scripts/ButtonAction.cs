using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour
{
    public GameObject[] buttons;
    public int curIndex;
    public bool enablekey = false;
    int minusValue = 0;

    // 버튼 액션 종료 이벤트
    public UnityEvent ButtonActionDone;

    private void OnEnable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = Random.Range(0, 4);// 아래, 좌, 우, 위
            buttons[i].GetComponent<ButtonActionKey>().KeySetting(index);
        }
    }

    void Check()
    {
        enablekey = false;
        ButtonActionKey buttonActionKey = buttons[curIndex].GetComponent<ButtonActionKey>();

        switch (buttonActionKey.curKeyCode)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    buttonActionKey.Correct();
                    ++curIndex;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    buttonActionKey.InCorrect();
                    minusValue += 100;
                    ++curIndex;

                }

                break;

            case 1:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    buttonActionKey.Correct();
                    ++curIndex;
                }
                else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    buttonActionKey.InCorrect();
                    minusValue += 100;
                    ++curIndex;

                }

                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    buttonActionKey.Correct();
                    ++curIndex;

                }
                else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    buttonActionKey.InCorrect();
                    minusValue += 100;
                    ++curIndex;

                }

                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    buttonActionKey.Correct();
                    ++curIndex;

                }
                else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    buttonActionKey.InCorrect();
                    minusValue += 100;
                    ++curIndex;

                }
                break;

            default:
                break;
        }

        if (curIndex == buttons.Length)
        {
            Invoke("EventInvoke", 0.5f);
        }

    }

    void EventInvoke()
    {
        GameManager.Instance.Value -= minusValue;
        ButtonActionDone.Invoke();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            enablekey = true;
        }

        if (enablekey && curIndex < buttons.Length)
        {
            Check();
        }
    }

    public void Init()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonActionKey>().InitKey();
            
        }
        enablekey = false;
        curIndex = 0;
        minusValue = 0;
    }

}
