using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_score : MonoBehaviour {
    //use this for initialization
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = Score_k.score.ToString();
        Score_k.Reset();
        //  However, if the instance is indeed null, then we asociate it to this
        //  gameObject and we ask Unity to not destroy it on every load.
    }
        // Update is called once per frame
        void Update()
        {

        }
    }