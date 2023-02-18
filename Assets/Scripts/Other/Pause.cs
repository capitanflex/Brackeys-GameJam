using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private GameObject pauseMenu;
    private GameManager _gameManager;

    private bool isOpen ;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // switch (isOpen)
        // {
        //     case false:
        //     {
        //         if (Input.GetKeyDown(KeyCode.P) && !isOpen)
        //         {
        //             print("ds");
        //             pauseMenu.SetActive(true);
        //             _animation.Play("PauseOpen");
        //             Cursor.lockState = CursorLockMode.None;
        //             isOpen = true;
        //             _gameManager.CanMove(false);
        //     
        //         }
        //         break;
        //     }
        //    case true:
        //    {
        //        if (Input.GetKeyDown(KeyCode.P) && isOpen)
        //        {
        //            print("as");
        //            _animation.Play("PauseClose");
        //            isOpen = false;
        //            Cursor.lockState = CursorLockMode.Locked;
        //            _gameManager.CanMove(true);
        //            
        //        }
        //        break;
        //    }
           if (Input.GetKeyDown(KeyCode.P) && !isOpen)
           {
                Open();
                
           }

           else if (Input.GetKeyDown(KeyCode.P) && isOpen)
           {
               Close();
               
           }
    }

    public void Open()
    {
        pauseMenu.SetActive(true);
        _animation.Play("PauseOpen");
        Cursor.lockState = CursorLockMode.None;
        isOpen = true;
        _gameManager.CanMove(false);
    }
    
    public void Close()
    {
        _animation.Play("PauseClose");
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        _gameManager.CanMove(true);
    }

}
