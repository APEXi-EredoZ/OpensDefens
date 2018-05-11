using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {
    
    public static float time;           //정적 실수형 변수

    public float publictime;            //위 변수에 넣을 값을 설정할 변수, 인스펙터 창에서 설정 가능하도록

	// Use this for initialization
	void Start () {
        time = publictime;          //인스펙터 창에 설정한 시간 값을 time변수 내에 대입
	}
	
	// Update is called once per frame
	void Update () {
        if (time != 0) {
            time -= Time.deltaTime;
            if (time <= 1) {
                time = 0;
            }
        }
        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();
        uiText.text = t.ToString();
	}
}
