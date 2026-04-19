using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 주문 생성 및 관리 클래스
public class OrderCreator : MonoBehaviour
{
    int orderCount = 1;

    public GameObject[] orderObjs;

    public List<int> orderList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        OrderCreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OrderCreate()
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            // 주문이 비어있는 경우 주문 생성
            if (orderList[i] == 0)
            {
                int orderNumber = Random.Range(1, 4); // 1~3번 중 무작위 주문 생성
                orderList[i] = orderNumber;
                DisplayOrder(i, orderNumber);
                
            }
        }
    }

    // 생성된 주문 출력
    void DisplayOrder(int _index, int _orderNumber)
    {
        orderObjs[_index].GetComponentInChildren<Text>().text = "주문 " + orderCount + " : " + _orderNumber + "번";
        ++orderCount;
    }

    // 주문 삭제
    void DeleteOrder(int _index)
    {
        orderList[_index] = 0;
        orderObjs[_index].GetComponentInChildren<Text>().text = "O";
        Invoke("OrderCreate", 2f);
    }

    // 주문 확인
    public bool OrderCheck(GameObject _obj)
    {
        // 주문 목록에서 비교
        for (int i = 0; i < orderList.Count; i++)
        {
            switch (orderList[i])
            {
                // 고기 많이
                case 1:
                    int[] thr_1 = { 0, 0, 1, 0, 0, 0 };
                    for (int j = 0; j < thr_1.Length; j++)
                    {
                        // 틀리면
                        if (_obj.GetComponent<Skewer>().ab[j] != thr_1[j])
                        {
                            break; // 탈출. 다른 주문과 비교
                        }
                        // 맞으면
                        else
                        {
                            if (j == thr_1.Length-1)
                            {
                                // 해당 주문 제거
                                DeleteOrder(i);
                                return true; // 정답 반환
                            }
                        }
                    }
                    break; // 주문과 맞지 않음. 탈출
                
                // 파 많이
                case 2:
                    int[] thr_2 = { 0, 1, 0, 1, 0, 1 };
                    for (int j = 0; j < thr_2.Length; j++)
                    {
                        if (_obj.GetComponent<Skewer>().ab[j] != thr_2[j])
                        {
                            break;
                        }
                        else
                        {
                            if (j == thr_2.Length-1)
                            {
                                DeleteOrder(i);
                                return true;
                            }
                        }
                    }
                    break;

                // 콤비네이션
                case 3:
                    int[] thr_3 = { 0, 1, 2, 0, 1, 2 };
                    for (int j = 0; j < thr_3.Length; j++)
                    {
                        if (_obj.GetComponent<Skewer>().ab[j] != thr_3[j])
                        {
                            break;
                        }
                        else
                        {
                            if (j == thr_3.Length-1)
                            {
                                DeleteOrder(i);
                                return true;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        // 모두 비교했음에도 반환되지 못함. 다틀림
        return false;
    }
}
