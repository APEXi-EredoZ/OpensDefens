using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour {

    private bool ClickObject;       // 선택 확인 변수

    public Collider2D Hit;


    void Start()            //처음 시작시 변수에 따라 값을 초기화 필수
    {

        ClickObject = false;        //처음 시작시 초기화
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())                //좌클릭시
        {
            Hit = SingleTon.instance.HitCollider();

            if (Hit != null)
            {
                if (Hit.tag == "Unit" && ClickObject == false)             //태그가 유닛이고, 오브젝트 클릭변수가 거짓일때 명령 실행
                {
                    Hit.tag = "Player";            //선택된 콜라이더 태그를 플레이어로 변경
                    ClickObject = true;                     //변수 참 변경
                }
                
                if (GameObject.FindWithTag("Player") == null)       // 게임 오브젝트 중 "플레이어" 라는 태그를 가진 오브젝트가 있는지 매 프레임 마다 확인하고 없을 경우에 동작
                {
                    ClickObject = false;        // 클릭 오브젝트를 거짓으로 변환
                }
            }
        }  
    }
}

