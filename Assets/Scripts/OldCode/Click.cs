using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private bool ClickObject;       // 선택 확인 변수
    //private bool SpwanButton_W;       // 선택 확인 변수
    //private bool SkillButton_W;       // 선택 확인 변수

    //public GameObject OtherPlayer;

    //public Button SkillButton_W;          //스킬 버튼 변수
    //public Button SpwanButton_W;          //스폰 버튼 변수    
    //public Button SkillButton_B;          //스킬 버튼 변수
    //public Button SpwanButton_B;          //스폰 버튼 변수

    //public Button Exit;
    //public Button ReStart;

    public Collider2D Hit;


    void Start()            //처음 시작시 변수에 따라 값을 초기화 필수
    {

        ClickObject = false;        //처음 시작시 초기화
        //SpwanButton_W = false;        //처음 시작시 초기화
        //SkillButton_W = false;        //처음 시작시 초기화

        //Exit.interactable = false;
        //ReStart.interactable = false;

        //SkillButton_W.interactable = false;           //버튼 오브젝트는 활성화지만, 선택 불가
        //SpwanButton_W.interactable = false;           //버튼 오브젝트는 활성화지만, 선택 불가
        //SkillButton_B.interactable = false;           //버튼 오브젝트는 활성화지만, 선택 불가
        //SpwanButton_B.interactable = false;           //버튼 오브젝트는 활성화지만, 선택 불가
    }


    void Update()
    {

        /*
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);          //스크린상에 있는 마우스 좌표값을 벡터2로 변경 하여 값을 넘겨받음
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);            //좌표값과, 이동위치, 깊이를 레이캐스트로 변경
        */
        //RaycastHit2D Hit = hit();

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())                //좌클릭시
        {
            Hit = SingleTon.instance.HitCollider();
            //Debug.Log(Hit.gameObject);
            if (Hit != null)
            {
                if (Hit.tag == "Unit" && ClickObject == false)             //태그가 유닛이고, 오브젝트 클릭변수가 거짓일때 명령 실행
                {
                    Hit.tag = "Player";            //선택된 콜라이더 태그를 플레이어로 변경
                    ClickObject = true;                     //변수 참 변경
                }
                //if (hit.collider.name == "Spwan") {
                //    Debug.Log("스폰 버튼 동작");
                //    if (hit.collider.name == "Up") {
                //        Debug.Log("위에 콜라이더 동작");
                //    }
                //    if (hit.collider.name == "Down") {
                //        Debug.Log("아래 콜라이더 동작");
                //    }
                //    if (hit.collider.name == "Mid") {
                //        Debug.Log("중간 콜라이더 동작");
                //    }
                //}

                //if (GameObject.FindWithTag("Player") != null)               //게임 오브젝트 중 "플레이어" 라는 태그를 가진 오브젝트가 없는지 매 프래임 마다 확인을 하고 있을 경우에 동작
                //{
                //    if (hit.collider.name == "Skill")                   //선택한 콜라이더이름이 "Skill"일때 동작
                //    {
                //        SkillButton_W = true;             //버튼 활성화
                //    }
                //}


                //============================스폰 버튼 관련===============================//
                //    if (hit.collider.name == "Spwan")           //스폰오브젝트 콜라이더 눌렀을시
                //    {
                //        Debug.Log("스폰 버튼 동작");
                //        SpwanButton_W = true;
                //    }
                //    if (hit.collider.name == "Up" && SpwanButton_W == true)
                //    {
                //        Debug.Log("위쪽 콜라이더 동작");
                //        SpwanButton_W = false;
                //        Debug.Log("스폰 버튼 중지");
                //    }
                //    if (hit.collider.name == "Down" && SpwanButton_W == true)
                //    {
                //        Debug.Log("아래쪽 콜라이더 동작");
                //        SpwanButton_W = false;
                //        Debug.Log("스폰 버튼 중지");
                //    }
                //    if (hit.collider.name == "Middle" && SpwanButton_W == true)
                //    {
                //        Debug.Log("중앙 콜라이더 동작");
                //        SpwanButton_W = false;
                //        Debug.Log("스폰 버튼 중지");
                //    }

                //}
                //if (GameObject.FindWithTag("Player") != null)          //게임 오브젝트 중 "플레이어" 라는 태그를 가진 오브젝트가 없는지 매 프래임 마다 확인을 하고 있을 경우에 동작
                //{
                //    //SkillUsed(hit);
                //}

                if (GameObject.FindWithTag("Player") == null)       // 게임 오브젝트 중 "플레이어" 라는 태그를 가진 오브젝트가 있는지 매 프레임 마다 확인하고 없을 경우에 동작
                {
                    ClickObject = false;        // 클릭 오브젝트를 거짓으로 변환
                }
            }

        }
        /*
        void SkillUsed(RaycastHit2D hit)
        {
            float TimeCount = 0;
            if (Input.GetMouseButtonDown(0))
            {
                if (SkillButton_W == true && hit.collider.name == "Up")           //스킬 버튼 온라인 상태에서 위에쪽 라인 콜라이더를 눌렀을시
                {
                    TimeCount += Time.deltaTime;
                    if (TimeCount <= 3)
                    {
                        GameObject.FindGameObjectWithTag("Unit").GetComponent<Player>().AiMoveMent(2.0f);        //3초 동안 이동 속도 0.5배 증가
                        TimeCount = 0;
                    }
                }

                if (SkillButton_W == true && hit.collider.name == "Down")
                {
                    TimeCount += Time.deltaTime;
                    if (TimeCount <= 3)
                    {
                        GameObject.FindGameObjectWithTag("Unit").GetComponent<Player>().AiMoveMent(2.0f);        //3초 동안 이동 속도 0.5배 증가
                        TimeCount = 0;
                    }

                }
                if (SkillButton_W == true && hit.collider.name == "Middle")
                {
                    TimeCount += Time.deltaTime;
                    if (TimeCount <= 3)
                    {
                        GameObject.FindGameObjectWithTag("Unit").GetComponent<Player>().AiMoveMent(2.0f);        //3초 동안 이동 속도 0.5배 증가
                        TimeCount = 0;
                    }

                }
            }
        }
        */
    }

    /*
    public void SkillOnOff(bool check) {
        //SkillButton_W.interactable = true;        //스킬 버튼 Interatable활성화
        //SpwanButton_W.interactable = true;        //스폰 버튼 Interatable활성화            
        //SkillButton_B.interactable = true;        //스킬 버튼 Interatable활성화
        //SpwanButton_B.interactable = true;        //스폰 버튼 Interatable활성화

        SkillButton_B.interactable = SkillButton_W.interactable = SpwanButton_B.interactable = SpwanButton_W.interactable = check;
    }
    */

}
