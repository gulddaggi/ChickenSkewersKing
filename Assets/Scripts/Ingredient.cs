using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 재료 정보 저장 클래스
public class Ingredient : MonoBehaviour
{
    // 인덱스
    private int index = 0;
    public int ingred_index = 0; // 닭 : 0, 파 : 1, 버섯 : 2

    // 변수 index의 프로퍼티
    public int Index { get { return index; } set { index = value; } }

    public void OnMouseDown()
    {
        // 메인 카메라 화면의 스크린 좌표계 기반으로 현재 마우스 좌표에서의 ray 선언
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        // ray 방향으로 Raycast 수행. 
        if (Physics.Raycast(ray, out raycastHit)) // ray가 물체와 충돌할 + 트리거 활성화일 경우
        {
            // 재료 클릭 시 해당 재료 삭제
            if (raycastHit.transform.tag == "Ingredient")
            {
                int index = raycastHit.transform.GetComponent<Ingredient>().Index;
                this.GetComponentInParent<Skewer>().DelIngredient(index);
            }
        }
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
