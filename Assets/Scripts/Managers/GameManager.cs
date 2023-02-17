using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animation endTimerAnim;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            endTimerAnim.Play();
        }
        
    }

    public void Loose()
    {
        endTimerAnim.Play("EndGame");
        Cursor.lockState = CursorLockMode.None;
        
    }

    public void RetryTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
