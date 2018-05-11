using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    
    public Button _Skill1;
    public Button _Skill2;

    public Button _Spawn1;
    public Button _Spawn2;

    // Use this for initialization
    void Start()
    {
        _Skill1.interactable = _Skill2.interactable = _Spawn1.interactable = _Spawn2.interactable = false;          //선언된 모든 스킬 버튼을 시작시 종료
    }


    public void OnButton(int Level) {
        if (Level >= 1) {
            _Skill1.interactable = _Spawn1.interactable = true;         //1보다 크거나 같을때 해제
        }
        if (Level >= 5) {
            _Skill2.interactable = _Spawn2.interactable = true;         //5보다 크거나 같을때 해제
        }

    }

    public void OffButton() {
        Start();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
