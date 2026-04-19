using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 닭꼬치 클래스
public class Skewer : MonoBehaviour
{
    // 재료 생성 위치 리스트
    public List<Vector3> ingredientPosList = new List<Vector3>();

    // 재료 프리팹 리스트
    public List<GameObject> ingredientPrefList = new List<GameObject>();

    // 현재 생성된 오브젝트 리스트
    public List<GameObject> curInstList = new List<GameObject>();

    // 현재 생성된 오브젝트 수
    public int count = 0;

    // 중간 매개 클래스
    private SpeakToSkewer speakToSkewer;

    // 마우스 이벤트 감지 트리거
    private bool enableToScan = false;

    // 현재 음식의 인덱스
    public int index = 0;

    // 버튼 액션 진입 표시 텍스트
    public GameObject buttonActionText;

    public int[] ab = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        speakToSkewer = GetComponentInParent<SpeakToSkewer>();
    }

    private void OnEnable()
    {
        if (this.transform.childCount != 0)
        {
            for (int i = 0; i < ab.Length; i++)
            {
                int a = this.transform.GetChild(i).GetComponent<Ingredient>().ingred_index;
                ab[i] = a;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    // 재료 생성
    public void InstIngredient(int _index)
    {
        GameObject obj = Instantiate(ingredientPrefList[_index], this.transform);
        obj.transform.localPosition = ingredientPosList[count];
        obj.GetComponent<Ingredient>().Index = count;
        curInstList.Add(obj);
        ++count;
        if (count == 6)
        {
            speakToSkewer.SkewerDoneEvent(this.gameObject);
        }
    }

    // 재료 삭제
    public void DelIngredient(int _index)
    {
        if (_index + 1 == count) // 제일 끝에 있는 재료일 경우
        {
            DestroyImmediate(this.transform.GetChild(_index).gameObject);
            curInstList.Remove(curInstList[_index]);
            --count;
        }
    }

    public void EnableToScan()
    {
        enableToScan = true;
    }

    public void DisableToScan()
    {
        enableToScan = false;
    }

    private void OnMouseDown()
    {
        if (enableToScan)
        {
            // 메인 카메라 화면의 스크린 좌표계 기반으로 현재 마우스 좌표에서의 ray 선언
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            // ray 방향으로 Raycast 수행. 
            if (Physics.Raycast(ray, out raycastHit)) // ray가 물체와 충돌할 + 트리거 활성화일 경우
            {
                // 도마에서 버너로 오브젝트 이동
                if (raycastHit.transform.tag == "Skewer_uncooked" && GameManager.Instance.CookingCount < 3)
                {
                    this.GetComponentInParent<Board>().BoardToBurner(index);
                    this.transform.tag = "Skewer_cooking";

                }
                // 버튼 액션 활성화
                else if (raycastHit.transform.tag == "Skewer_cooking")
                {
                    this.GetComponentInParent<Burner>().ActiveButtonAction(index);
                }
                else if(raycastHit.transform.tag == "Skewer_BurnOut")
                {
                    this.GetComponentInParent<Burner>().DelSkewer_Burn(index);
                    Destroy(this.gameObject);
                }
                else if (raycastHit.transform.tag == "Skewer_done")
                {
                    this.GetComponentInParent<Burner>().DelSkewer(index);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    // 버너 위에 생성되었을 때
    public void OnTheBurner()
    {
        DisableToScan();
        Invoke("ButtonActionReady", 2f); // 2초 후부터 버튼 액션 진입 가능
    }

    // 버튼 액션 진입 활성화
    public void ButtonActionReady()
    {
        EnableToScan();
        Instantiate(buttonActionText, this.transform);
    }

    public void ButtonActionTimeOver()
    {

    }

    public void TimerOver()
    {
        this.transform.tag = "Skewer_BurnOut";

    }
}
