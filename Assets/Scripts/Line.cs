using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    public List<GameObject> Unit = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unit") {            //태그 이름이 유닛일때
            Unit.Add(collision.gameObject);         //리스트 Unit에 입력 받은 게임 오브젝트 추가
        }
    }

    private void Update()
    {
        for (var i = Unit.Count - 1; i > -1; i--)
        {
            if (Unit[i] == null)
                Unit.RemoveAt(i);
        }
    }
}
