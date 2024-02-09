using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public Text scoreText;
    public int m_Points;
    private String nameBestPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Manager.Player player = Manager.Instance.LoadName();
        if(Manager.Instance != null && player.score > Manager.Instance.player.score ){
            SetBestPlayerInformation(player.name, player.score);
        }else{
            SetBestPlayerInformation(Manager.Instance.player.name, Manager.Instance.player.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBestPlayerInformation(String name, int score){
        bestScoreText.text = "Best Score : " + name + $" : {score}";
    }

    public void AddPoint(int point)
    {
        m_Points += point;
        scoreText.text = $"Score : {m_Points}";
    }
}
