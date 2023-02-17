using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI addTimeText;
    [SerializeField] private Animation addTimeAnim;
    [SerializeField] private float startTimeMin;
    [SerializeField] private float startTimeSec;
    
    private bool EndTimerPanel;
    
    private float currentTime;
    private float currentMins;
    private float currentSecs;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        currentTime = startTimeMin*60+startTimeSec;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddTime(25);
        }
        
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentMins = (float)Math.Floor(currentTime / 60);
            currentSecs = currentTime - currentMins * 60;
            if ((float)Math.Round(currentSecs) > 9.99f)
            {
                timerText.text = currentMins + " : " + currentSecs.ToString("F0");
            }
            else
            {
                timerText.text = currentMins + " : 0" + currentSecs.ToString("F0");
            }
        }
        else
        {
            timerText.text =  "0 : 00" ;
            if (!EndTimerPanel)
            {
                _gameManager.Loose();
                EndTimerPanel = true;
            }
        }
    }

    private void AddTime(int secs)
    {
        currentTime += secs;
        addTimeText.text = "+ " + secs;
        addTimeAnim.Play();
    }
}
