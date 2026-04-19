using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 게임 진행과 관련된 각종 기능을 수행하는 싱글톤 클래스.
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameObject curButtonObj = null;

    public GameObject orderCreater;

    public GameObject gameOverObj;

    public GameObject finalScoreText;

    // 도마 위에 존재하는 요리 가능한 음식 수
    int cookableCount = 0;

    // 현재 요리중인 음식 수
    int cookingCount = 0;

    bool isCorrect = false;

    int score = 0;

    int addValue = 3000;

    public int Value
    {
        get
        {
            return addValue;
        }
        set
        {
            addValue = value;
        }
    }

    public GameObject scoreText;

    public int CookableCount
    {
        get
        {
            return cookableCount;
        }
        set
        {
            cookableCount = value;
        }
    }

    public int CookingCount
    {
        get
        {
            return cookingCount;
        }
        set
        {
            cookingCount = value;
        }
    }

    private void Awake()
    {
        // 싱글톤 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance.orderCreater == null)
            {
                instance.orderCreater = this.orderCreater;
            }

            if (instance.scoreText == null)
            {
                instance.scoreText = this.scoreText;

            }

            if (instance.gameOverObj == null)
            {
                instance.gameOverObj = this.gameOverObj;
            }

            if (instance.finalScoreText == null)
            {
                instance.finalScoreText = this.finalScoreText;
            }
            instance.ScoreUpdate();
            
            DestroyImmediate(this.gameObject);
        }
    }

    // 접근 권한 설정
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }

    }

    public void AssignCurObj(GameObject _obj)
    {
        // 제출하기 전까지 돌입 안됨.
        if (curButtonObj == null)
        {
            curButtonObj = _obj;
        }
    }

    public void ButtonActionDone()
    {
        curButtonObj.GetComponentInChildren<ButtonActionTimer>().TimerOff();
        
    }

    public void OrderCheck()
    {
        isCorrect = orderCreater.GetComponent<OrderCreator>().OrderCheck(curButtonObj);
        CalcScore();
    }

    void CalcScore()
    {
        if (isCorrect)
        {
            score += Value;
            ScoreUpdate();
        }
        Init();
    }

    void Init()
    {
        isCorrect = false;
        curButtonObj = null;
        Value = 3000;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
        {
            ScoreUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate()
    {
        scoreText.GetComponent<Text>().text = "점수 : " + score.ToString();
    }

    public void GameStart()
    {
        score = 0;
        SceneManager.LoadScene("MainPlayScene");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
        finalScoreText.GetComponent<Text>().text = "수익 : " + score.ToString();
    }
}
