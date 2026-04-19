using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 마우스 클릭을 감지하는 클래스
public class MouseClickScanner : MonoBehaviour
{
    // 마우스 이벤트 트리거
    public bool mouseEventEnable = true;

    // 마우스 클릭 이벤트. 제작 모드 진입
    public UnityEvent mouseClikedEvent_Make;


    // 오브젝트 클릭시 발동하는 유니티 이벤트함수
    public void OnMouseDown()
    {
        // 메인 카메라 화면의 스크린 좌표계 기반으로 현재 마우스 좌표에서의 ray 선언
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        // ray 방향으로 Raycast 수행. 
        if (Physics.Raycast(ray, out raycastHit)) // ray가 물체와 충돌할 + 트리거 활성화일 경우
        {
            //Debug.Log("이벤트");
            // 접시 클릭 시 제작 모드 진입
            if (raycastHit.transform.tag == "Event_Plate" && GameManager.Instance.CookableCount < 7) // 도마 위에 최대 수량 미만의 음식이 있을 경우에만
            {
                mouseClikedEvent_Make.Invoke();
            }
        }
    }

    public void InitScanner()
    {
        mouseEventEnable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
