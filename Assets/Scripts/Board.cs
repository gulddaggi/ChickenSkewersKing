using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 도마 클래스. 완성된 닭꼬치를 도마 위에 생성.
public class Board : MonoBehaviour
{
    // 닭꼬치 생성 위치 리스트
    public List<Vector3> skewerPosList = new List<Vector3>();

    // 생성된 닭꼬치 저장 리스트
    public List<GameObject> skewers = new List<GameObject>();

    // 버너 오브젝트
    public GameObject burner;

    public int count = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 도마 위에 완성된 닭꼬치 생성
    public void InstSkewer(GameObject skewer)
    {
        for (int i = 0; i < skewers.Count; i++)
        {
            if (skewers[i] == null)
            {
                GameObject obj = Instantiate(skewer, this.transform);

                // 도마 위에 생성되도록 로컬 트랜스폼 변경
                obj.transform.localPosition = skewerPosList[i];
                obj.transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
                obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

                obj.GetComponent<Skewer>().index = i; // 인덱스 지정
                obj.GetComponent<Skewer>().EnableToScan(); // 마우스 스캔 트리거 활성화
                skewers[i] = obj;
                ++GameManager.Instance.CookableCount;
                obj.GetComponent<BoxCollider>().enabled = true;
                obj.transform.tag = "Skewer_uncooked";
                break;
            }
        }
    }

    public void BoardToBurner(int _index)
    {
        burner.GetComponent<Burner>().InstSkewer(skewers[_index]);
        --GameManager.Instance.CookableCount;
        Destroy(skewers[_index]);
    }
}
