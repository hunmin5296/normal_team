using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    public static Heart Instance;
    // HP�� ǥ���� �����̴�
    public Slider hpSlider;
    public Image hpSlider_Img;
    public int MAX_HP = 10;
    public int hp = 0;
    // ���ӿ��� �÷���
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

        // gameOver�� true�̰� ��ư�� Ŭ���Ǹ� ������ ������Ѵ�.
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
         
            // �� ���� �ε�
            SceneManager.LoadScene(0);
        }


    }

    public void Damage()
    {
        // 1�� ����
        hp--;
        // �����̴��� HP�� ����
       
        if (hp <= 0)
        {
            // hp�� 0���ϸ� ���ӿ���
            gameOver = true;
            // �̹� ������ �ƴϸ�
            if (die)
            {
                // ���ӿ��� UI Ȱ��ȭ
                die.SetActive(true);
            }
        }
    }
}
