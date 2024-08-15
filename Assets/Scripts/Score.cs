using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] public Text scoreText;
    private int totalscore;
    public int plusScore = 1;

    void FixedUpdate()
    {
        
        totalscore += plusScore;
        scoreText.text = totalscore.ToString();
    }
}
