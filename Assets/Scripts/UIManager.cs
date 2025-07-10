using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;



    private int ballsPotted = 0;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        UpdateScore(0);
    }

    void Update()
    {
        float elapsed = Time.time - startTime;
        timeText.text = "Time: " + FormatTime(elapsed);
    }

    public void UpdateScore(int addedBalls)
    {
        ballsPotted += addedBalls;
        scoreText.text = "Score: " + ballsPotted;
    }

    private string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);
        return minutes.ToString("00") + ":" + secs.ToString("00");
    }
}
