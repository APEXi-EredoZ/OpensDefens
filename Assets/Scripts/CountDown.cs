using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : TimeCount {
    float Count;
    public GameObject PausePanel;

    //public Button Restart;
    //public Button Exit;
    
    // Use this for initialization
    void Start() {
        PausePanel.SetActive(false);
        //Restart.interactable = false;
        //Exit.interactable = false;
    }

    // Update is called once per frame
    void Update() {
        Count = time;
        //Debug.Log(Count);
        if (Count <= 1) {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            //Restart.interactable = true;
            //Exit.interactable = true;
        }
    }
}
