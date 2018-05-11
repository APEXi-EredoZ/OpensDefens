using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingEnemy : MonoBehaviour {

    private int r;
    private int t;
    private float TimeCount = 0;

    private bool OnOff = false;

    public GameObject[] Line;

    // Use this for initialization
    void Start()
    {
        Line[0] = GameObject.Find("Up");
        Line[1] = GameObject.Find("Middle");
        Line[2] = GameObject.Find("Down");
        Line[3] = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update() {
        TimeCount += Time.deltaTime;
        Debug.Log(TimeCount);
        if (TimeCount >= 10)
        {
            //int t = RandomNumber(OnOff = true);             //무작위 숫자 함수를 호출 받은뒤 리턴 되는 정수값을 t에다가 대입
            int t = 4;
            Debug.Log(t);

            if (t == 1)     //t가 1일 경우
            {
                for (int i = 0; i < Line[0].GetComponent<Line>().Unit.Count; i++)
                {
                    Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = 0.2f;
                    Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = 3f;
                }
                t = 0;      // t초기화
                TimeCount = 0;      // 시간 카운트 초기화
            }

            if (t == 2)     //t가 2일 경우
            {
                for (int i = 0; i < Line[1].GetComponent<Line>().Unit.Count; i++)
                {
                    Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = 0.2f;
                    Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = 3f;
                }
                t = 0;      // t초기화
                TimeCount = 0;      // 시간 카운트 초기화
            }

            if (t == 3)     //t가 3일 경우
            {
                for (int i = 0; i < Line[2].GetComponent<Line>().Unit.Count; i++)
                {
                    Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = 0.2f;
                    Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = 3f;
                }
                t = 0;      // t초기화
                TimeCount = 0;          // 시간 카운트 초기화
            }
            if (t == 4) {     //t가 3일 경우
                for (int i = 0; i < Line[3].GetComponent<Line>().Unit.Count; i++)
                {
                    Line[3].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = 0.2f;
                    Line[3].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = 3f;
                }
                t = 0;      // t초기화
                TimeCount = 0;          // 시간 카운트 초기화
            }
        }
        
    }

    int RandomNumber(bool check) {
        if (check == true) {
            r = Random.Range(1, 5);         //1이상 4미만의 값을 무작위로 선택후 r에 대입
            check = false;
        }
        return r;
    }
}
