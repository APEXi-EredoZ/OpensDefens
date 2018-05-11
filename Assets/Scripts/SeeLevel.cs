using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeLevel : MonoBehaviour {

    private GameObject Player;

    public int playerlevel;
    private Text Stringtext;
    // Use this for initialization
    void Start() {
        Stringtext = GetComponent<Text>();
        //Player = GameObject.FindGameObjectWithTag("Player");
        //playerlevel = Player.GetComponent<Player>().LevelUp();
    }

    // Update is called once per frame
    void Update() {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            playerlevel = Player.GetComponent<Player>().LevelUp();

            Stringtext.text = playerlevel.ToString();
        }
        else
            Stringtext.text = "0";
    }
}
