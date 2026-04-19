using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 음식 제작과 관련된 기능 수행 클래스

public class FoodMaker : MonoBehaviour
{
    // 막대 생성 좌표 저장 오브젝트
    public GameObject stickPosObj;
    // 막대 오브젝트 프리팹
    public GameObject stickPref;

    GameObject stick;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        // 활성화 시 화면에 막대 생성
        Debug.Log("막대 생성");
        stick = Instantiate(stickPref, stickPosObj.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyStick()
    {
        DestroyImmediate(stick);
    }
}
