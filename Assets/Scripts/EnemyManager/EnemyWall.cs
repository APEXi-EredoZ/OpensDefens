using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWall : MonoBehaviour {

    public Image image;

    public float Health;
    public float FirstHealth;
    [HideInInspector]
    public bool DieTrue = false;

	// Use this for initialization
	void Start () {
        FirstHealth = Health;
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = Health/FirstHealth;
        DieCheck();
	}
    void DieCheck() {
        if (Health <= 0) {
            Destroy(gameObject);
            DieTrue = true;
        }
    }
}
