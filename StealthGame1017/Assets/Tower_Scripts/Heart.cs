using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    public static Heart Instance;
    // HP를 표시할 슬라이더
    public Slider hpSlider;
    public Image hpSlider_Img;
    public int MAX_HP = 10;
    public int hp = 0;
    // 게임오버 플래그
    bool gameOver = false;

    public GameObject die;

    void Awake()
    {

        if (Instance == null)
            Instance = this;
    }

    void Start()
    {

        hp = MAX_HP;
    }

    private void Update()
    {
        hpSlider_Img.fillAmount = (float)hp / 10;

        // gameOver가 true이고 버튼이 클릭되면 게임을 재시작한다.
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
         
            // 새 게임 로드
            SceneManager.LoadScene(0);
        }


    }

    public void Damage()
    {
        // 1씩 감소
        hp--;
        // 슬라이더에 HP를 세팅
       
        if (hp <= 0)
        {
            // hp가 0이하면 게임오버
            gameOver = true;
            // 이미 죽은게 아니면
            if (die)
            {
                // 게임오버 UI 활성화
                die.SetActive(true);
            }
        }
    }
}
