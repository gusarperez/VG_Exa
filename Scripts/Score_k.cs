using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_k : MonoBehaviour {
    public static int score = 0;            //	Player's score
    private Text scoreText;    //	So we can modify the score's Text
    
    // Use this for initialization
    void Start() {
        //	We dynamicaly point to the Text object in our UI.
        scoreText = GetComponent<Text>();
        //Reset ();
        scoreText.text = score.ToString();
        // Update is called once per frame
    }
    public void Score(int points) {
        score += points;
        scoreText.text = score.ToString();
    }
    public static void Reset()
    {
        score = 0;
        // scoreText.text = score.ToString ();
    }
}

