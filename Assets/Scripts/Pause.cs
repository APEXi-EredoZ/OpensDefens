using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    private bool isTime = true;
    public GameObject Planle;

	// Use this for initialization
	void Start () {
        Planle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPause() {
        if (isTime)
        {
            Time.timeScale = 0;
            isTime = false;
            Planle.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            isTime = true;
            Planle.SetActive(false);
        }
       
    }
}
