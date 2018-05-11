using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWall : MonoBehaviour {

    public Image image;

    public int Health;
    [HideInInspector]
    public bool DieTrue = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = 0.01f*Health;
        DieCheck();
	}
    void DieCheck() {
        if (Health <= 0) {
            Destroy(gameObject);
            DieTrue = true;
        }
    }
}
