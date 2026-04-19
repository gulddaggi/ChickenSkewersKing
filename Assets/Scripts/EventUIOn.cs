using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이벤트 UI 활성/비활성 클래스
public class EventUIOn : MonoBehaviour
{
    // 이벤트 UI 오브젝트 저장 배열
    public GameObject[] eventUIArray;

    public int curIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 제작 UI 활성화
    public void MakeUIOn()
    {
        eventUIArray[0].SetActive(true);
    }

    // 제작 UI 비활성화
    public void MakeUIOff()
    {
        eventUIArray[0].SetActive(false);
    }

    public void ButtonActionUIOn()
    {
        eventUIArray[1].SetActive(true);
    }

    public void ButtonActionUIOff()
    {
        eventUIArray[1].SetActive(false);
    }
}
